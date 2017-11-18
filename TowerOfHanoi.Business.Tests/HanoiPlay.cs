using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TowerOfHanoi.Business.Tests
{
    [TestClass]
    public class HanoiPlay
    {
        [TestMethod]
        public void Play()
        {
            Hanoi hanoi = new Hanoi(5);
            int moves = hanoi.Start();
            Assert.AreEqual(31, moves);
        }
    }
}
