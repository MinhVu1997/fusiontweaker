using System;
using System.Threading;
//Brazos merge next line added from BT
using System.Windows.Forms;

namespace FusionTweaker
{
	/// <summary>
	/// CPU settings for all cores and a given P-state.
	/// </summary>
	public class PState
	{
		private static readonly int _numCores = System.Environment.ProcessorCount;
		//Brazos merge next line added from BT
        private static int _maxPstate = K10Manager.GetHighestPState();

		private PStateMsr[] _msrs = new PStateMsr[_numCores];


		/// <summary>
		/// Gets the per-core settings.
		/// </summary>
		public PStateMsr[] Msrs { get { return _msrs; } }


		/// <summary>
		/// Private constructor. Use Load() or Decode() to create an instance.
		/// </summary>
		private PState()
		{
		}


		/// <summary>
		/// Loads the specified P-state from the cores' and NB MSRs.
		/// </summary>
		/// <param name="index">Index of the hardware P-state (0-7) to be loaded. Adding NB P-state (8,9)</param>
		public static PState Load(int index)
		{
			//Brazos merge next line from BT
			//if (index < 0 || index > 4)
			if (index < 0 || index > 9)
				throw new ArgumentOutOfRangeException("index");

			var r = new PState();

			for (int i = 0; i < _numCores; i++)
				r._msrs[i] = PStateMsr.Load(index, i);

			return r;
		}

