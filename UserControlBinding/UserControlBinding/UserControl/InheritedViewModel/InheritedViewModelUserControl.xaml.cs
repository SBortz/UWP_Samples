using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using UserControlBinding.UserControl.ViewModel;
using UserControlBinding.ViewModel;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UserControlBinding.UserControl.InheritedViewModel
{
	public sealed partial class InheritedViewModelUserControl : Windows.UI.Xaml.Controls.UserControl
	{
		private UserControlViewModel viewModel;

		public InheritedViewModelUserControl()
		{
			this.InitializeComponent();

			this.Loaded += InheritedViewModelUserControl_Loaded;
		}

		private void InheritedViewModelUserControl_Loaded(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("DataContext: " + this.DataContext);

			// Read inherited parent ViewModel and extract the correct child ViewModel that is needed in UserControl
			this.viewModel = (this.DataContext as MainPageViewModel)?.EditedControlViewModel;
			
			// Set child ViewModel to DataContext
			this.DataContext = this.viewModel;

			// Needed for x:Bind to work, when DataContext changes
			this.Bindings.Update();
		}
	}
}
