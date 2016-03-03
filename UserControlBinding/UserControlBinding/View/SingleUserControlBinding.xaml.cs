using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UserControlBinding.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UserControlBinding.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SingleUserControlBinding : Page
    {
	    private MainPageViewModel viewModel;
        public SingleUserControlBinding()
        {
            this.InitializeComponent();

			this.viewModel = new MainPageViewModel(this.Dispatcher);
	        this.DataContext = this.viewModel;
        }

	    private void ButtonChangeInputText_OnClick(object sender, RoutedEventArgs e)
	    {
		    this.viewModel.InputText = "Test";
	    }
	}
}
