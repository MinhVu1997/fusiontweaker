using System;
//Brazos merge only in FT
using System.Windows.Forms;

namespace FusionTweaker
{
	/// <summary>
	/// Manages various Cool & Quiet related settings of AMD K10 CPUs.
	/// </summary>
	public static class K10Manager
	{
		#region Core-specific functions.

		/// <summary>
		/// Returns the current hardware P-state of a core.
		/// </summary>
		public static int GetCurrentPState(int coreIndex)
		{
            //if (Form1.family == 14) //Brazos
            //{
            //    return (int)((Program.Ols.ReadMsr(0xC0010071u, coreIndex) >> 16) & 0x7);
            //}
            //else
            {
                return (int)((Program.Ols.ReadMsr(0xC0010071u, coreIndex) >> 16) & 0x7);
            }
		}

		/// <summary>
		/// Puts a core into the specified software P-state.
		/// </summary>
		public static void SwitchToPState(int pStateIndex, int coreIndex)
		{
			//Brazos merge next line from BT
			//if (pStateIndex < 0 || pStateIndex > 4)
			if (pStateIndex < 0 || pStateIndex > 7)
				throw new ArgumentOutOfRangeException("pStateIndex");

			Program.Ols.WriteMsr(0xC0010062u, (ulong)pStateIndex, coreIndex);
		}

		#endregion

		#region Functions affecting all cores.

		
		//Brazos merge BT is calling this function GetHighestPState()
		/// <summary>
		/// Returns the currently highest allowed hardware P-state index.
		/// </summary>
		public static int GetCurHighestPState()
		{
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F3xDC[PstateMaxVal]
			uint settings = Program.Ols.ReadPciConfig(0xC3, 0xDC);
			return (int)((settings >> 8) & 0x7);
		}
		
		//Brazos merge function modified in FT
        /// <summary>
        /// Returns the highest allowed hardware P-state index (read-only).
        /// </summary>
        public static int GetHighestPState()
        {
            ulong settings = Program.Ols.ReadMsr(0xC0010061u, 0);

            return (int)((settings >> 4) & 0x7);
		}

        /// <summary>
        /// Returns 1, if C6 state is allowed for cores
        /// </summary>
        public static int GetC6EnableBit()
        {
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F4x118[C6Enable]
            uint settings = Program.Ols.ReadPciConfig(0xC4, 0x118);
            return (int)(settings & 0x1);
        }

        /// <summary>
        /// Returns the bus speed controlled by BIOS.
        /// </summary>
        public static int GetBIOSBusSpeed()
        {
            Program.Ols.WritePciConfig(0x00, 0xE0, 0x013080F1);
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D0F0xE4_x0130_80F1[ClockRate]
            uint settings = Program.Ols.ReadPciConfig(0x00, 0xE4);
            return (int)(settings & 0xFF);
        }

        /// <summary>
        /// Sets the bus speed controlled by BIOS.
        /// </summary>
        public static int SetBIOSBusSpeed(uint fsb)
        {
            Program.Ols.WritePciConfig(0x00, 0xE0, 0x013080F1);
            //D18 Device -> C0
            //D0 Device -> 00
            //Device 00 -> 1022h -> D0 F0
            //10,20,30,40,50,60 -> no device
            // value of interest: D0F0xE4_x0130_80F1[ClockRate]
            uint settings = Program.Ols.ReadPciConfig(0x00, 0xE4);
            settings = settings >> 8; //erasing 8 lowest significant bits
            settings = settings << 8 | fsb; //(settings SwitchToPState 101MHz)
            Program.Ols.WritePciConfig(0x00, 0xE4, settings);
            return (int)(settings & 0xFF);
        }

		//Brazos merge function added from BT
        /// <summary>
        /// Sets the bus speed controlled by BIOS.
        /// </summary>
        public static int GetTemp()
        {
            // value of interest: D18F3xA4[CurTmp]
            uint settings = Program.Ols.ReadPciConfig(0xC3, 0xA4);
            return (int)(((settings >> 21) & 0x7FF) >> 3); //value divided by 8
        }

