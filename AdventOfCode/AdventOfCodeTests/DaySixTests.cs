using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class DaySixTests
    {
        private DaySix _daySix;

        [TestInitialize]
        public void Initialize()
        {
            _daySix = new DaySix();
        }

        [TestMethod]
        public void PartOneExampleOne()
        {
            int[] startArray = new[] {0, 2, 7, 0};

            int returnValue = _daySix.RearrangeMemory(startArray);
            Assert.AreEqual(5, returnValue);
        }

        [TestMethod]
        public void PartOneActualInputTest()
        {
            int[] startArray = new[] {14, 0, 15, 12, 11, 11, 3, 5, 1, 6, 8, 4, 9, 1, 8, 4,};
            int returnValue = _daySix.RearrangeMemory(startArray);
            Assert.AreEqual(11137, returnValue);
        }

        [TestMethod]
        public void PartTwpExampleOne()
        {
            int[] startArray = new[] { 0, 2, 7, 0 };

            int returnValue = _daySix.RearrangeMemoryPartTwo(startArray);
            Assert.AreEqual(4, returnValue);
        }

        [TestMethod]
        public void PartTwoActualInputTest()
        {
            int[] startArray = new[] { 14, 0, 15, 12, 11, 11, 3, 5, 1, 6, 8, 4, 9, 1, 8, 4, };
            int returnValue = _daySix.RearrangeMemoryPartTwo(startArray);
            Assert.AreEqual(1037, returnValue);
        }
    }
}