		/// <summary>
		/// Saves the P-state to the cores' and NB MSRs.
		/// </summary>
        /// <param name="index">Index of the hardware P-state (0-4) to be modified. Adding NB P-state (8,9)</param>
		public void Save(int index)
		{
			//Brazos merge next line from BT
			//if (index < 0 || index > 4)
			if (index < 0 || index > 9)
				throw new ArgumentOutOfRangeException("index");

            //Brazos merge next line from BT
			//if (index < 3) //dealing with CPU P-States
			if (index < 8) //dealing with CPU P-States
            {
                uint msrIndex = 0xC0010064u + (uint)index;

                //Brazos merge next line commented out in BT
				int boostedStates = K10Manager.GetNumBoostedStates();
                //Brazos merge next line active in BT
				//int boostedStates = 0;
                int indexSw = Math.Max(0, index - boostedStates);

                //Brazos merge next line active in BT
				//int tempPStateHw = (index <= boostedStates ? _maxPstate : 0);
				int tempPStateHw = (index <= boostedStates ? K10Manager.GetHighestPState() : 0);
                int tempPStateSw = Math.Max(0, tempPStateHw - boostedStates);

                // switch temporarily to the highest thread priority
                // (we try not to interfere with any kind of C&Q)
                var previousPriority = Thread.CurrentThread.Priority;
                Thread.CurrentThread.Priority = ThreadPriority.Highest;

                    bool[] applyImmediately = new bool[_numCores];
                    for (int i = 0; i < _numCores; i++)
                    {
                        applyImmediately[i] = (K10Manager.GetCurrentPState(i) == index);

                        // if the settings are to be applied immediately, switch temporarily to another P-state
                        if (applyImmediately[i])
                            K10Manager.SwitchToPState(tempPStateSw, i);
                    }
                    Thread.Sleep(3); // let transitions complete
                    for (int i = 0; i < _numCores; i++)
                    {
                        // save the new settings
                        ulong msr = Program.Ols.ReadMsr(msrIndex, i);

                        ulong mask = 0xFE00FFFFu; //Brazos + Llano Bits 15 .. 0 Vid + Mult
                        if (Form1.family == 16) 
                        {
                            mask = 0xFE01FFFFu; //Kabini Bits 16 .. 0 Vid + Mult
                        }
                        else
                        {
                            msr = (msr & ~mask) | (_msrs[i].Encode(index) & mask);
                            Program.Ols.WriteMsr(msrIndex, msr, i);
                        }
                        // apply the new settings by switching back
                        if (applyImmediately[i])
                            K10Manager.SwitchToPState(indexSw, i);
                    }
                    Thread.Sleep(3); // let transitions complete
                

                Thread.CurrentThread.Priority = previousPriority;
            }
            else if (index == 8 || index == 9) //dealing with NB P-State 0
            {
                if (Form1.family == 16) //Kabini
                {

                }
                else //Brazos + Llano
                {
                    // switch temporarily to the highest thread priority
                    // (we try not to interfere with any kind of C&Q)
                    var previousPriority = Thread.CurrentThread.Priority;
                    Thread.CurrentThread.Priority = ThreadPriority.Highest;

                    //check, if current NB P-State is the one, which is going to be modified
                    //Brazos merge next line from BT
                    //index = index - 3;
                    index = index - 8;
                    int curNbstate = K10Manager.GetNbPState();

                    string message = "Start: " + curNbstate;

                    int changedNbstate = curNbstate;
                    bool applyImmediately = (curNbstate != index);

                    K10Manager.EnableNBPstateSwitching();

                    applyImmediately = (curNbstate != index);

                    // if the settings are to be applied immediately, switch temporarily to another P-state
                    if (applyImmediately)
                    {
                        K10Manager.SwitchToNbPState(index);
                        for (int i = 0; i < 10; i++)
                        {
                            //Brazos merge BT uses Sleep 100 and i=1000
                            Thread.Sleep(20); // let transitions complete
                            changedNbstate = K10Manager.GetNbPState();
                            if (changedNbstate == index)
                            {
                                message += " Time_init_switch: " + i;
                                i = 10;
                            }
                        }
                    }

                    curNbstate = K10Manager.GetNbPState();

                    if (index == 0) // NB P-state0
                    {
                        //DRAM needs to be set into SelfRefresh
                        //K10Manager.DisDllShutDown();
                        //K10Manager.EnterDramSelfRefresh(); //NB Pstate HW switching needs to be disabled before NbPsCtrDis
                        // save the new settings
                        uint config = Program.Ols.ReadPciConfig(0xC3, 0xDC);
                        //const uint mask = 0x07F7F000; //enable overwrite of Vid and Div
                        const uint mask = 0x0007F000; //enable overwrite of Vid only
                        //Brazos merge next line from BT
                        //config = (config & ~mask) | (_msrs[0].Encode(index + 3) & mask);
                        config = (config & ~mask) | (_msrs[0].Encode(index + 8) & mask);
                        uint voltage = Program.Ols.ReadPciConfig(0xC3, 0x15C);
                        //Brazos next 4 lines from BT
                        //ToDo family dependent code
                        /*
                        //const uint maskvolt = 0x00007F00;
                        const uint maskvolt = 0x7F7F7F00; //overwriting VIDSelect2 and 3 in addition
                        uint check = _msrs[0].Encode(index + 3) >> 12 & 0x7F;
                        voltage = (voltage & ~maskvolt) | ((check << 24) | (check << 16) | (check << 8) & maskvolt);
                        */
                        const uint maskvolt = 0x00007F00;
                        uint check = _msrs[0].Encode(index + 8) >> 12 & 0x7F;
                        voltage = (voltage & ~maskvolt) | ((check << 8) & maskvolt);

                        Program.Ols.WritePciConfig(0xC3, 0xDC, config);
                        Program.Ols.WritePciConfig(0xC3, 0x15C, voltage);
                    }
                    else if (index == 1)
                    {
                        // save the new settings
                        //K10Manager.DisDllShutDown();
                        //K10Manager.EnterDramSelfRefresh(); //NB Pstate HW switching needs to be disabled before NbPsCtrDis
                        uint config = Program.Ols.ReadPciConfig(0xC6, 0x90);
                        //const uint mask = 0x00007F7F; //enable DID and VID modification
                        const uint mask = 0x00007F00; //enable VID modification only
                        //Brazos merge next line from BT
                        //config = (config & ~mask) | (_msrs[0].Encode(index + 3) & mask);
                        config = (config & ~mask) | (_msrs[0].Encode(index + 8) & mask);
                        uint voltage = Program.Ols.ReadPciConfig(0xC3, 0x15C);
                        const uint maskvolt = 0x0000007F;
                        //Brazos merge next line from BT
                        //uint check = _msrs[0].Encode(index + 3) >> 8;
                        uint check = _msrs[0].Encode(index + 8) >> 8;
                        voltage = (voltage & ~maskvolt) | (check & maskvolt);

                        Program.Ols.WritePciConfig(0xC6, 0x90, config);
                        Program.Ols.WritePciConfig(0xC3, 0x15C, voltage);
                    }

                    if (curNbstate == 0)
                    {
                        K10Manager.SwitchToNbPState(1);
                        for (int i = 0; i < 10; i++)
                        {
                            //Brazos merge BT uses Sleep 100 and i=1000
                            Thread.Sleep(20); // let transitions complete
                            changedNbstate = K10Manager.GetNbPState();
                            if (changedNbstate == 1)
                            {
                                message += " Time_P0_P1: " + i;
                                i = 10;
                            }
                        }
                        K10Manager.SwitchToNbPState(0);
                        for (int i = 0; i < 10; i++)
                        {
                            //Brazos merge BT uses Sleep 100 and i=1000
                            Thread.Sleep(20); // let transitions complete
                            changedNbstate = K10Manager.GetNbPState();
                            if (changedNbstate == 0)
                            {
                                message += " Time_P1_P0: " + i;
                                i = 10;
                            }
                        }
                    }
                    else if (curNbstate == 1)
                    {
                        K10Manager.SwitchToNbPState(0);
                        for (int i = 0; i < 10; i++)
                        {
                            //Brazos merge BT uses Sleep 100 and i=1000
                            Thread.Sleep(20); // let transitions complete
                            changedNbstate = K10Manager.GetNbPState();
                            if (changedNbstate == 0)
                            {
                                message += " Time_P1_P0: " + i;
                                i = 10;
                            }
                        }
                        K10Manager.SwitchToNbPState(1);
                        for (int i = 0; i < 10; i++)
                        {
                            //Brazos merge BT uses Sleep 100 and i=1000
                            Thread.Sleep(20); // let transitions complete
                            changedNbstate = K10Manager.GetNbPState();
                            if (changedNbstate == 1)
                            {
                                message += " Time_P0_P1: " + i;
                                i = 10;
                            }
                        }
                    }

                    //K10Manager.ExitDramSelfRefresh();
                    //K10Manager.EnDllShutDown();

                    K10Manager.DisableNBPstateSwitching();
                    //MessageBox.Show(message);
                    Thread.CurrentThread.Priority = previousPriority;
                }
            }
		}


