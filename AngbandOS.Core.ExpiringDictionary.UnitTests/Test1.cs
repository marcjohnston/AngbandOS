namespace AngbandOS.Core.ExpiringDictionary.UnitTests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestSet()
        {
            TimeSpan defaultTimeToLive = TimeSpan.FromSeconds(3);
            ExpiringDictionary<string, string> dict = new ExpiringDictionary<string, string>(defaultTimeToLive);
            DateTimeOffset expirationDateTime = dict.Set("key1", "value1");
            if (!dict.TryGet("key1", out string _))
            {
                Assert.Fail("Key was not present after set.");
            }
        }

        [TestMethod]
        public void TestExpiration()
        {
            TimeSpan defaultTimeToLive = TimeSpan.FromSeconds(3);
            ExpiringDictionary<string, string> dict = new ExpiringDictionary<string, string>(defaultTimeToLive);
            DateTimeOffset expirationDateTime = dict.Set("key1", "value1");
            Thread.Sleep(expirationDateTime - DateTimeOffset.UtcNow);
            if (dict.TryGet("key1", out string _))
            {
                Assert.Fail("Key was present after expiration.");
            }
        }
    }
}
