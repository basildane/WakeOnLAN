/*
 *   WakeOnLAN - Wake On LAN
 *    Copyright (C) 2004-2017 Aquila Technology, LLC. <webmaster@aquilatech.com>
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

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace AlphaWindow
{
	public class Splash : Form
	{
        private static Splash ms_frmSplash = null;
        private static Bitmap _bitmap;
        private static String _title;
        private static String _version;
        private static String _copyright;

        static public void ShowSplash(Bitmap bitmap, String title, String version, String copyright)
	    {
	        _bitmap = bitmap;
	        _title = title;
	        _version = version;
	        _copyright = copyright;

            // Make sure it's only launched once.
            if (ms_frmSplash != null)
                return;

            Thread msOThread = new Thread(ShowForm) {IsBackground = true};
            msOThread.SetApartmentState(ApartmentState.STA);
            msOThread.Start();
            while (ms_frmSplash == null || ms_frmSplash.IsHandleCreated == false)
            {
                Thread.Sleep(50);
            }
        }

	    private static void ShowForm()
	    {
            ShowIt();
            for (int i = 1; i <= 40; i++)
            {
                Thread.Sleep(100);
            }
        }

        private static void ShowIt()
        {
	        ms_frmSplash = new Splash
            {
                ShowInTaskbar = false,
                Size = _bitmap.Size,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true
            };

			// Window settings
            ms_frmSplash.Show();				// Must be called before setting bitmap

            Graphics g = Graphics.FromImage(_bitmap);

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(_title, new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black, new Point(280, 130), sf);
            g.DrawString(_version, new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black, new Point(80, 220));
            g.DrawString(_copyright, new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.Black, new Point(80, 250));
            g.Flush();

            SelectBitmap(_bitmap);
		}

		// Sets the current bitmap
		private static void SelectBitmap(Bitmap bitmap) 
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
                APIHelp.Point newLocation = new APIHelp.Point(ms_frmSplash.Left - 22, ms_frmSplash.Top);		    // Same as this window, offset by 22 to compensate
                                                                                        // for transparent border
				APIHelp.BLENDFUNCTION blend = new APIHelp.BLENDFUNCTION
				{
				    BlendOp = APIHelp.AC_SRC_OVER,
				    BlendFlags = 0,
				    SourceConstantAlpha = 255,
				    AlphaFormat = APIHelp.AC_SRC_ALPHA
				};

			    // Update the window
                APIHelp.UpdateLayeredWindow(ms_frmSplash.Handle, screenDc, ref newLocation, ref newSize,
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

		// Let Windows drag this window for us
	    protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                    //TODO: fix this
                case APIHelp.WM_LBUTTONUP:
                    // let user close splashscreen by clicking
                    message.Msg = APIHelp.WM_CLOSE;
                    break;

                //case APIHelp.WM_NCHITTEST:
                //    // Tell Windows that the user is on the title bar (caption), this allows users to drag the window
                //    message.Result = (IntPtr)APIHelp.HTCAPTION;
                //    break;
            }

            base.WndProc(ref message);
        }

	}
	
	// Class to assist with Win32 API calls
	class APIHelp 
	{
		// Required constants
		public const Int32	WS_EX_LAYERED	= 0x80000;
        public const Int32  WM_LBUTTONUP    = 0x202;
        public const Int32  WM_CLOSE        = 0x0010;
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
