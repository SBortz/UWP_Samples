using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserControlBinding.Annotations;
using UserControlBinding.UserControl;
using UserControlBinding.UserControl.ViewModel;

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

		#region Scenario 1,2,3,4 -> New ControlViewModel instance for control

		public UserControlViewModel NewControlViewModel
		{
			get
			{
				return new UserControlViewModel()
				{
					TextToShow = this.InputText
				};
			}
		}

		#endregion


		#region Scenario 5 -> Edit existing ControlViewModel, Control updates its binding through INotifyPropertyChanged

		private UserControlViewModel viewModelUserControlViewModel;

		public UserControlViewModel EditedControlViewModel
		{
			get { return this.viewModelUserControlViewModel; }
		}

		#endregion

		public MainPageViewModel()
		{
			this.viewModelUserControlViewModel = new UserControlViewModel();
			this.InputText = "TestText";

			
		}
	}
}
