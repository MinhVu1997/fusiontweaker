﻿using System;
using System.Windows.Forms;
using System.ServiceProcess;

namespace FusionTweaker
{
	public partial class ServiceDialog : Form
	{
		private PState[] _pStates = new PState[10];
        //Brazos merge line from BT
		private static int _maxPstate = K10Manager.GetHighestPState();


		/// <summary>
		/// Gets a value indicating whether the service has been (re)started.
		/// </summary>
		public bool Applied { get; private set; }


		public ServiceDialog(System.Drawing.Icon icon)
		{
			InitializeComponent();

			this.Icon = icon;

			makePermanentCheckBox.CheckedChanged += (s, e) => updateButton.Enabled = makePermanentCheckBox.Checked;
			turboCheckBox.CheckedChanged += (s, e) =>
			{
				if (turboCheckBox.Checked)
				{
					enableCustomCnQCheckBox.Checked = false;
					enableCustomCnQCheckBox.Enabled = false;
				}
				else
					enableCustomCnQCheckBox.Enabled = true;
			};
			enableCustomCnQCheckBox.CheckedChanged += (s, e) => tabControl1.Enabled = enableCustomCnQCheckBox.Checked;

			// select the current P-state settings as default settings
			updateButton_Click(updateButton, EventArgs.Empty);

			turboCheckBox.Enabled = K10Manager.IsTurboSupported();
			turboCheckBox.Checked = K10Manager.IsTurboEnabled();
			//Brazos merge line from BT
    		//turboCheckBox.Checked = K10Manager.IsTurboSupported();
	
			balancedProfileControl.LoadFromRegistry();
			highPerformanceProfileControl.LoadFromRegistry();
			powerSaverProfileControl.LoadFromRegistry();

			var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\FusionTweaker");
			if (key == null)
				return;

			//Brazos merge ToDo line from BT , which sets only active PStates
			//for (int i = 0; i < (_maxPstate + 1); i++)
			for (int i = 0; i < 10; i++)
			{
				string text = (string)key.GetValue("P" + i);
				_pStates[i] = PState.Decode(text,i);
			}
            //Brazos merge ToDo line from BT , which sets only active PStates
			/*for (int i = 3; i < 5; i++)
            {
                string text = (string)key.GetValue("P" + i);
                _pStates[i] = PState.Decode(text, i);
            }*/

			RefreshPStatesLabel();

			makePermanentCheckBox.Checked = ((int)key.GetValue("EnableCustomPStates", 0) != 0);

			//Brazos merge next line only in FT
			turboCheckBox.Checked = (K10Manager.IsTurboEnabled());
			
			enableCustomCnQCheckBox.Checked = ((int)key.GetValue("EnableCustomCnQ", 0) != 0);

			key.Close();
		}


		private void RefreshPStatesLabel()
		{
			var sb = new System.Text.StringBuilder();

			//Brazos merge BT
			/*for (int i = 0; i < (_maxPstate + 1); i++)
			{
				if (_pStates[i] == null)
					continue;

				if (sb.Length > 0)
					sb.AppendLine();

				sb.AppendFormat("P{0}: {1}", i, _pStates[i].ToString());
			}
            for (int i = 3; i < 5; i++)
            {
                if (_pStates[i] == null)
                    continue;

                if (sb.Length > 0)
                    sb.AppendLine();

                sb.AppendFormat("P{0}: {1}", i, _pStates[i].ToString());
            }*/			

			for (int i = 0; i < 10; i++)
			{
				if (_pStates[i] == null)
					continue;

				if (sb.Length > 0)
					sb.AppendLine();

				sb.AppendFormat("P{0}: {1}", i, _pStates[i].ToString());
			}

			pStatesLabel.Text = sb.ToString();
		}


		private void updateButton_Click(object sender, EventArgs e)
		{
			//Brazos merge next line from BT
			//for (int i = 0; i < 5; i++)
			
			for (int i = 0; i < 10; i++)
			{
				_pStates[i] = PState.Load(i);

				// disable the current P-state and all following ones in case the
				// first core's CPU VID is > than the previous P-state's
				//Brazos merge next line from BT
				//if ((i > 0 && _pStates[i].Msrs[0].Vid > _pStates[i - 1].Msrs[0].Vid) && (i < 3)) //ignore Vids from NB in comprison
				if ((i > 0 && _pStates[i].Msrs[0].Vid > _pStates[i - 1].Msrs[0].Vid) && (i < 8)) //ignore Vids from NB in comparison
				{
					//Brazos merge next line from BT
					//for (int j = i; j < 5; j++)
					for (int j = i; j < 8; j++)
						_pStates[j] = null;

					break;
				}
			}

			RefreshPStatesLabel();
		}

		private void applyButton_Click(object sender, EventArgs e)
		{
			var key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\FusionTweaker");

			key.SetValue("EnableCustomPStates", (makePermanentCheckBox.Checked ? 1 : 0));

			if (makePermanentCheckBox.Checked)
			{
				
				//Brazos merge lines from BT
				/*
				for (int i = 0; i < (K10Manager.GetHighestPState() + 1); i++) //this is the part, where the CPU PStates are handled
				{
					string valueName = "P" + i;

					if (_pStates[i] != null)
						key.SetValue(valueName, _pStates[i].Encode(i));
					else
						key.DeleteValue(valueName, false);
				}
                for (int i = 3; i < 5; i++) //this is the part for the NB PStates
				{
					string valueName = "P" + i;

					if (_pStates[i] != null)
						key.SetValue(valueName, _pStates[i].Encode(i));
					else
						key.DeleteValue(valueName, false);
				}
				*/
				
				for (int i = 0; i < 10; i++)
				{
					string valueName = "P" + i;

					if (_pStates[i] != null)
						key.SetValue(valueName, _pStates[i].Encode(i));
					else
						key.DeleteValue(valueName, false);
				}
			}
			
			//Brazos merge next if only in FT
			//ToDo check, if that fits Brazos
            if (turboCheckBox.Checked)
            {
                K10Manager.SetTurbo(true);
            }
            else
            {
                K10Manager.SetTurbo(false);
            }
            
			key.SetValue("EnableCustomCnQ", (enableCustomCnQCheckBox.Checked ? 1 : 0));
			key.Close();

			if (enableCustomCnQCheckBox.Checked)
			{
				balancedProfileControl.Save();
				highPerformanceProfileControl.Save();
				powerSaverProfileControl.Save();
			}

			try
			{
				serviceController1.Refresh();
				var status = serviceController1.Status;
				if (status != ServiceControllerStatus.Stopped && status != ServiceControllerStatus.StopPending)
					serviceController1.Stop();

				Cursor = Cursors.WaitCursor;
				serviceController1.WaitForStatus(ServiceControllerStatus.Stopped);
				serviceController1.Start();
				Cursor = Cursors.Default;

				Applied = true;
			}
			catch (Exception exception)
			{
				Cursor = Cursors.Default;

				MessageBox.Show("The service could not be (re)started:\n\n" + exception.Message,
					"FusionTweaker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

        private void resetButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete all your customized settings?\n"
                + "If you want that:\n1. Click OK.\n2. Close the application without hitting \"Apply\"\n3. Restart your system.", "Reset PStates", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                var key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\FusionTweaker");
                if (key == null)
                    return;
                //Brazos merge next line from BT
				//for (int i = 0; i < 5; i++)
				for (int i = 0; i < 10; i++)
                {
                    string valueName = "P" + i;
                    key.DeleteValue(valueName, false);
                }
                key.SetValue("EnableCustomPStates", 0);
                key.Close();
            }
        }
	}
}
