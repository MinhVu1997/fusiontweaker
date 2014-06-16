using System;

namespace FusionTweaker
{
	/// <summary>
	/// Represents the interesting MSR settings of a CPU core's P-state.
	/// </summary>
	public struct PStateMsr
	{
		/// <summary>
		/// Core multiplicator (4, 4.5, 5, ..., 31.5).
		/// </summary>
		//Brazos merge BT
		//public double Divider { get; set; }
		public double CPUMultNBDivider { get; set; }

		/// <summary>
		/// Core voltage ID (0.0125 ... 1.55V).
		/// </summary>
		public double Vid { get; set; }

		/// <summary>
		/// Pstate enabled.
		/// </summary>
		public uint Enabled { get; set; }

        /// <summary>
        /// Core / GPU frequency.
        /// </summary>
        public double PLL { get; set; }

        /// <summary>
		/// Loads a core's P-state.
		/// </summary>
		public static PStateMsr Load(int pStateIndex, int coreIndex)
		{
			//Brazos merge BT
			//if (pStateIndex < 0 || pStateIndex > 4)
			if (pStateIndex < 0 || pStateIndex > 9)
				throw new ArgumentOutOfRangeException("pStateIndex");

            uint lower = 0;
            //branch here for CPU- and NB-Pstates 
            //Brazos merge BT
			//if (pStateIndex < 3)
			if (pStateIndex < 8)
            {
                lower = (uint)(Program.Ols.ReadMsr(0xC0010064u + (uint)pStateIndex, coreIndex) & 0xFFFFFFFFu);
            }
            //Brazos merge BT
			//else if (pStateIndex == 3)
			else if (pStateIndex == 8)
            {
                if (Form1.family == 16)//Kabini
                {
                    lower = Program.Ols.ReadPciConfig(0xC5, 0x160);
                }
                else //Llano + Brazos
                {
                    // value of interest: F3xDC NbPstate0Register
                    lower = Program.Ols.ReadPciConfig(0xC3, 0xDC);
                }
            }
            //Brazos merge BT
			//else if (pStateIndex == 4)
			else if (pStateIndex == 9)
            {
                if (Form1.family == 16)//Kabini
                {
                    lower = Program.Ols.ReadPciConfig(0xC5, 0x164);
                }
                else //Llano + Brazos
                {
                    // value of interest: F6x90 NbPstate1Register
                    lower = Program.Ols.ReadPciConfig(0xC6, 0x90);
                }
            }  
			return Decode(lower,pStateIndex);
		}