        /// <summary>
        /// enable DRAM self refresh to be able to change Div and Vid on th NB Pstate by Software switching
        /// </summary>
        public static void DisDllShutDown()
        {
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F2x90[DisDllShutDownSR]
            uint settings = Program.Ols.ReadPciConfig(0xC2, 0x90);
            settings = settings | 0x08000000; //assert Bit27 DisDllShutDownSR
            Program.Ols.WritePciConfig(0xC2, 0x90, settings); //write to register - to enter Self Refresh in the next step
        }

        /// <summary>
        /// enable DRAM self refresh to be able to change Div and Vid on th NB Pstate by Software switching
        /// </summary>
        public static void EnDllShutDown()
        {
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F2x90[DisDllShutDownSR]
            uint settings = Program.Ols.ReadPciConfig(0xC2, 0x90);
            settings = settings & 0xF7FFFFFF; //reset Bit27 DisDllShutDownSR
            Program.Ols.WritePciConfig(0xC2, 0x90, settings); //write to register - finishing Self Refresh process
        }

        /// <summary>
        /// enable DRAM self refresh to be able to change Div and Vid on th NB Pstate by Software switching
        /// </summary>
        public static void EnterDramSelfRefresh()
        {
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F2x90[EnterSelfRef]
            uint settings = Program.Ols.ReadPciConfig(0xC2, 0x90);
            settings = settings | 0x00020000; //assert Bit17 EnterSelfRef
            Program.Ols.WritePciConfig(0xC2, 0x90, settings); //write to register - enter Self Refresh
            uint notdone = 1;
            while (notdone != 0) //waiting for the SelfRefresh to exit
            {
                settings = Program.Ols.ReadPciConfig(0xC2, 0x90);
                notdone = ((settings >> 17) & 0x1);
            }
        }

        /// <summary>
        /// exit DRAM self refresh to be able to change Div and Vid on th NB Pstate by Software switching
        /// </summary>
        public static void ExitDramSelfRefresh()
        {
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F2x90[EnterSelfRef]
            uint settings = Program.Ols.ReadPciConfig(0xC2, 0x90);
            settings = settings | 0x00000002; //assert Bit1 ExitSelfRef
            Program.Ols.WritePciConfig(0xC2, 0x90, settings); //write to register - enter Self Refresh
            uint notdone = 1;
            while (notdone != 0) //waiting for the ExitSelfRefresh to finish
            {
                settings = Program.Ols.ReadPciConfig(0xC2, 0x90);
                notdone = ((settings >> 1) & 0x1);
            }
        }

        /// <summary>
        /// enable Software NB Pstate switching
        /// </summary>
        public static void EnableNBPstateSwitching()
        {
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F6x90[ClockRate]
            uint settings = Program.Ols.ReadPciConfig(0xC6, 0x90);
            settings = settings | 0x40000000; //assert Bit30 NbPsCtrlDis - disable HW switching
            Program.Ols.WritePciConfig(0xC6, 0x90, settings); //write to register - enable SW NB Pstate switching
        }

        /// <summary>
        /// disable Software NB Pstate switching
        /// </summary>
        public static void DisableNBPstateSwitching()
        {
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F6x90[NbPsCtrlDis]
            uint settings = Program.Ols.ReadPciConfig(0xC6, 0x90);
            settings = settings & 0x8FFFFFFF; //reset Bit30:28 NbPsCtrlDis,NbPsForceSel,NbPsForceReq - enable HW switching
            Program.Ols.WritePciConfig(0xC6, 0x90, settings); //write to register - disable SW NB Pstate switching
        }

        /// <summary>
        /// Puts NB into the specified software P-state 1.
        /// </summary>
        public static void SwitchToNbPState(int forcepstate)
        {
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F6x90
            uint settings = Program.Ols.ReadPciConfig(0xC6, 0x90);
            if (forcepstate == 1) settings = settings | 0x20000000; //assert Bit29 NbPsForceSel - target NB-Pstate 1
            else if (forcepstate == 0) settings = settings & 0xDFFFFFFF; //reset Bit29 NbPsForceSel - target NB-Pstate 0
            else return;
            Program.Ols.WritePciConfig(0xC6, 0x90, settings); //write to register - setting target NB-Pstate
            settings = Program.Ols.ReadPciConfig(0xC6, 0x90);
            settings = settings | 0x10000000; //assert Bit30 NbPsForceReq
            Program.Ols.WritePciConfig(0xC6, 0x90, settings); //initiate NB-Pstate request
        }

