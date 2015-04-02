using System.Drawing;

namespace Chromesthesia.WebInterface.Chrometisation
{
	public class WeightedColour
	{
		public Color Color { get; private set; }
		public double Weight { get; private set; }

		public WeightedColour(Color color, double weight)
		{
			Color = color;
			Weight = weight;
		}
	}
}