		public static PStateMsr Decode(uint value, int pstate)
		{
            //uint maxDiv = (uint)K10Manager.MaxCOF();
            uint maxDiv = (uint)K10Manager.CurrCOF();
            uint clk = (uint)Form1.clock;
            bool turbo = K10Manager.IsTurboSupported();

            if (pstate < 8)
            {
                if (Form1.family == 12) //Llano
                {
                    uint cpuDid = (value >> 0) & 0x0F;
                    uint cpuFid = (value >> 4) & 0x1F;
                    uint cpuVid = (value >> 9) & 0x7F;
                    uint enabled = (value >> 63) & 0x1;
                    double Did = 1;

                    switch (cpuDid)
                    {
                        case 0:
                            Did = 1;
                            break;
                        case 1:
                            Did = 1.5;
                            break;
                        case 2:
                            Did = 2;
                            break;
                        case 3:
                            Did = 3;
                            break;
                        case 4:
                            Did = 4;
                            break;
                        case 5:
                            Did = 6;
                            break;
                        case 6:
                            Did = 8;
                            break;
                        case 7:
                            Did = 12;
                            break;
                        case 8:
                            Did = 16;
                            break;
                        default:
                            throw new NotSupportedException("This Divider is not supported");
                    }
                    double Mult = (cpuFid + 16) / Did;
                    var msr = new PStateMsr()
                    {
                        CPUMultNBDivider = Mult,
                        Vid = 1.55 - 0.0125 * cpuVid,
                        Enabled = enabled,
                        PLL = Mult * clk
                    };
                    return msr;
                }
                else if (Form1.family == 14) //Brazos
                {
                    if (pstate <= K10Manager.GetHighestPState())
                    {
                        uint cpuDidLSD = (value >> 0) & 0x0F;
                        uint cpuDidMSD = (value >> 4) & 0x1F;
                        uint cpuVid = (value >> 9) & 0x7F;
                        uint enabled = (value >> 63) & 0x1;

                        double Div = cpuDidMSD + (cpuDidLSD * 0.25) + 1;
                        double DivPLL = cpuDidMSD + (cpuDidLSD * 0.25) + 1;
                        if (maxDiv == 16 && Div < 2) //E-350 seems to restrict PLL frequencies higher than 1.6GHz
                        {
                            DivPLL = 2;
                        }
                        else if (maxDiv == 24 && Div < 4 && !turbo) //C-50 seems to restrict PLL frequencies higher than 1.0GHz
                        {
                            DivPLL = 4;
                        }
                        else if (maxDiv == 24 && Div < 3 && turbo) //C-60 (with turbo seems to restrict PLL frequencies higher than 1.33GHz
                        {
                            DivPLL = 3;
                        }

                        var msr = new PStateMsr()
                        {
                            CPUMultNBDivider = Div,
                            Vid = 1.55 - 0.0125 * cpuVid,
                            Enabled = enabled,
                            PLL = (16 + maxDiv) / DivPLL * clk
                        };
                        return msr;
                    }
                    else
                    {
                        var msr = new PStateMsr()
                        {
                            CPUMultNBDivider = 10,
                            Vid = 0.4,
                            Enabled = 0,
                            PLL = 0
                        };
                        return msr;
                    }
                }
                else //family 16 Kabini
                {
                    if (pstate <= K10Manager.GetHighestPState())
                    {
                        uint cpuDid = (value >> 6) & 0x7;
                        uint cpuFid = value & 0x3F;
                        
                        uint cpuVid = (value >> 10) & 0x7F; //this works for SVI only - 7bits
                        uint enabled = (value >> 63) & 0x1;

                        if (cpuDid > 4){
                            throw new NotSupportedException("This Divider is not supported");
                        }

                        double CoreCOF = (cpuFid + 16) / (Math.Pow(2, cpuDid));
                        var msr = new PStateMsr()
                        {
                            CPUMultNBDivider = CoreCOF,
                            Vid = 1.55 - 0.0125 * cpuVid,
                            Enabled = enabled,
                            PLL = CoreCOF * clk
                        };
                        return msr;
                    }
                    else
                    {
                        var msr = new PStateMsr()
                        {
                            CPUMultNBDivider = 10,
                            Vid = 0.4,
                            Enabled = 0,
                            PLL = 0
                        };
                        return msr;
                    }
                }
            }
            else if (pstate == 8)
            {
                if (Form1.family == 16) //Kabini
                {
                    uint nbvidh = ((value >> 21) & 0x1);
                    //uint nbvidl = ((value >> 10) & 0x7F); //SVI2 - 8bits
                    uint nbvidl = ((value >> 11) & 0x3F);
                    uint nbvid = (nbvidh * 64 + nbvidl);

                    uint nbdid = ((value >> 7) & 0x1);
                    uint nbfid = ((value >> 1) & 0x3F);
                    double nclkdiv = (nbfid + 4) / (Math.Pow(2, nbdid));

                    var msr = new PStateMsr()
                    {
                        CPUMultNBDivider = nclkdiv,
                        Vid = 1.55 - 0.0125 * nbvid,
                        Enabled = 1,
                        PLL = nclkdiv * clk
                    };
                    return msr;
                }
                else
                {
                    uint nclk = ((value >> 20) & 0x7F);
                    uint nbVid = ((value >> 12) & 0x7F);
                    double nclkdiv = 1;
                    //NCLK Div 2-16 ind 0.25 steps / Div 16-32 in 0.5 steps / Div 32-63 in 1.0 steps
                    if (nclk >= 8 && nclk <= 63) nclkdiv = nclk * 0.25;
                    else if (nclk >= 64 && nclk <= 95) nclkdiv = (nclk - 64) * 0.5 - 16;
                    else if (nclk >= 96 && nclk <= 127) nclkdiv = nclk - 64;
                    else nclkdiv = 1;
                    var msr = new PStateMsr()
                    {
                        CPUMultNBDivider = nclkdiv,
                        Vid = 1.55 - 0.0125 * nbVid,
                        Enabled = 1,
                        PLL = (16 + maxDiv) / nclkdiv * clk
                    };
                    return msr;
                }
            }
            else if (pstate == 9)
            {
                if (Form1.family == 16) //Kabini
                {
                    uint nbvidh = ((value >> 21) & 0x1);
                    //uint nbvidl = ((value >> 10) & 0x7F); //SVI2 - 8bits
                    uint nbvidl = ((value >> 11) & 0x3F);
                    uint nbvid = (nbvidh * 64 + nbvidl);

                    uint nbdid = ((value >> 7) & 0x1);
                    uint nbfid = ((value >> 1) & 0x3F);
                    double nclkdiv = (nbfid + 4) / (Math.Pow(2, nbdid));
                    
                    var msr = new PStateMsr()
                    {
                        CPUMultNBDivider = nclkdiv,
                        Vid = 1.55 - 0.0125 * nbvid,
                        Enabled = 1,
                        PLL = nclkdiv * clk
                    };
                    return msr;
                }
                else
                {
                    uint nclk = ((value >> 0) & 0x7F);
                    uint nbVid = ((value >> 8) & 0x7F);
                    double nclkdiv = 1;
                    //NCLK Div 2-16 ind 0.25 steps / Div 16-32 in 0.5 steps / Div 32-63 in 1.0 steps
                    if (nclk >= 8 && nclk <= 63) nclkdiv = nclk * 0.25;
                    else if (nclk >= 64 && nclk <= 95) nclkdiv = (nclk - 64) * 0.5 - 16;
                    else if (nclk >= 96 && nclk <= 127) nclkdiv = nclk - 64;
                    else nclkdiv = 1;
                    var msr = new PStateMsr()
                    {
                        CPUMultNBDivider = nclkdiv,
                        Vid = 1.55 - 0.0125 * nbVid,
                        Enabled = 1,
                        PLL = (16 + maxDiv) / nclkdiv * clk
                    };
                    return msr;
                }
            }
            else
            {
                var msr = new PStateMsr()
                {
                    CPUMultNBDivider = 0,
                    Vid = 1,
                    Enabled = 1,
                    PLL = 1600
                };
                return msr;
            }
		}