        /// <summary>
        /// Returns the current NB VID of NB P-state 1.
        /// </summary>
        public static int GetNbPState()
        {
            if (Form1.family == 16) //Kabini
            {
                //D18F5x174 Northbridge P-state Status 20:19 CurNbPstate
                uint settings = Program.Ols.ReadPciConfig(0xC5, 0x174);
                return (int)((settings >> 19) & 0x3);
            } else { //Llano + Brazos
                //D18 Device F0 -> C0
                //D0 Device F0 -> 00
                //10,20,30,40,50,60 -> no device
                // value of interest: D18F6x98[NbPs1Act]
                uint settings = Program.Ols.ReadPciConfig(0xC6, 0x98);
                return (int)((settings >> 2) & 0x1);
            }
        }

        /// <summary>
        /// Returns the current NB VID of NB P-state 0.
        /// </summary>
        public static int GetNbVidPState0()
        {
            if (Form1.family == 16) //Kabini
            {
                //Kabini 16h
                //Register Mapping for D18F5x16[C:0]
                //Register Function
                //D18F5x160 NB P-state 0
                //D18F5x164 NB P-state 1
                //D18F5x168 NB P-state 2
                //D18F5x16C NB P-state 3
                //21 NbVid[7].
                //16:10 NbVid[6:0]: Northbridge VID
                uint settings = Program.Ols.ReadPciConfig(0xC5, 0x160);

                uint nbvidh = ((settings >> 21) & 0x1);
                //uint nbvidl = ((value >> 10) & 0x7F); //SVI2 - 8bits
                uint nbvidl = ((settings >> 11) & 0x3F);
                
                return (int)(nbvidh * 64 + nbvidl);
            }
            else //Llano + Brazos
            {
                //D18 Device F0 -> C0
                //D0 Device F0 -> 00
                //10,20,30,40,50,60 -> no device
                // value of interest: D18F3xDC[NbPs0Vid]
                uint settings = Program.Ols.ReadPciConfig(0xC3, 0xDC);
                return (int)((settings >> 12) & 0x7F);
            }
        }

        /// <summary>
        /// Returns the current NB VID of NB P-state 1.
        /// </summary>
        public static int GetNbVidPState1()
        {
            if (Form1.family == 16) //Kabini
            {
                //Kabini 16h
                //Register Mapping for D18F5x16[C:0]
                //Register Function
                //D18F5x160 NB P-state 0
                //D18F5x164 NB P-state 1
                //D18F5x168 NB P-state 2
                //D18F5x16C NB P-state 3
                //21 NbVid[7].
                //16:10 NbVid[6:0]: Northbridge VID
                uint settings = Program.Ols.ReadPciConfig(0xC5, 0x164);
                uint nbvidh = ((settings >> 21) & 0x1);
                //uint nbvidl = ((value >> 10) & 0x7F); //SVI2 - 8bits
                uint nbvidl = ((settings >> 11) & 0x3F);

                return (int)(nbvidh * 64 + nbvidl);
            }
            else //Llano + Brazos
            {
                //D18 Device F0 -> C0
                //D0 Device F0 -> 00
                //10,20,30,40,50,60 -> no device
                // value of interest: D18F6x90[NbPs0Vid]
                uint settings = Program.Ols.ReadPciConfig(0xC6, 0x90);
                return (int)((settings >> 8) & 0x7F);
            }
        }

