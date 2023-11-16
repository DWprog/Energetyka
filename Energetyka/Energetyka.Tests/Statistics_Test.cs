using NUnit.Framework;


namespace Energetyka.Tests
{
    public class Statistics_Test
    {
        [Test]
        public void WhenAddUse_ShouldRerutnCorrectMax()
        {
            //ARRANGE
            var clientInMemory = new ClientInMemory("Jan", "Nowak");

            //ACT
            AddSomeCorrectUses(clientInMemory);


            var stat = clientInMemory.GetStatistics();

            //ASSERT
            Assert.AreEqual(32f, stat.Max);
        }

        [Test]
        public void WhenAddUse_ShouldRerutnCorrectMin()
        {
            //ARRANGE
            var clientInMemory = new ClientInMemory("Jan", "Nowak");

            //ACT
            AddSomeCorrectUses(clientInMemory);


            var stat = clientInMemory.GetStatistics();

            //ASSERT
            Assert.AreEqual(1f, stat.Min);
        }

        [Test]
        public void WhenAddUse_ShouldRerutnCorrectSum()
        {
            //ARRANGE
            var clientInMemory = new ClientInMemory("Jan", "Nowak");

            //ACT
            AddSomeCorrectUses(clientInMemory);


            var stat = clientInMemory.GetStatistics();

            //ASSERT
            Assert.AreEqual(64.5f, stat.Sum);
        }

        [Test]
        public void WhenAddUse_ShouldRerutnCorrectCount()
        {
            //ARRANGE
            var clientInMemory = new ClientInMemory("Jan", "Nowak");

            //ACT
            AddSomeCorrectUses(clientInMemory);


            var stat = clientInMemory.GetStatistics();

            //ASSERT
            Assert.AreEqual(6, stat.Count);
        }

        [Test]
        public void WhenAddUse_ShouldRerutnCorrectAverage()
        {
            //ARRANGE
            var clientInMemory = new ClientInMemory("Jan", "Nowak");

            //ACT
            AddSomeCorrectUses(clientInMemory);


            var stat = clientInMemory.GetStatistics();

            //ASSERT
            Assert.AreEqual(10.75f, stat.Average);
        }

        [Test]
        public void IfAreUses_ShouldRerutnCorrectValue()
        {
            //ARRANGE
            var clientInMemory = new ClientInMemory("Jan", "Nowak");

            //ACT
            AddSomeCorrectUses(clientInMemory);


            var result = clientInMemory;

            //ASSERT
            Assert.AreEqual(true, clientInMemory.IsStat());
        }

        [Test]
        public void IfNoUses_ShouldRerutnCorrectValue()
        {
            //ARRANGE
            var clientInMemory = new ClientInMemory("Jan", "Nowak");

            //ACT
            //no data uses

            var result = clientInMemory;

            //ASSERT
            Assert.AreEqual(false, clientInMemory.IsStat());
        }

        private void AddSomeCorrectUses(ClientInMemory client)
        {
            //Max 32
            //Min 1
            //Sum 64.5
            //Count 6
            //Average 10.75
            client.AddUse(15);
            client.AddUse(8.7f);
            //client.AddUse(-10); //rejected
            client.AddUse(32);
            client.AddUse(4);
            //client.AddUse("a"); //rejected
            client.AddUse("1");
            //client.AddUse("-5"); //rejected
            client.AddUse("3,8");
            //client.AddUse("7,,8"); //rejected
        }
        
        private void AddSomeInCorrectUses(ClientInMemory client)
        {
            client.AddUse(-10); //rejected
            client.AddUse("a"); //rejected
            client.AddUse("-5"); //rejected
            client.AddUse("7,,8"); //rejected
        }
    }
}
