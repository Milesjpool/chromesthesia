using Chromesthesia.WebInterface.Exceptions;
using Chromesthesia.WebInterface.Parsing;

namespace Chromesthesia.WebInterface.AcousticbrainzHelpers
{
	public class InputParser
	{
		private readonly dynamic _parameters;

		public InputParser(dynamic parameters)
		{
			_parameters = parameters;
		}

		public Mbid GetMbid()
		{
			var idType = ((string) _parameters.idType).ToLower();

			if (idType == "7d")
				return new SevenDigitalId(_parameters.id).ToMbid();
			if (idType == "mbid")
				return new Mbid(_parameters.id);

			throw new InvalidIdTypeException();
		}
	}
}