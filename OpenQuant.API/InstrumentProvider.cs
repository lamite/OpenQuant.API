using SmartQuant.Providers;
using System;
namespace OpenQuant.API
{
	public class InstrumentProvider : Provider
	{
		internal InstrumentProvider(IInstrumentProvider provider) : base(provider)
		{
		}
	}
}