        /// <summary>
        /// Returns the current NB CLK DIV of NB P-state 0.
        /// </summary>
        public static double GetNbDivPState0()
        {
            if (Form1.family == 16) //Kabini
            {
                //Kabini 16h
                //Register Mapping for D18F5x16[C:0]
                //Register Function
                //D18F5x160 NB P-state 0
                //D18F5x164 NB P-state 1
                //D18F5x168 NB P-state 2
                //D18F5x16C NB P-state 3
                //NBCOF[0] = (100 * (D18F5x160[NbFid] + 4h) / (2^D18F5x160[NbDid])).
                //7 NbDid: Northbridge divisor ID
                //6:1 NbFid[5]: Northbridge frequency ID.
                uint settings = Program.Ols.ReadPciConfig(0xC5, 0x160);
                uint nbdid = ((settings >> 7) & 0x1);
                uint nbfid = ((settings >> 1) & 0x1F);
                double nclkdiv = (nbfid + 4) / (Math.Pow(2, nbdid));
                return nclkdiv;
            }
            else //Llano + Brazos
            {
                //D18 Device F0 -> C0
                //D0 Device F0 -> 00
                //10,20,30,40,50,60 -> no device
                // value of interest: D18F3xDC[NbPs0NclkDiv] -> default 24d
                uint settings = Program.Ols.ReadPciConfig(0xC3, 0xDC);
                uint nclk = ((settings >> 20) & 0x7F);
                double nclkdiv = 0;
                //NCLK Div 2-16 ind 0.25 steps / Div 16-32 in 0.5 steps / Div 32-63 in 1.0 steps
                if (nclk >= 8 && nclk <= 63) nclkdiv = nclk * 0.25;
                else if (nclk >= 64 && nclk <= 95) nclkdiv = (nclk - 64) * 0.5 - 16;
                else if (nclk >= 96 && nclk <= 127) nclkdiv = nclk - 64;
                else nclkdiv = 0;
                return nclkdiv;
            }
        }

        /// <summary>
        /// Returns the current NB CLK DIV of NB P-state 1.
        /// </summary>
        public static double GetNbDivPState1()
        {
            if (Form1.family == 16) //Kabini
            {
                //Kabini 16h
                //Register Mapping for D18F5x16[C:0]
                //Register Function
                //D18F5x160 NB P-state 0
                //D18F5x164 NB P-state 1
                //D18F5x168 NB P-state 2
                //D18F5x16C NB P-state 3
                //NBCOF[0] = (100 * (D18F5x160[NbFid] + 4h) / (2^D18F5x160[NbDid])).
                //7 NbDid: Northbridge divisor ID
                //6:1 NbFid[5]: Northbridge frequency ID.
                
                uint settings = Program.Ols.ReadPciConfig(0xC5, 0x164);
                uint nbdid = ((settings >> 7) & 0x1);
                uint nbfid = ((settings >> 1) & 0x1F);
                double nclkdiv = (nbfid + 4) / (Math.Pow(2,nbdid)) ;
                return nclkdiv;
            }
            else //Llano + Brazos
            {
                //D18 Device F0 -> C0
                //D0 Device F0 -> 00
                //10,20,30,40,50,60 -> no device
                // value of interest: D18F6x90[NbPs0NclkDiv] -> default 38d
                uint settings = Program.Ols.ReadPciConfig(0xC6, 0x90);
                uint nclk = ((settings >> 0) & 0x7F);
                double nclkdiv = 0;
                //NCLK Div 2-16 ind 0.25 steps / Div 16-32 in 0.5 steps / Div 32-63 in 1.0 steps
                if (nclk >= 8 && nclk <= 63) nclkdiv = nclk * 0.25;
                else if (nclk >= 64 && nclk <= 95) nclkdiv = (nclk - 64) * 0.5 - 16;
                else if (nclk >= 96 && nclk <= 127) nclkdiv = nclk - 64;
                else nclkdiv = 0;
                return nclkdiv;
            }
        }

		/// <summary>
		/// Sets the highest allowed hardware P-state index.
		/// </summary>
		public static void SetHighestPState(int maxIndex)
		{
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F3xDC
            //Brazos merge next line BT
			//if (maxIndex < 0 || maxIndex > 4)
			if (maxIndex < 0 || maxIndex > 7)
				throw new ArgumentOutOfRangeException("maxIndex");

			uint reference = Program.Ols.ReadPciConfig(0xC3, 0xDC);
			uint newSettings = (reference & 0xFFFFF8FFu) | ((uint)maxIndex << 8);

			Program.Ols.WritePciConfig(0xC3, 0xDC, newSettings);
		}


