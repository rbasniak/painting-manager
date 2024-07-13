using PaintingManager.Catalogue;
using System.Collections.Specialized;
using System.Diagnostics;

namespace PaintingManager.Tests
{
    public class ColorHelperTests
    {
        [Fact]
        public void TestMatch()
        {
            var dist1 = ColorHelper.CalculateColorDistance("#00506F", "#365478");
            var dist2 = ColorHelper.CalculateColorDistance("#000000", "#FFFFFF");

            var match1 = ColorHelper.CalculateColorSimilarity("#00506F", "#365478");
            var match2 = ColorHelper.CalculateColorSimilarity("#000000", "#FFFFFF");
            var match3 = ColorHelper.CalculateColorSimilarity("#DDDDDD", "#DDDDDD");

            var repo = new PaintRepository();

            var results = new SortedDictionary<double, Paint>();

            foreach (var paint in repo.GetAllPaints())
            {
                var match = ColorHelper.CalculateColorSimilarity("#00506F", paint.HexColor);
                if (!results.TryAdd(match, paint))
                {
                    var temp = results[match];
                    Debugger.Break();
                }
            }

        }
    }
}