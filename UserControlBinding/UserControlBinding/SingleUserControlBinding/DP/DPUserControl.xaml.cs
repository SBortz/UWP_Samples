using System.Diagnostics;
using Windows.UI.Xaml;

namespace UserControlBinding.SingleUserControlBinding.DP
{
	public sealed partial class DPUserControl : Windows.UI.Xaml.Controls.UserControl
	{
		public static DependencyProperty ColorProperty { get; }

		static DPUserControl ()
		{
			ColorProperty = DependencyProperty.Register(nameof(Headline), typeof(string), typeof(DPUserControl), new PropertyMetadata(null, PropertyChangedCallback));
		}

		private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			var control = dependencyObject as DPUserControl;
			Debug.WriteLine(nameof(ColorProperty) + " set to " + control.Headline);
		}

		public string Headline
		{
			get { return (string)this.GetValue(ColorProperty); }
			set
			{
				this.SetValue(ColorProperty, value);
				this.Bindings.Update();
			}
		}
		public DPUserControl()
		{
			this.InitializeComponent();
		}
	}
}
