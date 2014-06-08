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
		//Brazos merge added next line from BT
		private static int _maxPstate = -1;

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
				//Brazos merge BT
				//if (value < 0 || value > 5)
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
                    if (Form1.family == 12) //Llano
                    {
                        _maxCOF = 48;
                    }
                    else
                    {
                        _maxCOF = 31.5;
					}

                    _minVid = 0.0125;
					_maxVid = 1.55;
					//Brazos merge next line added from BT
					_maxPstate = -1;
				}
                else if (Form1.family == 14) //Brazos
				{
					_maxCOF = K10Manager.MaxCOF() + 16; 
                    
					//Brazos merge next line added from BT
					_maxPstate = K10Manager.GetHighestPState();
                    K10Manager.GetVidLimits(out _minVid, out _maxVid);
                }
                else //Kabini
                {
                    _maxCOF = K10Manager.MaxCOF();

                    //Brazos merge next line added from BT
                    _maxPstate = K10Manager.GetHighestPState();
                    K10Manager.GetVidLimits(out _minVid, out _maxVid);
                }
			} 

			VidNumericUpDown.Minimum = (decimal)_minVid;
            VidNumericUpDown.Maximum = (decimal)_maxVid;
 
			// add as many NumericUpDown controls as there are CPU cores for the multis
			for (int i = 0; i < _numCores; i++)
			{
				var control = new NumericUpDown()
				{
					AutoSize = true,
					DecimalPlaces = 2,
                    Increment = (decimal)0.25,
					Maximum = (decimal)_maxCOF,
					Minimum = 1,
                    TabIndex = i,
					TextAlign = HorizontalAlignment.Center,
					Value = 4,
				};
                if (Form1.family == 12) //Llano
                {
                    control.Increment = (decimal)1;
                    control.Minimum = 4;
                }
                if (Form1.family == 16) //Kabini
                {
                    control.Increment = (decimal)0.5;
                    control.Minimum = 4;
                }


                toolTip1.SetToolTip(control, "CPUMultNBDivider for core " + (i + 1) + ".\r\nReference clock (default: 100 MHz) times " + _maxCOF + " divided by the chosen value yields the core speed.");

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
		    
			// set the tab order
			VidNumericUpDown.TabIndex = 3 + _numCores;
			refreshButton.TabIndex = VidNumericUpDown.TabIndex + 1;

			// compute the optimal width, based on the number of cores
			_optimalWidth = Cofstate.Width + Cofstate.Margin.Horizontal + flowLayoutPanel1.Controls.Count *
				(flowLayoutPanel1.Controls[0].Width + flowLayoutPanel1.Controls[0].Margin.Horizontal) + 270;

			//Brazos merge next line from BT
			//refreshButton.Click += (s, e) => LoadFromHardware(_index);
			refreshButton.Click += (s, e) => LoadFromHardware();
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
        public void LoadFromHardware()
        {
            if (_index < 0)
                throw new InvalidOperationException("The PStateIndex property needs to be initialized first.");

            if (_index < 8) //hardware loads for CPU
            {
                //FT if (_index <= K10Manager.GetHighestPState() + K10Manager.GetNumBoostedStates()) //skip, in case index is bigger than initialized CPU PStates 
                if (_index <= 7)//_maxPstate) //skip, in case just 2 CPU PStates are initialized 
                {
                    _pState = PState.Load(_index);
                    double maxCpuVid = 0;
                    for (int i = 0; i < _pState.Msrs.Length; i++)//iterating through cores
                        {
                            var msr = _pState.Msrs[i];

                            var control = (NumericUpDown)flowLayoutPanel1.Controls[i];
                            control.Value = (decimal)msr.CPUMultNBDivider;

                            maxCpuVid = Math.Max(maxCpuVid, msr.Vid);
                            
                        }

                    VidNumericUpDown.Value = Math.Min(VidNumericUpDown.Maximum, (decimal)maxCpuVid);
                    //int check = K10Manager.SetBIOSBusSpeed(80); 
                    pllfreq.Text = "P" + _index + " Freq (CPU): ";
                    clockvalue.Text = K10Manager.GetBIOSBusSpeed() + "MHz"; 
                    freqvalue.Text = (int)_pState.Msrs[0].PLL + "MHz";
                    if ((Form1.family == 12) || (Form1.family == 16)) { //Llano + Kabini
                        Cofstate.Text = "Mult = ";
                    } else { //Brazos
                        Cofstate.Text = "Mult = " + (K10Manager.CurrCOF() + 16) + " divided by ->";
                    }
                    Form1.freq[_index] = (int)_pState.Msrs[0].PLL;
                    if (PStateIndex <= _maxPstate)
                    {
                        checkBox_Penable.Checked = true;
                        checkBox_Penable.Enabled = false;
                    }
                    else
                    {
                        checkBox_Penable.Checked = false;
                        checkBox_Penable.Enabled = false;
                    }
                }
                else
                {
                    VidNumericUpDown.Value = (decimal)0.4;
                }
            } else if (_index == 8)
            {
                //hardware loads for NB P0
                _pState = PState.Load(_index);
                var control = (NumericUpDown)flowLayoutPanel1.Controls[0];
                control.Value = (decimal)K10Manager.GetNbDivPState0();
                VidNumericUpDown.Value = (decimal)(1.55 - 0.0125 * K10Manager.GetNbVidPState0());
                pllfreq.Text = "NB P0 Freq (GPU): ";
                Cofstate.Text = "Mult = " + (K10Manager.CurrCOF() + 16) + " divided by ->";
                clockvalue.Text = K10Manager.GetBIOSBusSpeed() + "MHz";
                freqvalue.Text = (int)_pState.Msrs[0].PLL + "MHz";
                Form1.freq[_index] = (int)_pState.Msrs[0].PLL;
                checkBox_Penable.Checked = true;
                checkBox_Penable.Enabled = false;
            }
            else if (_index == 9)
            {
                //hardware loads for NB P1
                _pState = PState.Load(_index);
                var control = (NumericUpDown)flowLayoutPanel1.Controls[0];
                control.Value = (decimal)K10Manager.GetNbDivPState1();
                VidNumericUpDown.Value = (decimal)(1.55 - 0.0125 * K10Manager.GetNbVidPState1());
                pllfreq.Text = "NB P1 Freq (GPU): ";
                clockvalue.Text = K10Manager.GetBIOSBusSpeed() + "MHz";
                freqvalue.Text = (int)_pState.Msrs[0].PLL + "MHz";
                Cofstate.Text = "Mult = " + (K10Manager.CurrCOF() + 16) + " divided by ->";
                Form1.freq[_index] = (int)_pState.Msrs[0].PLL;
                checkBox_Penable.Checked = true;
                checkBox_Penable.Enabled = false;
            }
            else if (_index == 10) //settings for displaying registers
            {
                VidNumericUpDown.Value = 1;
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
				
				//Brazos merge next line from BT
				//_pState.Msrs[i].Divider = (double)control.Value;
				_pState.Msrs[i].CPUMultNBDivider = (double)control.Value;
				_pState.Msrs[i].Vid = (double)VidNumericUpDown.Value;
				_pState.Msrs[i].Enabled = 1;
                checkBox_Penable.Checked = true;
			}

			_pState.Save(_index);

			_modified = false;
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Penable.Checked)
            {
                for (int i = 0; i < _numCores; i++)
                {
                    _pState.Msrs[i].Enabled = 1;
                    //MessageBox.Show("Check 0 - " + _pState.Msrs[i].Enabled);
                }
                //_pState.Save(_index);
            }
            else
            {
                for (int i = 0; i < _numCores; i++)
                {
                    _pState.Msrs[i].Enabled = 0;
                    //MessageBox.Show("Check 1 - " + _pState.Msrs[i].Enabled);
                }
                //_pState.Save(_index);
            }
        }
	}
}