		/// <summary>
		/// Encodes the settings into the 32 lower bits of a MSR.
		/// </summary>
		public uint Encode(int pstate)
		{
            if (pstate < 8)
            {
                if (Form1.family == 12) // Llano
                {
                    if (CPUMultNBDivider < 4 || CPUMultNBDivider > 48) throw new ArgumentOutOfRangeException("CPUMultNBDivider");
                    if (Vid <= 0 || Vid > 1.55) throw new ArgumentOutOfRangeException("Vid");
                    
                    uint cpuFid, cpuDid;
                    if (CPUMultNBDivider >= 19)
                    {
                        cpuFid = (uint)Math.Abs(CPUMultNBDivider - 16);
                        cpuDid = 0; //Div 1
                    }
                    else if (CPUMultNBDivider == 18) //PState 4
                    {
                        cpuFid = 27 - 16;
                        cpuDid = 1; //Div 1.5
                    }
                    else if (CPUMultNBDivider == 17)
                    {
                        cpuFid = 34 - 16;
                        cpuDid = 2; //Div 2
                    }
                    else if (CPUMultNBDivider == 16)
                    {
                        cpuFid = 32 - 16;
                        cpuDid = 2; //Div 2
                    }
                    else if (CPUMultNBDivider == 15)
                    {
                        cpuFid = 30 - 16;
                        cpuDid = 2; //Div 2
                    }
                    else if (CPUMultNBDivider == 14) //PState 5
                    {
                        cpuFid = 28 - 16;
                        cpuDid = 2; //Div 2
                    }
                    else if (CPUMultNBDivider == 13)
                    {
                        cpuFid = 26 - 16;
                        cpuDid = 2; //Div 2
                    }
                    else if (CPUMultNBDivider == 12)
                    {
                        cpuFid = 24 - 16;
                        cpuDid = 2; //Div 2
                    }
                    else if (CPUMultNBDivider == 11) //PState 6
                    {
                        cpuFid = 22 - 16;
                        cpuDid = 2; //Div 2
                    }
                    else if (CPUMultNBDivider == 10)
                    {
                        cpuFid = 30 - 16;
                        cpuDid = 3; //Div 3
                    }
                    else if (CPUMultNBDivider == 9)
                    {
                        cpuFid = 27 - 16;
                        cpuDid = 3; //Div 3
                    }
                    else if (CPUMultNBDivider == 8) //PState 7
                    {
                        cpuFid = 24 - 16;
                        cpuDid = 3; //Div 3
                    }
                    else if (CPUMultNBDivider == 7)
                    {
                        cpuFid = 21 - 16;
                        cpuDid = 3; //Div 3
                    }
                    else if (CPUMultNBDivider == 6)
                    {
                        cpuFid = 24 - 16;
                        cpuDid = 4; //Div 4
                    }
                    else if (CPUMultNBDivider == 5)
                    {
                        cpuFid = 20 - 16;
                        cpuDid = 4; //Div 4
                    }
                    else if (CPUMultNBDivider == 4)
                    {
                        cpuFid = 24 - 16;
                        cpuDid = 5; //Div 6
                    }
                    else
                    {
                        cpuFid = 24 - 16;
                        cpuDid = 3; //Div 3
                    }
                    uint cpuVid = (uint)Math.Round((1.55 - Vid) / 0.0125);
                    return (cpuVid << 9) | (cpuFid << 4) | cpuDid;
                
                } 
                else if (Form1.family == 14) // Brazos
                {

                    if (CPUMultNBDivider < 1 || CPUMultNBDivider > 31.5) throw new ArgumentOutOfRangeException("CPUMultNBDivider");
                    if (Vid <= 0 || Vid > 1.55) throw new ArgumentOutOfRangeException("Vid");
                    
                    uint cpuDidMSD, cpuDidLSD;
                    cpuDidMSD = (uint)Math.Abs(CPUMultNBDivider - 1);

                    double temp1 = (double)cpuDidMSD;
                    double temp2 = CPUMultNBDivider - 1 - temp1;
                    cpuDidLSD = (uint)Math.Abs(temp2 / 0.25);

                    uint cpuVid = (uint)Math.Round((1.55 - Vid) / 0.0125);
                    return (cpuVid << 9) | (cpuDidMSD << 4) | cpuDidLSD;
                } else { // Kabini

                    if (CPUMultNBDivider < 4 || CPUMultNBDivider > 40) throw new ArgumentOutOfRangeException("CPUMultNBDivider");
                    if (Vid <= 0 || Vid > 1.55) throw new ArgumentOutOfRangeException("Vid");

                    uint cpuFid, cpuDid;
                    if (CPUMultNBDivider >= 8)
                    {
                        cpuFid = (uint)Math.Abs(CPUMultNBDivider * 2 - 16);
                        cpuDid = 1; //Div 2
                    }
                    else if (CPUMultNBDivider >= 4 && CPUMultNBDivider < 8) //PState 4
                    {
                        cpuFid = (uint)Math.Abs(CPUMultNBDivider * 8 - 16); 
                        cpuDid = 3; //Div 8
                    }
                    else
                    {
                        cpuFid = 0;
                        cpuDid = 0;
                    }
                    uint cpuVid = (uint)Math.Round((1.55 - Vid) / 0.0125);
                    return (cpuVid << 9) | (cpuDid << 6) | cpuFid;
                }
                
            }
            else if (pstate == 8)
            {
                //K10Manager.SetBIOSBusSpeed((uint)CLK);
                uint nbVid = (uint)Math.Round((1.55 - Vid) / 0.0125);
                //CPUMultNBDivider
                //NCLK Div 2-16 ind 0.25 steps / Div 16-32 in 0.5 steps / Div 32-63 in 1.0 steps
                uint nclk = (uint)Math.Round(CPUMultNBDivider * 4);

                return (nclk << 20) | (nbVid << 12);
            }
            else if (pstate == 9)
            {
                //K10Manager.SetBIOSBusSpeed((uint)CLK);
                uint nbVid = (uint)Math.Round((1.55 - Vid) / 0.0125);
                //CPUMultNBDivider
                //NCLK Div 2-16 ind 0.25 steps / Div 16-32 in 0.5 steps / Div 32-63 in 1.0 steps
                uint nclk = (uint)Math.Round(CPUMultNBDivider * 4);

                return (nbVid << 8) | (nclk << 0);
            }            
            else
            {
                return 0;
            }
		}
	}
}
