﻿using System.Windows;
using Dapplo.Config.Ini;
using Dapplo.Config.Language;
using Greenshot.CaptureCore;
using Greenshot.CaptureCore.Forms;
using Greenshot.Core.Configuration;
using Greenshot.Core.Enumerations;

namespace Greenshot.Wpf.QuickTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IniConfig _iniConfig = new IniConfig("GreenshotQuickTest", "greenshot-test");
		private readonly LanguageLoader _languageLoader = new LanguageLoader("GreenshotQuickTest");

		public MainWindow()
		{

			Loaded += async (sender, args) =>
			{
				await _iniConfig.RegisterAndGetAsync<ITestConfiguration>();
				await _languageLoader.RegisterAndGetAsync<ITestTranslations>();


			};
			InitializeComponent();
		}

		private async void WindowButton_OnClick(object sender, RoutedEventArgs e)
		{
			var captureWindow = new CaptureWindow
			{
				Mode = WindowCaptureMode.Auto,
				CaptureCursor = false,
				IeCapture = true
			};

			var capture = await captureWindow.CaptureActiveAsync();
			// TODO: Show it
		}

		private void ScreenButton_OnClick(object sender, RoutedEventArgs e)
		{
			var captureScreen = new CaptureScreen
			{
				Mode = ScreenCaptureMode.Auto,
				CaptureCursor = true,
			};

			var cropCapture = new CropCapture();
			var capture = captureScreen.CaptureActiveScreen();
			cropCapture.Crop(capture);

			// TODO: Show it
		}
	}
}