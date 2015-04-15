using System;

namespace Chromesthesia.WebInterface.Exceptions
{
	public abstract class ChromesthesiaException : Exception
	{
		public virtual dynamic DefaultModel { get; private set; }
	}
}