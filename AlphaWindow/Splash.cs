using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AlphaWindow
{
	// This only works with Windows 2000/XP
	public class Splash : Form
    {
        Timer timer = new Timer();

		public Splash(Bitmap bitmap)
		{
			// Window settings
			//this.TopMost = true;
			this.ShowInTaskbar = false;
			this.Size = bitmap.Size;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Show();				// Must be called before setting bitmap


            Graphics g = Graphics.FromImage(bitmap);

            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString("WakeOnLAN", new Font("Microsoft Sans Serif", 28, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black, new Point(280,100), sf);
            g.Flush();

            this.SelectBitmap(bitmap);

            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 4000;
            timer.Start();
		}

        private void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            timer.Stop();
            this.Close();
        }

		// Sets the current bitmap
		public void SelectBitmap(Bitmap bitmap) 
		{
			// Does this bitmap contain an alpha channel?
			if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
			{
				throw new ApplicationException("The bitmap must be 32bpp with alpha-channel.");
			}

			// Get device contexts
			IntPtr screenDc = APIHelp.GetDC(IntPtr.Zero);
			IntPtr memDc = APIHelp.CreateCompatibleDC(screenDc);
			IntPtr hBitmap = IntPtr.Zero;
			IntPtr hOldBitmap = IntPtr.Zero;

			try 
			{
				// Get handle to the new bitmap and select it into the current device context
				hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
				hOldBitmap = APIHelp.SelectObject(memDc, hBitmap);

				// Set parameters for layered window update
				APIHelp.Size newSize = new APIHelp.Size(bitmap.Width, bitmap.Height);	// Size window to match bitmap
				APIHelp.Point sourceLocation = new APIHelp.Point(0, 0);
				APIHelp.Point newLocation = new APIHelp.Point(this.Left, this.Top);		// Same as this window
				APIHelp.BLENDFUNCTION blend = new APIHelp.BLENDFUNCTION();
				blend.BlendOp             = APIHelp.AC_SRC_OVER;						// Only works with a 32bpp bitmap
				blend.BlendFlags          = 0;											// Always 0
				blend.SourceConstantAlpha = 255;										// Set to 255 for per-pixel alpha values
				blend.AlphaFormat         = APIHelp.AC_SRC_ALPHA;						// Only works when the bitmap contains an alpha channel

				// Update the window
				APIHelp.UpdateLayeredWindow(Handle, screenDc, ref newLocation, ref newSize,
					memDc, ref sourceLocation, 0, ref blend, APIHelp.ULW_ALPHA);
			}
			finally 
			{
				// Release device context
				APIHelp.ReleaseDC(IntPtr.Zero, screenDc);
				if (hBitmap != IntPtr.Zero) 
				{
					APIHelp.SelectObject(memDc, hOldBitmap);
					APIHelp.DeleteObject(hBitmap);										// Remove bitmap resources
				}
				APIHelp.DeleteDC(memDc);
			}
		}

		protected override CreateParams CreateParams	
		{
			get 
			{
				// Add the layered extended style (WS_EX_LAYERED) to this window
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= APIHelp.WS_EX_LAYERED;
				return createParams;
			}
		}

		// Let Windows drag this window for us (thinks its hitting the title bar of the window)
		protected override void WndProc(ref Message message) 
		{
			if (message.Msg == APIHelp.WM_NCHITTEST) 
			{
				// Tell Windows that the user is on the title bar (caption)
				message.Result= (IntPtr)APIHelp.HTCAPTION;
			}
			else
			{
				base.WndProc(ref message);
			}
		}

	}
	
	// Class to assist with Win32 API calls
	class APIHelp 
	{
		// Required constants
		public const Int32	WS_EX_LAYERED	= 0x80000;
		public const Int32	HTCAPTION		= 0x02;
		public const Int32	WM_NCHITTEST	= 0x84;
		public const Int32	ULW_ALPHA		= 0x02;
		public const byte	AC_SRC_OVER		= 0x00;
		public const byte	AC_SRC_ALPHA	= 0x01;

		public enum Bool 
		{
			False = 0,
			True = 1
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Point 
		{
			public Int32 x;
			public Int32 y;

			public Point(Int32 x, Int32 y) { this.x = x; this.y = y; }
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Size 
		{
			public Int32 cx;
			public Int32 cy;

			public Size(Int32 cx, Int32 cy) { this.cx = cx; this.cy = cy; }
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		struct ARGB 
		{
			public byte Blue;
			public byte Green;
			public byte Red;
			public byte Alpha;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct BLENDFUNCTION 
		{
			public byte BlendOp;
			public byte BlendFlags;
			public byte SourceConstantAlpha;
			public byte AlphaFormat;
		}

		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("user32.dll", ExactSpelling = true)]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern Bool DeleteDC(IntPtr hdc);

		[DllImport("gdi32.dll", ExactSpelling = true)]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern Bool DeleteObject(IntPtr hObject);
	}
}
