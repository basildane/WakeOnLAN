//
// Copyright © 2002 Rui Godinho Lopes <rui@ruilopes.com>
// All rights reserved.
//
// This source file(s) may be redistributed unmodified by any means
// PROVIDING they are not sold for profit without the authors expressed
// written consent, and providing that this notice and the authors name
// and all copyright notices remain intact.
//
// Any use of the software in source or binary forms, with or without
// modification, must include, in the user documentation ("About" box and
// printed documentation) and internal comments to the code, notices to
// the end user as follows:
//
// "Portions Copyright © 2002 Rui Godinho Lopes"
//
// An email letting me know that you are using it would be nice as well.
// That's not much to ask considering the amount of work that went into
// this.
//
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED. USE IT AT YOUT OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;


// a static class to expose needed win32 gdi functions.
class Win32 {

	public enum Bool {
		False= 0,
		True
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct Point {
		public Int32 x;
		public Int32 y;

		public Point(Int32 x, Int32 y) { this.x= x; this.y= y; }
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Size {
		public Int32 cx;
		public Int32 cy;

		public Size(Int32 cx, Int32 cy) { this.cx= cx; this.cy= cy; }
	}

	[StructLayout(LayoutKind.Sequential, Pack=1)]
	struct ARGB {
		public byte Blue;
		public byte Green;
		public byte Red;
		public byte Alpha;
	}

	[StructLayout(LayoutKind.Sequential, Pack=1)]
	public struct BLENDFUNCTION {
		public byte BlendOp;
		public byte BlendFlags;
		public byte SourceConstantAlpha;
		public byte AlphaFormat;
	}


	public const Int32 ULW_COLORKEY = 0x00000001;
	public const Int32 ULW_ALPHA    = 0x00000002;
	public const Int32 ULW_OPAQUE   = 0x00000004;

	public const byte AC_SRC_OVER  = 0x00;
	public const byte AC_SRC_ALPHA = 0x01;


	[DllImport("user32.dll", ExactSpelling=true, SetLastError=true)]
	public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

	[DllImport("user32.dll", ExactSpelling=true, SetLastError=true)]
	public static extern IntPtr GetDC(IntPtr hWnd);

	[DllImport("user32.dll", ExactSpelling=true)]
	public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

	[DllImport("gdi32.dll", ExactSpelling=true, SetLastError=true)]
	public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

	[DllImport("gdi32.dll", ExactSpelling=true, SetLastError=true)]
	public static extern Bool DeleteDC(IntPtr hdc);

	[DllImport("gdi32.dll", ExactSpelling=true)]
	public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

	[DllImport("gdi32.dll", ExactSpelling=true, SetLastError=true)]
	public static extern Bool DeleteObject(IntPtr hObject);
}


/// <para>PerPixel forms should derive from this base class</para>
/// <author><name>Rui Godinho Lopes</name><email>rui@ruilopes.com</email></author>
class PerPixelAlphaForm : Form {

	/// <para>Changes the current bitmap.</para>
	public void SetBitmap(Bitmap bitmap) {
		SetBitmap(bitmap, 255);
	}

	/// <para>Changes the current bitmap with a custom opacity level.  Here is where all happens!</para>
	public void SetBitmap(Bitmap bitmap, byte opacity) {
		if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
			throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

		// The ideia of this is very simple,
		// 1. Create a compatible DC with screen;
		// 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
		// 3. Call the UpdateLayeredWindow.

		IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
		IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
		IntPtr hBitmap = IntPtr.Zero;
		IntPtr oldBitmap = IntPtr.Zero;

		try {
			hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
			oldBitmap = Win32.SelectObject(memDc, hBitmap);

			Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
			Win32.Point pointSource = new Win32.Point(0, 0);
			Win32.Point topPos = new Win32.Point(Left, Top);
			Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
			blend.BlendOp             = Win32.AC_SRC_OVER;
			blend.BlendFlags          = 0;
			blend.SourceConstantAlpha = opacity;
			blend.AlphaFormat         = Win32.AC_SRC_ALPHA;

			Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
		}
		finally {
			Win32.ReleaseDC(IntPtr.Zero, screenDc);
			if (hBitmap != IntPtr.Zero) {
				Win32.SelectObject(memDc, oldBitmap);
				//Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win32 GDI and it's working fine without any resource leak.
				Win32.DeleteObject(hBitmap);
			}
			Win32.DeleteDC(memDc);
		}
	}

	protected override CreateParams CreateParams	{
		get {
			CreateParams cp = base.CreateParams;
			cp.ExStyle |= 0x00080000; // This form has to have the WS_EX_LAYERED extended style
			return cp;
		}
	}
}







/// <para>Our test form for this sample application.  The bitmap will be displayed in this window.</para>
class MyPerPixelAlphaForm : PerPixelAlphaForm {

	public MyPerPixelAlphaForm() {
		Text = "PerPixelAlpha Layered Form";
		TopMost = true;
		FormBorderStyle = FormBorderStyle.FixedDialog;
		MinimizeBox = false;
		MaximizeBox = false;
		ControlBox = false;
	}

	// Let Windows drag this window for us
	protected override void WndProc(ref Message m) {
		if (m.Msg == 0x0084 /*WM_NCHITTEST*/) {
			m.Result= (IntPtr)2;	// HTCLIENT
			return;
		}
		base.WndProc(ref m);
	}
}



///<para>The "controller" dialog box.</para>
class MyForm : Form {