        /// <summary>
        /// Returns the current COF of the main PLL. 6:0 MaxCpuCof from COFVID Status Register
        /// </summary>
        public static uint MainCofEn()
        {
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F3xD4[MainPllOpFreqId]
            uint settings = Program.Ols.ReadPciConfig(0xC3, 0xD4);
            uint Enable = (settings >> 6) & 0x1;

            return Enable;
        }

        /// <summary>
        /// Returns the current COF of the main PLL. 6:0 MaxCpuCof from COFVID Status Register
        /// </summary>
        public static double CurrCOF()
        {
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            // value of interest: D18F3xD4[MainPllOpFreqId]
            uint settings = Program.Ols.ReadPciConfig(0xC3, 0xD4);
            uint curCOF = (settings >> 0) & 0x3F;

            return curCOF;
        }

        /// <summary>
        /// Returns true, if the Motherboard uses SVI2, which uses 8bit encoding for voltages
        /// </summary>
        public static uint SVI2()
        {
            //D18 Device F0 -> C0
            //D0 Device F0 -> 00
            //10,20,30,40,50,60 -> no device
            
            //Program.Ols.WritePciConfig(0x00, 0xE0, 0x013080F1);
            Program.Ols.WritePciConfig(0x00, 0xE0, 0x3F9D8);
            //D0F0xBC_x3F9D8 PM_CONFIG
            //29 SviMode. Read-write.
            //Bits Description
            //0 SVI1.
            //1 SVI2
            
            uint settings = Program.Ols.ReadPciConfig(0x00, 0xBC);
            // value of interest: D0F0xE4_x0130_80F1[ClockRate]
            //uint settings = Program.Ols.ReadPciConfig(0x00, 0xE4);
            return ((settings >> 29) & 0x1);
        }


        /// <summary>
        /// Resets the effective Frequency registers
        /// </summary>
        public static void ResetEffFreq()
        {
            //MSR0000_00E7 [Max Performance Frequency Clock Count (MPERF)]
            //MSR0000_00E8 [Actual Performance Frequency Clock Count (APERF)]
            Program.Ols.WriteMsr(0x000000E7u, 0, 0);
            Program.Ols.WriteMsr(0x000000E8u, 0, 0);
        }

        /// <summary>
        /// Returns the effective Frequency of the system
        /// </summary>
        public static float EffFreq()
        {
            //MSR0000_00E7 [Max Performance Frequency Clock Count (MPERF)]
                //MSR0000_00E8 [Actual Performance Frequency Clock Count (APERF)]
                ulong msr_max = Program.Ols.ReadMsr(0x000000E7u,0);
                ulong msr_act = Program.Ols.ReadMsr(0x000000E8u,0);

                return (msr_act / msr_max * 1600);
         }

		/// <summary>
        /// Returns the maximum supported COF of the main PLL. 54:49 MaxCpuCof from COFVID Status Register
		/// </summary>
		public static double MaxCOF()
		{
            if (Form1.family == 12) //Llano 
            {
                //MSRC001_0071 [MainPllOpFreqIdMax] - 54:49
                ulong msr = Program.Ols.ReadMsr(0xC0010071u);
                int maxCOF = (int)(msr >> 49) & 0x3F;

                return (maxCOF == 0 ? 48 : maxCOF);
            }
            else //Ontario + Kabini
            {
                //MSRC001_0071 [MainPllOpFreqIdMax] - 54:49
                ulong msr = Program.Ols.ReadMsr(0xC0010071u);
                int maxCOF = (int)(msr >> 49) & 0x3F;

                return (maxCOF == 0 ? 31.5 : maxCOF);
            }
       }