		/// <summary>
		/// Decodes a P-state from its string representation.
		/// </summary>
		/// <returns></returns>
		public static PState Decode(string text,int pstate)
		{
			if (string.IsNullOrEmpty(text))
				return null;

			string[] tokens = text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			if (tokens == null || tokens.Length != _numCores)
				return null;

			var r = new PState();

			for (int i = 0; i < _numCores; i++)
			{
				uint value = uint.Parse(tokens[i], System.Globalization.NumberStyles.HexNumber);
				r._msrs[i] = PStateMsr.Decode(value,pstate);
			}

			return r;
		}

		/// <summary>
		/// Encodes the P-state into a string.
		/// </summary>
		public string Encode(int pstate)
		{
			var sb = new System.Text.StringBuilder();

			for (int i = 0; i < _numCores; i++)
			{
				uint value = _msrs[i].Encode(pstate);

				sb.Append(value.ToString("X8"));

				if (i < _numCores - 1)
					sb.Append('|');
			}

			return sb.ToString();
		}


		/// <summary>
		/// Returns a human-readable string representation.
		/// </summary>
		public override string ToString()
		{
			var sb = new System.Text.StringBuilder();

            double maxVid = 0, maxCLK = 0;
            int maxPLL = 0;
			for (int i = 0; i < _msrs.Length; i++)
			{
				//Brazos merge next line from BT
				//sb.Append(_msrs[i].Divider);
				sb.Append(_msrs[i].CPUMultNBDivider);
				if (i < _numCores - 1)
					sb.Append('|');

                maxVid = Math.Max(maxVid, _msrs[i].Vid);
                maxCLK = Form1.clock;
                maxPLL = (int)Math.Max(maxCLK, _msrs[i].PLL);
			}

            sb.AppendFormat(" @ {0}V/{1}MHz/{2}MHz", maxVid, maxCLK, maxPLL);

			return sb.ToString();
		}
	}
}
