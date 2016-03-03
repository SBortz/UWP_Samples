using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using UserControlBinding.Annotations;
using UserControlBinding.SingleUserControlBinding.ViewModel;


namespace UserControlBinding.ViewModel
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		private CoreDispatcher dispatcher;

		#region DPUserControl
		private string inputText;
		
		public string InputText
		{
			get { return this.inputText; }
			set
			{
				this.inputText = value;
				this.OnPropertyChanged();


				// Scenario 1,2,3 -> Re-fill a new ControlViewModel into control
				this.OnPropertyChanged(nameof(NewControlViewModel));

				// Scenario 4 -> Edit existing child ControlViewModel
				this.viewModelUserControlViewModel.TextToShow = value;
			}
		}

		#endregion

		#region Scenario 1,2,3 -> New ControlViewModel instance for control

		public UserControlViewModel NewControlViewModel
		{
			get
			{
				return new UserControlViewModel(this.dispatcher)
				{
					TextToShow = this.InputText
				};
			}
		}

		#endregion


		#region Scenario 5 -> Edit existing ControlViewModel, Control updates its binding through INotifyPropertyChanged

		private UserControlViewModel viewModelUserControlViewModel;

		public UserControlViewModel ControlViewModel
		{
			get { return this.viewModelUserControlViewModel; }
		}

		#endregion

		public MainPageViewModel(CoreDispatcher dispatcher)
		{
			this.dispatcher = dispatcher;
			this.viewModelUserControlViewModel = new UserControlViewModel(this.dispatcher);
			this.InputText = "TestText";

			
		}
	}
}