		/// <summary>
        /// Gets the CPU's VID limits (for both CPU VID and NB VID). 48:42 MinVid and 41:35 MaxVid from COFVID Status Register
		/// </summary>
		public static void GetVidLimits(out double min, out double max)
		{
            if (Form1.family == 16)
            {
                // value of interest: D18F5x17C
                uint settings = Program.Ols.ReadPciConfig(0xC5, 0x17C);
                uint minValue = (settings >> 10) & 0xFF;
                uint maxValue = (settings >> 0) & 0xFF;

                min = (minValue == 0 ? 0.0125 : 1.55 - minValue * 0.0125);
                max = (maxValue == 0 ? 1.55 : 1.55 - maxValue * 0.0125);
            }
            else
            {
                ulong msr = Program.Ols.ReadMsr(0xC0010071u);

                uint minValue = (uint)(msr >> 42) & 0x7F;
                uint maxValue = (uint)(msr >> 35) & 0x7F;

                min = (minValue == 0 ? 0.0125 : 1.55 - minValue * 0.0125);
                max = (maxValue == 0 ? 1.55 : 1.55 - maxValue * 0.0125);
            }
		}

        /// <summary>
        /// Returns the family in hex.
        /// </summary>
        public static int GetFamily()
        {
            uint eax = 0, ebx = 0, ecx = 0, edx = 0;
            int baseFamily, extFamily, family;
            if (Program.Ols.Cpuid(0x80000001u, ref eax, ref ebx, ref ecx, ref edx) == 0)
                throw new NotSupportedException("Cpuid()");

            baseFamily = (int)((eax >> 8) & 0xF);
            extFamily = (int)((eax >> 20) & 0xF);
            family = baseFamily + extFamily;
            int tmp1 = family % 16;
            int tmp10 = (int)(family / 16);
            family = tmp10 * 10 + tmp1;
            return family;
        }

		/// <summary>
		/// Returns the number of (enabled) CPU cores.
		/// </summary>
		public static int GetNumCores()
		{
			uint eax = 0, ebx = 0, ecx = 0, edx = 0;

			if (Program.Ols.Cpuid(0x80000008u, ref eax, ref ebx, ref ecx, ref edx) == 0)
				throw new NotSupportedException("Cpuid()");

			return (int)(ecx & 0xFF) + 1;
		}

		#endregion

		#region Turbo.

		private static int _isTurboSupported = -1;

		/// <summary>Returns true if the CPU supports Turbo.</summary>
		public static bool IsTurboSupported()
		{
			// cached
			if (_isTurboSupported == -1)
			{
				uint eax = 0, ebx = 0, ecx = 0, edx = 0;
				if (Program.Ols.Cpuid(0x80000007u, ref eax, ref ebx, ref ecx, ref edx) != 0)
					_isTurboSupported = ((int)edx >> 9) & 1;
				else
					_isTurboSupported = 0;
			}

            return (_isTurboSupported != 0); //returns true, if Turbo is supported (C-60) 
            //return true;
		}

		//Brazos merge function from BT
		//ToDo 
		/// <summary>
		/// Returns true if the Turbo is not supported or locked
		/// (number of boosted states and Turbo cores).
		/// </summary>
		/*public static bool IsTurboLocked()
		{
			if (!IsTurboSupported())
				return true; //returns true, if Turbo is not supported (C-50) 

			uint lower = Program.Ols.ReadPciConfig(0xC4, 0x15C);
			return ((lower & 0x80000000u) != 0);
		}*/

		//Brazos merge function only in FT
		/// <summary>
		/// Returns true if the Turbo is enabled
		/// (number of boosted states == 0 or battery powered (?)).
		/// </summary>
		public static bool IsTurboEnabled()
		{
			if (!IsTurboSupported())
				return false;

			uint lower = Program.Ols.ReadPciConfig(0xC4, 0x15C);
            //MessageBox.Show((lower & 0x3u).ToString());
			return ((lower & 0x1u) == 1); //returns true, if Turbo is enabled / Bit 1 behaves odd, will disregard it 
		}

