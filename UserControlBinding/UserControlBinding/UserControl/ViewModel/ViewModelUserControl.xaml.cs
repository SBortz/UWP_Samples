namespace UserControlBinding.UserControl.ViewModel
{
	public sealed partial class ViewModelUserControl : Windows.UI.Xaml.Controls.UserControl
	{
		private UserControlViewModel viewModel;

		public UserControlViewModel ViewModel
		{
			get { return this.viewModel; }
			set
			{
				this.viewModel = value;

				// This is only necessary for {Binding} to still work, if necessary.
				this.DataContext = this.viewModel;

				// Force all bindings to update the binding
				Bindings.Update();
			}
		}
		
		public ViewModelUserControl()
		{
			this.InitializeComponent();
		}
	}
}
