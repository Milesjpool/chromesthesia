using Chromesthesia.WebInterface.Views;
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
            Assert.That(new Homepage().Render(), Is.StringContaining(expected));
        }

    }
}
