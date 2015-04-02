using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SurveyResults.Outputs
{
	public class SwatchOutputType : IOutputType
	{
		private readonly UserInteraction _interaction;
		private Bitmap _swatch;
		private Graphics _graphics;
		private readonly int _iterations;
		private const int SquareSize = 50;
		private const int TextWidth = 200;
		private const int TextBorder = 5;


		public SwatchOutputType(UserInteraction interaction)
		{
			_interaction = interaction;
			_iterations = _interaction.GetNumberOfIterations();
		}

		public void Print(IList<TrackData> allData)
		{
			var numberOfTracks = allData.Count;
			InitialiseGraphics(numberOfTracks);
			var lb = new LoadingBar("Rendering", numberOfTracks);
			lb.Start();
			for (int track = 0; track < numberOfTracks; track++)
			{
				RenderTrackSwatch(allData[track], track);
				lb.Next();
			}
			SaveSwatchToFile();
		}

		public void Print(TrackData trackData)
		{
			const int numberOfTracks = 1;
			InitialiseGraphics(numberOfTracks);
			RenderTrackSwatch(trackData, numberOfTracks - 1);
			SaveSwatchToFile();
		}

		private void InitialiseGraphics(int numberOfTracks)
		{
			int width = TextWidth + (_iterations * SquareSize);
			var height = numberOfTracks * SquareSize;
			_swatch = new Bitmap(width, height);
			_graphics = Graphics.FromImage(_swatch);
			_graphics.FillRectangle(Brushes.White, 0, 0, width, height);
		}

		private void RenderTrackSwatch(TrackData trackData, int trackOffset)
		{
			var calculate = new Calculate(trackData);
			var yOffset = SquareSize * trackOffset;
			WriteTrackInfo(trackData, yOffset);
			DrawExaggeratedMeans(calculate, yOffset);
		}

		private void SaveSwatchToFile()
		{
			var location = _interaction.GetSaveSwatchLocation();
			_swatch.Save(location);
		}

		private void WriteTrackInfo(TrackData trackData, int yOffset)
		{
			var track = trackData.Results.First();
			var trackInfo = track.TrackId + " - " + track.TrackString;

			const int width = TextWidth - (2*TextBorder);
			const int height = SquareSize - (2 * TextBorder);
			var textArea = new RectangleF(TextBorder, yOffset, width, height);
			PrintString(trackInfo, Brushes.Black, textArea);
		}

		private void DrawExaggeratedMeans(Calculate calculate, int yOffset)
		{
			for (int i = 0; i < _iterations; i++)
			{
				var colour = calculate.ExaggeratedMean(i);
				var xOffset = TextWidth + (i*SquareSize);
				DrawSquare(colour, xOffset, yOffset);
				WriteColourInfo(colour, xOffset, yOffset);
			}
		}

		private void DrawSquare(Colour colour, int xOffset, int yOffset)
		{
			var brushColour = Color.FromArgb(colour.Redness, colour.Greenness, colour.Blueness);
			_graphics.FillRectangle(new SolidBrush(brushColour), xOffset, yOffset, SquareSize, SquareSize);
		}

		private void WriteColourInfo(Colour colour, int xOffset, int yOffset)
		{
			const int width = SquareSize - (2 * TextBorder);
			const int height = width;
			var brush = Brushes.Black;
			if (colour.Shade < 255) brush = Brushes.White;
			var textArea = new RectangleF(xOffset + TextBorder, yOffset + TextBorder, width, height);
			PrintString(colour.ToHex(), brush, textArea);
		}

		private void PrintString(string text, Brush brush, RectangleF textArea)
		{
			_graphics.DrawString(text, new Font("Tahoma", 8), brush, textArea);
		}
	}
}