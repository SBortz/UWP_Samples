using System.ComponentModel;
using System.Runtime.CompilerServices;
using UserControlBinding.Annotations;

namespace UserControlBinding.UserControl.ViewModel
{
	public class UserControlViewModel : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		#region Fields

		private string textToShow;

		#endregion

		#region Properties

		public string TextToShow
		{
			get { return this.textToShow; }
			set
			{
				this.textToShow = value;
				this.OnPropertyChanged();
			}
		}

		#endregion
	}
}
