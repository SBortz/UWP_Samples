using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Core;
using UserControlBinding.Annotations;
using UserControlBinding.Work;

namespace UserControlBinding.SingleUserControlBinding.ViewModel
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

		private CoreDispatcher dispatcher;

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

		public UserControlViewModel(CoreDispatcher dispatcher)
		{
			this.dispatcher = dispatcher;
		}

		public async Task DoHeavyWorkLoadStuff()
		{
			var formatter = new DateTimeFormatter();

			var task = formatter.FormatNowAsync(1000);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
			Task.Run(async delegate
			{
				int result = await task;

				dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
				{
					this.TextToShow = result.ToString();
				});
			});
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

		}
	}
}
