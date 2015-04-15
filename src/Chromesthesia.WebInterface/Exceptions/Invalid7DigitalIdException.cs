namespace Chromesthesia.WebInterface.Exceptions
{
	public class Invalid7DigitalIdException : ChromesthesiaException
	{
		private readonly string _id;

		public Invalid7DigitalIdException(string id)
		{
			_id = id;
		}

		public override dynamic DefaultModel
		{
			get
			{
				return "{" +
							 "\"id\":\"" + _id + "\"," +
							 "\"error\":\"This is not a valid 7digital track ID\"" +
							 "}";
			}
		}
	}
}