using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UserControlBinding.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class StartView : Page
	{
		public StartView()
		{
			this.InitializeComponent();
		}

		private void SingleUserControlBinding_OnClick(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(SingleUserControlBinding));

		}

		private void CustomControlBinding_OnClick(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(ListUserControlBinding));
		}

		private void ListUserControlBinding_OnClick(object sender, RoutedEventArgs e)
		{
			
		}

		private void BehaviorControls_OnClick(object sender, RoutedEventArgs e)
		{
			

		}
	}
}
