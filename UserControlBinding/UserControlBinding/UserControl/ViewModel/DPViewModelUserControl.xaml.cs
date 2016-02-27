using System.Diagnostics;
using Windows.UI.Xaml;

namespace UserControlBinding.UserControl.ViewModel
{
	public sealed partial class DPViewModelUserControl : Windows.UI.Xaml.Controls.UserControl
	{
		public static DependencyProperty ViewModelProperty { get; }

		static DPViewModelUserControl()
		{
			ViewModelProperty = DependencyProperty.Register(nameof(ViewModel), typeof(UserControlViewModel), typeof(DPViewModelUserControl),
			new PropertyMetadata(null,
			delegate (DependencyObject o, DependencyPropertyChangedEventArgs args)
			{
				var control = o as DPViewModelUserControl;
				var viewModel = args.NewValue as UserControlViewModel;

				// This is only necessary for {Binding} to still work, if necessary.
				control.DataContext = viewModel;

				// Force all bindings to update, if a new ViewModel is being put into the control
				if (args.OldValue != null && !ReferenceEquals(args.OldValue, args.NewValue))
				{
					control.Bindings.Update();
				}
			}));
		}

		public UserControlViewModel ViewModel
		{
			get { return (UserControlViewModel)this.GetValue(ViewModelProperty); }
			set { this.SetValue(ViewModelProperty, value); }
		}

		public DPViewModelUserControl()
		{
			this.InitializeComponent();
		}
	}
}
