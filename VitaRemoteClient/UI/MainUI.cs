using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;
using Sce.PlayStation.Core.Graphics;

namespace VitaRemoteClient 
{
	public partial class MainUI : Scene
	{
		public MainUI()
		{
			InitializeWidget();
		}
		
		public void updateLabel(string str)
		{
			if(lblOutput.Text != str)
				lblOutput.Text = str;
		}
		
		public void updateImage(Texture2D txt, Texture2D txt2)
		{
			if(txt != null && txt2 != null)
			{
				imgDesktop.Image = new ImageAsset(txt);
				imgDesktop2.Image = new ImageAsset(txt2);
			}
		}
		
		void  Tap (object sender, TapEventArgs e)
		{
		 	SendPacket.sendLeftMouseClick((int)e.LocalPosition.X, (int)e.LocalPosition.Y);	
		}
		
		void DoubleTap (object sender, DoubleTapEventArgs e)
		{
			SendPacket.sendLeftMouseDoubleClick((int)e.LocalPosition.X, (int)e.LocalPosition.Y);	
		}
		
		void  Drag (object sender, DragEventArgs e)
		{
			if(Frame.TC == 2){
				if(e.Distance.X != 0 || e.Distance.Y != 0)
		 			SendPacket.sendDrag((int)e.Distance.X,(int)e.Distance.Y);
			}
			if(Frame.TC == 1){
				if(e.Distance.X != 0 || e.Distance.Y != 0)
					SendPacket.sendMouseMove((int)e.LocalPosition.X,(int)e.LocalPosition.Y);
			}
		}
		
		 void  LongPress (object sender, LongPressEventArgs e)
		 {
			SendPacket.sendRightMouseClick((int)e.LocalPosition.X,(int)e.LocalPosition.Y);		 	
		 }
		
		  void  dragStart (object sender, DragEventArgs e)
		 {
			if(Frame.TC == 1)
		 		SendPacket.sendLeftMouseDown((int)e.LocalPosition.X,(int)e.LocalPosition.Y);
		 }
		
		 void  dragEnd (object sender, DragEventArgs e)
		 {
			if(Frame.TC == 1)
				SendPacket.sendLeftMouseUp((int)e.LocalPosition.X,(int)e.LocalPosition.Y);
		 }



		
	}
		
}