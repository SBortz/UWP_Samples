using System.Diagnostics;
using Windows.UI.Xaml;
using UserControlBinding.SingleUserControlBinding.ViewModel;
using UserControlBinding.ViewModel;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UserControlBinding.SingleUserControlBinding.InheritedViewModel
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
			this.viewModel = (this.DataContext as MainPageViewModel)?.ControlViewModel;
			
			// Set child ViewModel to DataContext
			this.DataContext = this.viewModel;

			// Needed for x:Bind to work, when DataContext changes
			this.Bindings.Update();
		}
	}
}
