using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Uno.UI.Tests.App.Xaml;
using UWPUnitTests2;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UnitTestsApp
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	sealed partial class App : Application
	{
		internal const bool EnableInteractiveTests = false;

		async partial void OnLaunchedPartial()
		{
			await Task.Delay(50);

			TestRunner.Run();

			await Task.Run(async () =>
			{
				await Task.Delay(1500); //Puts the message after the symbol-loading spam
				Debug.WriteLine("Tests have completed.");
			});
		}
	}
}
