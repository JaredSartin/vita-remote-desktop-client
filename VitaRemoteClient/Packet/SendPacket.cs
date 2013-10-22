using System;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;


namespace VitaRemoteClient
{
	public class SendPacket
	{
		private static TCPConnection socket;
		
		public static void Init(TCPConnection tcpSocket)
		{
			socket = tcpSocket;
		}
		
		public static void sendLeftMouseClick(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 101; //tap
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		
		public static void sendLeftMouseDoubleClick(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 102; //tap
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		
		public static void sendDrag(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 103; //tap
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		
		public static void sendMouseMove(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 104; //tap
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		
		public static void sendRightMouseClick(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 105; //tap
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
			
		}
		
		public static void sendRightMouseDoubleClick(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 106; //tap
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
			
		}
		
		public static void sendLeftMouseDown(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 107; //tap
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
			
		}
		
		public static void sendLeftMouseUp(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 108; //tap
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
			
		}
		
		public static void sendGamePadInput(byte[] dataInput)
		{
			Packet msg = new Packet();
			msg.ID = 301;
			msg.Data = dataInput;
			socket.send(msg);
		}
		
		public static void sendReady()
		{
			Packet msg = new Packet();
			msg.ID = 401;
			msg.Data = new byte[]{255,255};
			socket.send(msg);
		}
		
		public static void sendSensorData(int avX, int avY, int avZ, int aX, int aY, int aZ)
		{
			byte[] data = new byte[12];
			
			Array.Copy(BitConverter.GetBytes(avX),0,data,0,2);
			Array.Copy(BitConverter.GetBytes(avY),0,data,2,2);
			Array.Copy(BitConverter.GetBytes(avZ),0,data,4,2);
			Array.Copy(BitConverter.GetBytes(aX),0,data,6,2);
			Array.Copy(BitConverter.GetBytes(aY),0,data,8,2);
			Array.Copy(BitConverter.GetBytes(aZ),0,data,10,2);
			
			Packet msg = new Packet();
			msg.ID = 302;
			msg.Data = data;
			socket.send(msg);
		}
		
		public static byte[] coordsToByte(int x, int y)
		{
			byte[] data = new byte[4];
			byte[] _x = BitConverter.GetBytes(x);
			byte[] _y = BitConverter.GetBytes(y);
			Array.Copy(_x ,0,data,0,2);
			Array.Copy(_y,0,data,2,2);
			return data;
		}
	}
}