		//Brazos merge function from BT, might be outdated
		//ToDo check, if the function works on all families
		/*
				/// <summary>
		/// Tries to enable/disable the Turbo and returns true if successful.
		/// If the number of boosted P-states is unlocked, it is set appropriately.
		/// </summary>
		public static bool SetTurbo(bool enable)
		{
			if (!IsTurboSupported())
				return false; 

			uint lower = Program.Ols.ReadPciConfig(0xC4, 0x15C);
			bool isLocked = ((lower & 0x80000000u) != 0);

			uint newLower = (lower & 0xFFFFFFFCu) | (enable ? 3u : 0u);
			// set the number of boosted states if unlocked
			if (!isLocked)
				newLower = (newLower & 0xFFFFFFFBu) | (enable ? 1u << 2 : 0u);

			if (newLower != lower)
				Program.Ols.WritePciConfig(0xC4, 0x15C, newLower);

			return true;
		}
		*/

		/// <summary>
		/// Tries to enable/disable the Turbo and returns true if successful.
		/// If the number of boosted P-states is unlocked, it is set appropriately.
		/// </summary>
		public static bool SetTurbo(bool enable)
		{
			if (!IsTurboSupported())
				return false;

			uint lower = Program.Ols.ReadPciConfig(0xC4, 0x15C);
            
            uint newLower = (lower & 0xFFFFFFFEu) | (enable ? 1u : 0u); //deleting bit 0 and setting it (BoostSrc page 339)
			                                                            // Bit 1 behaves odd, will be ignored
			if (newLower != lower)
				Program.Ols.WritePciConfig(0xC4, 0x15C, newLower);

            //MessageBox.Show((lower & 0x3u).ToString() + " " + (newLower & 0x3u).ToString());
			return true;
		}

		/// <summary>
		/// sets handling of requirements for a given core to enter boosted PState, when no others are boosted
		/// true => All cores power consuption must be below limit
        /// false => A given cores's power consumption must be below limt
		/// </summary>
		public static bool SetBoostEnAllCores(bool enable)
		{
            if (!IsTurboEnabled())
				return false;

            uint lower = Program.Ols.ReadPciConfig(0xC4, 0x15C);

            uint newLower = (lower & 0xDFFFFFFFu) | (enable ? 20000000u : 0u); //deleting bit 29 and setting them (page 339)

            if (newLower != lower)
                Program.Ols.WritePciConfig(0xC4, 0x15C, newLower);

            return true;
		}

		/// <summary>Returns the number of boosted (Turbo) P-states.</summary>
		public static int GetNumBoostedStates()
		{
			if (!IsTurboSupported())
				return 0;

			uint lower = Program.Ols.ReadPciConfig(0xC4, 0x15C);

			return ((int)lower >> 2) & 3;
		}
		//Brazos merge older functions from BT, which were not used
		/*

		/// <summary>
		/// Tries to set the maximum number of cores in the Turbo state at a time and
		/// returns true if successful.
		/// </summary>
		public static bool SetNumTurboCores(int num)
		{
			if (IsTurboLocked())
				return false;

			uint numIdleCores = (uint)(GetNumCores() - num);

			uint lower = Program.Ols.ReadPciConfig(0xC4, 0x16C);
			uint newLower = (lower & 0xFFFFF1FFu) | ((numIdleCores & 7) << 9);

			if (newLower != lower)
				Program.Ols.WritePciConfig(0xC4, 0x16C, newLower);

			return true;
		}

		/// <summary>Returns true if the Turbo is enabled and if there are boosted P-states.</summary>
		public static bool IsTurboEnabled()
		{
			if (!IsTurboSupported())
				return false;

			uint lower = Program.Ols.ReadPciConfig(0xC4, 0x15C);

			return ((lower & 7) == 7); // check if enabled and if there is a boosted state
		}

		/// <summary>Returns the number of boosted (Turbo) P-states.</summary>
		public static int GetNumBoostedStates()
		{
			if (!IsTurboSupported())
				return 0;

			uint lower = Program.Ols.ReadPciConfig(0xC4, 0x15C);

			return ((int)lower >> 2) & 1;
		}

		/// <summary>
		/// Returns the maximum number of cores in the Turbo state at a time.
		/// </summary>
		public static int GetNumTurboCores()
		{
			if (!IsTurboSupported())
				return 0;

			uint lower = Program.Ols.ReadPciConfig(0xC4, 0x16C);
			uint numIdleCores = (lower >> 9) & 7;

			return GetNumCores() - (int)numIdleCores;
		}

		*/
		#endregion
	}
}
