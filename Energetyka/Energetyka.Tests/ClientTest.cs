using NUnit.Framework;

namespace Energetyka.Tests
{
    public class ClientTest
    {
        [Test]
        public void WhenAddClientInMemory_ShouldRerutnCorrectName()
        {
            //ARRANGE
            var clientInMemory = new ClientInMemory("Jan", "Nowak");

            //ACT
            var name = clientInMemory.Name;
            var surname = clientInMemory.Surname;

            //ASSERT
            Assert.AreEqual("Jan", name);
            Assert.AreEqual("Nowak", surname);
        }

        [Test]
        public void WhenAddClientInFile_ShouldRerutnCorrectName()
        {
            //ARRANGE
            var clientInFile = new ClientInFile("Jan", "Nowak");

            //ACT
            var name = clientInFile.Name;
            var surname = clientInFile.Surname;

            //ASSERT
            Assert.AreEqual("Jan", name);
            Assert.AreEqual("Nowak", surname);
        }
    }
}
