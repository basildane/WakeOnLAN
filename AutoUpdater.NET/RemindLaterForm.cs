/*
 *   WakeOnLAN - Wake On LAN
 *    Copyright (C) 2004-2019 Aquila Technology, LLC. <webmaster@aquilatech.com>
 *
 *    This file is part of WakeOnLAN.
 *
 *    WakeOnLAN is free software: you can redistribute it and/or modify
 *    it under the terms of the GNU General Public License as published by
 *    the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *    WakeOnLAN is distributed in the hope that it will be useful,
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *    GNU General Public License for more details.
 *
 *    You should have received a copy of the GNU General Public License
 *    along with WakeOnLAN.  If not, see <http://www.gnu.org/licenses/>.
 */

/*
 *    This module originated from https://autoupdaterdotnet.codeplex.com/
 */

using System;
using System.Windows.Forms;

namespace AutoUpdaterDotNET
{
    internal partial class RemindLaterForm : Form
    {
        public AutoUpdater.RemindLaterFormat RemindLaterFormat { get; private set; }

        public int RemindLaterAt { get; private set; }

        public RemindLaterForm()
        {
            InitializeComponent();
        }

        private void RemindLaterFormLoad(object sender, EventArgs e)
        {
            comboBoxRemindLater.SelectedIndex = 0;
            radioButtonYes.Checked = true;
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (radioButtonYes.Checked)
            {
                switch (comboBoxRemindLater.SelectedIndex)
                {
                    case 0:
                        RemindLaterFormat = AutoUpdater.RemindLaterFormat.Minutes;
                        RemindLaterAt = 30;
                        break;
                    case 1:
                        RemindLaterFormat = AutoUpdater.RemindLaterFormat.Hours;
                        RemindLaterAt = 12;
                        break;
                    case 2:
                        RemindLaterFormat = AutoUpdater.RemindLaterFormat.Days;
                        RemindLaterAt = 1;
                        break;
                    case 3:
                        RemindLaterFormat = AutoUpdater.RemindLaterFormat.Days;
                        RemindLaterAt = 2;
                        break;
                    case 4:
                        RemindLaterFormat = AutoUpdater.RemindLaterFormat.Days;
                        RemindLaterAt = 4;
                        break;
                    case 5:
                        RemindLaterFormat = AutoUpdater.RemindLaterFormat.Days;
                        RemindLaterAt = 8;
                        break;
                    case 6:
                        RemindLaterFormat = AutoUpdater.RemindLaterFormat.Days;
                        RemindLaterAt = 10;
                        break;
                }
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Abort;
            }
        }

        private void RadioButtonYesCheckedChanged(object sender, EventArgs e)
        {
            comboBoxRemindLater.Enabled = radioButtonYes.Checked;
        }
    }
}
