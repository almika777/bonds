using Bonds.Core.Helpers;

namespace Bonds.Core.Tests
{
    public class CustomStringComparerTests
    {
        [Test]
        [TestCase("ОФЗ25690", "ОФЗ26243", 0.8)]
        public void Test(string s1, string s2, double ratio)
        {
            var c = CustomStringComparer.IsSimilar(s1, s2);
        }
    }
}
