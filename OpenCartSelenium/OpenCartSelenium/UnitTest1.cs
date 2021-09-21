using NUnit.Framework;

namespace OpenCartSelenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            int a = 3;
            if (a == 3) 
            {
                Assert.Pass();
            }
        }
    }
}