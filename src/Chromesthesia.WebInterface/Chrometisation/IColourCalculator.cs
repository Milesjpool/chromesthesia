using System.Drawing;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;

namespace Chromesthesia.WebInterface.Chrometisation
{
	public interface IColourCalculator
	{
		Color From(Analysis analysis);
	}
}