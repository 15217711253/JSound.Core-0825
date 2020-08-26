using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace JSound.App
{
    internal enum AccentState
	{
		ACCENT_DISABLED = 0,
		ACCENT_ENABLE_GRADIENT = 1,
		ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
		ACCENT_ENABLE_BLURBEHIND = 3,
		ACCENT_INVALID_STATE = 4
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct AccentPolicy
	{
		public AccentState AccentState;
		public int AccentFlags;
		public int GradientColor;
		public int AnimationId;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct WindowCompositionAttributeData
	{
		public WindowCompositionAttribute Attribute;
		public IntPtr Data;
		public int SizeOfData;
	}

	internal enum WindowCompositionAttribute
	{
		// ...
		WCA_ACCENT_POLICY = 19
		// ...
	}
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
    {
		[DllImport("user32.dll")]
		internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
		public MainWindow()
		{
			InitializeComponent();
		}


		internal void EnableBlur()
		{
			var windowHelper = new WindowInteropHelper(this);

			var accent = new AccentPolicy();
			accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

			var accentStructSize = Marshal.SizeOf(accent);

			var accentPtr = Marshal.AllocHGlobal(accentStructSize);
			Marshal.StructureToPtr(accent, accentPtr, false);

			var data = new WindowCompositionAttributeData();
			data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
			data.SizeOfData = accentStructSize;
			data.Data = accentPtr;

			SetWindowCompositionAttribute(windowHelper.Handle, ref data);

			Marshal.FreeHGlobal(accentPtr);
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			EnableBlur();

		}

		private void btnHide_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void btnClose_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			System.Environment.Exit(0);
			//XService.SrvClose();
			this.Close();

		}

		private void btnToggleMax_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (this.WindowState == WindowState.Maximized)
				this.WindowState = WindowState.Normal;
			else
				this.WindowState = WindowState.Maximized;

		}
		private void LeftTop_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount == 2)
			{
				this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
				e.Handled = true;
			}
		}
		private void Grid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				this.DragMove();
			}
		}
	}
}
