using AngbandOS.Tokens;

namespace AngbandOS.Tokens.Tests
{
    [TestClass]
    public class TokenExtensionUnitTest
    {
        [TestMethod]
        public void ByIndex()
        {
            Assert.AreEqual("one", "one,two,three".Token(",", 0));
            Assert.AreEqual("two", "one,two,three".Token(",", 1));
            Assert.AreEqual("three", "one,two,three".Token(",", 2));
            Assert.AreEqual("", "one,two,three".Token(",", 3));
        }

        [TestMethod]
        public void FromEnd()
        {
            Assert.AreEqual("three", "one,two,three".Token(",", -1));
            Assert.AreEqual("two", "one,two,three".Token(",", -2));
            Assert.AreEqual("one", "one,two,three".Token(",", -3));
            Assert.ThrowsException<Exception>(() => "one,two,three".Token(",", -4));
        }

        [TestMethod]
        public void ByIndexRemainingTokens()
        {
            Assert.AreEqual("one,two,three", "one,two,three".Token(",", 0, true));
            Assert.AreEqual("two,three", "one,two,three".Token(",", 1, true));
            Assert.AreEqual("three", "one,two,three".Token(",", 2, true));
            Assert.AreEqual("", "one,two,three".Token(",", 3, true));
        }

        [TestMethod]
        public void FromEndRemainingTokens()
        {
            Assert.AreEqual("three", "one,two,three".Token(",", -1, true));
            Assert.AreEqual("two,three", "one,two,three".Token(",", -2, true));
            Assert.AreEqual("one,two,three", "one,two,three".Token(",", -3, true));
            Assert.ThrowsException<Exception>(() => "one,two,three".Token(",", -4, true));
        }

        [TestMethod]
        public void ByIndexWithCount()
        {
            Assert.AreEqual("", "one,two,three".Token(",", 0, 0));
            Assert.AreEqual("one", "one,two,three".Token(",", 0, 1));
            Assert.AreEqual("one,two", "one,two,three".Token(",", 0, 2));
            Assert.AreEqual("one,two,three", "one,two,three".Token(",", 0, 3));

            Assert.AreEqual("", "one,two,three".Token(",", 1, 0));
            Assert.AreEqual("two", "one,two,three".Token(",", 1, 1));
            Assert.AreEqual("two,three", "one,two,three".Token(",", 1, 2));
            Assert.AreEqual("two,three", "one,two,three".Token(",", 1, 3));
        }

        [TestMethod]
        public void FromEndWithCount()
        {
            Assert.AreEqual("", "one,two,three".Token(",", -2, 0));
            Assert.AreEqual("two", "one,two,three".Token(",", -2, 1));
            Assert.AreEqual("two,three", "one,two,three".Token(",", -2, 2));
            Assert.AreEqual("two,three", "one,two,three".Token(",", -2, 3));
        }

        [TestMethod]
        public void ByIndexWithNegativeCount()
        {
            Assert.AreEqual("one,two", "one,two,three".Token(",", 0, -1));
            Assert.AreEqual("one", "one,two,three".Token(",", 0, -2));
            Assert.ThrowsException<Exception>(() => "one,two,three".Token(",", 0, -3));

            Assert.AreEqual("two", "one,two,three".Token(",", 1, -1));
            Assert.ThrowsException<Exception>(() => "one,two,three".Token(",", 1, -2));
        }

        [TestMethod]
        public void FromEndWithNegativeCount()
        {
            Assert.AreEqual("two", "one,two,three".Token(",", -2, -1));
            Assert.ThrowsException<Exception>(() => "one,two,three".Token(",", -2, -2));
            Assert.ThrowsException<Exception>(() => "one,two,three".Token(",", -2, -3));
        }
    }
}