using System;
namespace OpenQuant.API.Compression
{
	internal class TimeBarCompressor : BarCompressor
	{
		protected override void Add(DataEntry entry)
		{
			if (this.bar == null || this.bar.EndTime <= entry.DateTime)
			{
				if (this.bar != null)
				{
					base.EmitNewCompressedBar();
				}
				DateTime barBeginTime = this.GetBarBeginTime(entry.DateTime);
				DateTime endTime = barBeginTime.AddSeconds((double)this.newBarSize);
				base.CreateNewBar(BarType.Time, barBeginTime, endTime, entry.Items[0].Price);
			}
			base.AddItemsToBar(entry.Items);
		}
		private DateTime GetBarBeginTime(DateTime datetime)
		{
			long num = (long)datetime.TimeOfDay.TotalSeconds / this.newBarSize * this.newBarSize;
			return datetime.Date.AddSeconds((double)num);
		}
	}
}
