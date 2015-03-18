namespace SurveyResults
{
	public class Validator
	{
		private readonly int _maxId;

		public Validator(int maxId)
		{
			_maxId = maxId;
		}

		public bool ValidateUserInputAndValidateTrackId(string userInput, out int trackId)
		{
			var isInteger = int.TryParse(userInput, out trackId);
			var isInRange = (trackId >= 0) && (trackId <= _maxId);
			return isInteger && isInRange;
		}
	}
}