using System;
using System.Windows.Forms;

namespace FusionTweaker
{
	/// <summary>
	/// Represents a set of P-state settings for all cores of a CPU.
	/// </summary>
	public sealed partial class PStateControl : UserControl
	{
		private static readonly int _numCores = System.Environment.ProcessorCount;

		// cached:
		private static double _maxCOF = -1;
        private static double _minVid, _maxVid;

		private int _index = -1; // 0-7 CPU and 8,9 NB
		private PState _pState;

		private int _optimalWidth;
		private bool _modified;


		/// <summary>
		/// Gets or sets the associated hardware P-state index (0-7). Adding NB P-states (8,9)
		/// </summary>
		public int PStateIndex
		{
			get { return _index; }
			set
			{
				if (value < 0 || value > 9)
					throw new ArgumentOutOfRangeException("PStateIndex");

				_index = value;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the control has been modified by the user
		/// since the last load/save operation.
		/// </summary>
		public bool IsModified
		{
			get { return _modified; }
		}

		/// <summary>
		/// Gets the currently selected CPU/NB VID.
		/// </summary>
		public double Vid
		{
			get { return (double)VidNumericUpDown.Value; }
		}

		/// <summary>
		/// Gets the currently selected FSB.
		/// </summary>
		public double FSB
		{
			get { return (double)FSBNumericUpDown.Value; }
		}


		/// <summary>
		/// Constructor.
		/// </summary>
		public PStateControl()
		{
			InitializeComponent();

			// check if the CPU's maximum multi is limited (non Black Edition CPUs)
			if (_maxCOF < 0)
			{
				// in DesignMode, Program.Ols is null
				if (Program.Ols == null)
				{
					_maxCOF = 48;
					_minVid = 0.0125;
					_maxVid = 1.55;
				}
				else
				{
					_maxCOF = K10Manager.MaxCOF() + 16;
                    //double _curDiv = K10Manager.CurrCOF();
                    //uint MainDivEn = K10Manager.MainCofEn();
					K10Manager.GetVidLimits(out _minVid, out _maxVid);
				}
			}

			VidNumericUpDown.Minimum = (decimal)_minVid;
            FSBNumericUpDown.Minimum = 0;
			VidNumericUpDown.Maximum = (decimal)_maxVid;
            FSBNumericUpDown.Maximum = 200;

			// add as many NumericUpDown controls as there are CPU cores for the multis
			for (int i = 0; i < _numCores; i++)
			{
				var control = new NumericUpDown()
				{
					AutoSize = true,
					DecimalPlaces = 2,
                    Increment = (decimal)1,
                    Maximum = (decimal)_maxCOF,
					Minimum = 4,
                    TabIndex = i,
					TextAlign = HorizontalAlignment.Center,
					Value = 4,
				};
                toolTip1.SetToolTip(control, "CPUMultNBDivider for core " + (i + 1) + ".\r\nReference clock (default: 100 MHz) times " + (K10Manager.MaxCOF() + 16) + " divided by the chosen value yields the core speed.");

				control.ValueChanged += (s, e) => _modified = true;

				if (i == 0)
				{
					control.ValueChanged += (s, e) =>
					{
						for (int j = 1; j < _numCores; j++)
						{
							var otherControl = (NumericUpDown)flowLayoutPanel1.Controls[j];
							otherControl.Value = control.Value;
						}
					};
				}

				flowLayoutPanel1.Controls.Add(control);
			}

			VidNumericUpDown.ValueChanged += (s, e) => _modified = true;
		    FSBNumericUpDown.ValueChanged += (s, e) => _modified = true;

			// set the tab order
			VidNumericUpDown.TabIndex = 3 + _numCores;
			FSBNumericUpDown.TabIndex = VidNumericUpDown.TabIndex + 1;
			refreshButton.TabIndex = FSBNumericUpDown.TabIndex + 1;

			// compute the optimal width, based on the number of cores
			_optimalWidth = Cofstate.Width + Cofstate.Margin.Horizontal + flowLayoutPanel1.Controls.Count *
				(flowLayoutPanel1.Controls[0].Width + flowLayoutPanel1.Controls[0].Margin.Horizontal) + 270;

			refreshButton.Click += (s, e) => LoadFromHardware(_index);
		}

		/// <summary>
		/// Returns the delta for the optimal width, based upon the number of cores.
		/// </summary>
		public int GetDeltaOptimalWidth()
		{
			return (_optimalWidth - this.Width);
		}


		/// <summary>
		/// Loads the P-state settings from each core's MSR.
		/// </summary>
		public void LoadFromHardware(int pstatetab)
		{
            if (pstatetab < 0)
				throw new InvalidOperationException("The PStateIndex property needs to be initialized first.");

            if (pstatetab < 8) //hardware loads for CPU
            {
                if (pstatetab <= K10Manager.GetHighestPState()) //skip, in case index is bigger than initialized CPU PStates 
                {
                    _pState = PState.Load(pstatetab);

                    double maxCpuVid = 0;
                    for (int i = 0; i < _pState.Msrs.Length; i++)
                    {
                        var msr = _pState.Msrs[i];

                        var control = (NumericUpDown)flowLayoutPanel1.Controls[i];
                        control.Value = (decimal)msr.CPUMultNBDivider;

                        maxCpuVid = Math.Max(maxCpuVid, msr.Vid);
                    }

                    VidNumericUpDown.Value = Math.Min(VidNumericUpDown.Maximum, (decimal)maxCpuVid);
                    //int check = K10Manager.SetBIOSBusSpeed(80); 
                    FSBNumericUpDown.Value = (decimal)K10Manager.GetBIOSBusSpeed();
                    pllfreq.Text = "P" + pstatetab + " Freq (CPU): " + (int)_pState.Msrs[0].PLL + "MHz";
                    Cofstate.Text = "Mult = "; 
                }
                else
                {
                    VidNumericUpDown.Value = 1;
                    FSBNumericUpDown.Value = 100;
                }
            }
            else if (pstatetab == 8) 
            {
                //hardware loads for NB P0
                _pState = PState.Load(pstatetab);
                var control = (NumericUpDown)flowLayoutPanel1.Controls[0];
                control.Value = (decimal)K10Manager.GetNbDivPState0(); 
                VidNumericUpDown.Value = (decimal)(1.55 - 0.0125 * K10Manager.GetNbVidPState0());
                FSBNumericUpDown.Value = (decimal)K10Manager.GetBIOSBusSpeed();
                pllfreq.Text = "NB P0 Freq (GPU): " + (int)_pState.Msrs[0].PLL + "MHz";
                Cofstate.Text = "Mult = " + (K10Manager.CurrCOF() + 16) + " divided by ->"; 
            }
            else if (pstatetab == 9)
            {
                //hardware loads for NB P0
                _pState = PState.Load(pstatetab);
                var control = (NumericUpDown)flowLayoutPanel1.Controls[0];
                control.Value = (decimal)K10Manager.GetNbDivPState1();
                VidNumericUpDown.Value = (decimal)(1.55 - 0.0125 * K10Manager.GetNbVidPState1());
                FSBNumericUpDown.Value = (decimal)K10Manager.GetBIOSBusSpeed();
                pllfreq.Text = "NB P1 Freq (GPU): " + (int)_pState.Msrs[0].PLL + "MHz";
                Cofstate.Text = "Mult = " + (K10Manager.CurrCOF() + 16) + " divided by ->"; 
            }
            else if (pstatetab == 10) //settings for displaying registers
            {
                VidNumericUpDown.Value = 1;
                FSBNumericUpDown.Value = 100;
            }
            _modified = false;
		}

		/// <summary>
		/// Saves the current P-state settings to each core's MSR.
		/// </summary>
		public void Save()
		{
			if (!_modified)
				return;

			if (_pState == null)
				throw new InvalidOperationException("Load a P-state first for safe initialization.");

			for (int i = 0; i < _numCores; i++)
			{
				var control = (NumericUpDown)flowLayoutPanel1.Controls[i];

				_pState.Msrs[i].CPUMultNBDivider = (double)control.Value;
				_pState.Msrs[i].Vid = (double)VidNumericUpDown.Value;
				_pState.Msrs[i].FSB = (double)FSBNumericUpDown.Value;
			}

			_pState.Save(_index);

			_modified = false;
		}
	}
}