	public MyForm() {
		Font= new Font("tahoma", 8);
		Text= "perpixelalpha# - Sample application";
		FormBorderStyle = FormBorderStyle.FixedDialog;
		MinimizeBox = false;
		MaximizeBox = false;
		ClientSize = new Size(350, 160);
		StartPosition = FormStartPosition.CenterScreen;

		AllowDrop = true; // Because we want to be a drop target of windows explorer files.

		InitializeComponent();
	}

	///<para>Constructs and initializes all child controls of this dialog box.</para>
	private void InitializeComponent() {

		// Label with to display current opacity level
		Label Label1 = new Label();
		Label1.AutoSize = true;
		Label1.Location = new System.Drawing.Point(4, 8);
		Label1.Text = "1. Drag&&Drop an image file from windows explorer into this window.";
		Controls.Add(Label1);

		Label Label2 = new Label();
		Label2.AutoSize = true;
		Label2.Location = new System.Drawing.Point(4, 38);
		Label2.Text = "2. Play with the opacity level [0..255]:";
		Controls.Add(Label2);

		// Label with to display current opacity level
		LabelValue = new Label();
		LabelValue.AutoSize = true;
		LabelValue.Location = new System.Drawing.Point(195, 38);
		LabelValue.Text = "255";

		Controls.Add(LabelValue);



		// Trackbar to change opacity level
		Track = new TrackBar();

		Track.Location = new System.Drawing.Point(18, 58);
		Track.Size = new System.Drawing.Size(310, 0);
		Track.BeginInit();
			Track.Maximum = 255;
			Track.TickFrequency = 5;
			Track.TickStyle = TickStyle.TopLeft;
			Track.Value = 255;
		Track.EndInit();

		Track.ValueChanged += new EventHandler(Track_ValueChanged);

		Controls.Add(Track);

		
		Label Label3 = new Label();
		Label3.AutoSize = true;
		Label3.Location = new System.Drawing.Point(4, 108);
		Label3.Text = "3. Drag the layered window arround you desktop!";
		Controls.Add(Label3);


		// Label with two links to me! :)
		LinkLabel Link = new LinkLabel();

		Link.Location = new System.Drawing.Point(4, 140);
		Link.Size = new System.Drawing.Size(250, 80);
		Link.Text = "by Rui Lopes <rui@ruilopes.com>";
		Link.Links.Add(3, 9,  "http://www.ruilopes.com");
		Link.Links.Add(14, 16, "mailto:rui@ruilopes.com");

		Link.LinkClicked += new LinkLabelLinkClickedEventHandler(Link_LinkClicked);

		Controls.Add(Link);


		// TestForm will containt the per-pixel-alpha dib
		TestForm = new MyPerPixelAlphaForm();
		TestForm.Show();
	}

	///<para>Frees our bitmap.</para>
	protected override void Dispose(bool disposing) {
		try {
			if (disposing && bitmap != null) {
				bitmap.Dispose();
				bitmap = null;
			}
		} finally {
			base.Dispose(disposing);
		}
	}

	///<para>Accepts only Drops of windows explorer files.</para>
	protected override void OnDragEnter(DragEventArgs e) {
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
			e.Effect = DragDropEffects.Copy;
		base.OnDragEnter(e);
	}

	///<para>Just loads the dropped file from windows explorer.</para>
	protected override void OnDragDrop(DragEventArgs e) {
		string[] files= e.Data.GetData(DataFormats.FileDrop) as string[];
		if (files != null) {
			if (files.Length == 1)
				SetPerPixelBitmapFilename(files[0]);
			else
				MessageBox.Show(this, "Please, drop only one image file.", "Too many files dropped", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
		base.OnDragDrop(e);
	}

	///<para>Just load a image file and display it on our test form.</para>
	private void SetPerPixelBitmapFilename(string fileName) {
		Bitmap newBitmap;

		try {

			newBitmap = Image.FromFile(fileName) as Bitmap;
			TestForm.SetBitmap(newBitmap, (byte)Track.Value);

		} catch (ApplicationException e) {
			MessageBox.Show(this, e.Message, "Error with bitmap.", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		} catch (Exception e) {
			MessageBox.Show(this, e.Message, "Could not open image file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}

		if (bitmap != null)
			bitmap.Dispose();
		bitmap = newBitmap;
	}


	///<para>Change the opacity level of our test form.</para>
	private void Track_ValueChanged(object sender, EventArgs e) {
		byte opacity = (byte)Track.Value;
		LabelValue.Text = opacity.ToString();
		LabelValue.Refresh(); // We need this because on slow computers (mine!) the windows takes some time to update our label.

		if (bitmap != null)
			TestForm.SetBitmap(bitmap, opacity);		
	}

	///<para>Start the computer browser in the specified uri.</para>
	private void Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
		e.Link.Visited = true;
		using (System.Diagnostics.Process.Start(e.Link.LinkData.ToString())) {
		}
	}


	// Our member varaibles:

	private Label LabelValue;	// label with current opacity level
	private TrackBar Track;		// trackbar to chabge opacity level
	private MyPerPixelAlphaForm TestForm;	// our test form
	private Bitmap bitmap;		// bitmap that is currently displaying on our test form
}



// Our Great Application!
class TheApp {
	[STAThread]
	public static void Main() {
		Application.Run(new MyForm());
	}
}