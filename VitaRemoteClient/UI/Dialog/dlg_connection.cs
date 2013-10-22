using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;
using System.Threading;

namespace dialog
{
    public partial class DLG_CONNECTION : Dialog
    {
        public DLG_CONNECTION()
            : base(null, null)
        {
            InitializeWidget();
        }
		
		private void  Connect (object sender, TouchEventArgs e)
        {
			VitaRemoteClient.AppMain.client.Port = Convert.ToUInt16(txtPort.Text.ToString());
			VitaRemoteClient.AppMain.client.RemoteHost = txtIp.Text;
			VitaRemoteClient.AppMain.client.Connect();
			this.Hide();
			this.Visible =false;
        }
    }
}
