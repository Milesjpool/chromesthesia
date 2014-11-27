using Chromesthesia.WebInterface;
using NUnit.Framework;

namespace Chromesthesia.Unit.Tests
{
    [TestFixture]
    public class WalkingSkeletonTests
    {
        [Test]
        public void Homepage_should_render_with_app_name()
        {
            var expected = "Chromesthesia";
            var renderer = new PageRenderer();
            Assert.That(renderer.RenderHomepage(), Is.StringContaining(expected));
        }

    }
}
