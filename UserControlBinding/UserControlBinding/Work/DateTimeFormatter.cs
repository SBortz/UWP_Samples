using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlBinding.Work
{
	public class DateTimeFormatter
	{
		public const int count = 5000000;
		public int FormatNow()
		{
			return Format(count);
		}

		public async Task<int> FormatNowAsync(int count)
		{
			return Format(count);
		}

		public async Task<int> FormatNowAsync()
		{
			return Format(count);
		}

		private int Format(long count)
		{
			int chars = 0;
			for (int i = 0; i < count; i++)
			{
				var dateTime = DateTime.Now.ToString();
				chars += dateTime.Length;
			}

			return chars;
		}
	}

	public class DateTimeFormatterAsync
	{
		private DateTimeFormatter dateTimeFormatter;

		public async Task<int> FormatNowAsync(int threads)
		{
			if (dateTimeFormatter == null)
			{
				dateTimeFormatter = new DateTimeFormatter();
			}

			int countPerThread = DateTimeFormatter.count / threads;

			List<Task<int>> taskList = new List<Task<int>>();
			for (int i = 0; i < threads; i++)
			{
				taskList.Add(Task.Run(() => dateTimeFormatter.FormatNowAsync(countPerThread)));
			}

			int chars = 0;

			foreach (var task in taskList)
			{
				chars += await task;
			}

			return chars;
		}
	}
}
