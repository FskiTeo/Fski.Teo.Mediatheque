using Mediatheque.Core.Model;
using Mediatheque.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.CoreTests.ServiceTests.MediathequeServiceTests
{
    [TestClass]
    public class GetCDsDescription
    {
        [TestMethod]
        public void returnListDescriptions()
        {
            //Arrange
            MediathequeService mediathequeService = new MediathequeService(null);
            CD cd1 = new CD("Polak", "PLK");
            CD cd2 = new CD("Spectre", "Alan Walker");
            CD cd3 = new CD("Daft", "Daft Punk");

            //Act
            mediathequeService.AddObjet(cd1);
            mediathequeService.AddObjet(cd2);
            mediathequeService.AddObjet(cd3);


            List<string> actualList = mediathequeService.GetCDList();
            List<string> expectedList = new List<string>();
            expectedList.Add("Polak");
            expectedList.Add("Spectre");
            expectedList.Add("Daft");

            string actual = string.Join(", ", actualList);
            string expected = string.Join(", ", expectedList);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void returnMessageWhenEmpty()
        {
            //Arrange
            MediathequeService mediathequeService = new MediathequeService(null);

            //Act

            List<string> actualList = mediathequeService.GetCDList();
            List<string> expectedList = new List<string>();

            expectedList.Add("Aucun objet dans cette liste");

            string expected = string.Join(", ", expectedList);
            string actual = string.Join(", ", actualList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void returnOnlyCDsNotJeuxDeSociete()
        {
            //Arrange
            MediathequeService mediathequeService = new MediathequeService(null);
            CD cd1 = new CD("Polak", "PLK");
            CD cd2 = new CD("Spectre", "Alan Walker");
            CD cd3 = new CD("Daft", "Daft Punk");
            TypeJeuxDeSociete typeJeuxDeSociete1 = new TypeJeuxDeSociete();
            JeuxDeSociete jeuxDeSociete1 = new JeuxDeSociete("Monopoly", 10, 12, "Hasbro", typeJeuxDeSociete1);
            TypeJeuxDeSociete typeJeuxDeSociete2 = new TypeJeuxDeSociete();
            JeuxDeSociete jeuxDeSociete2 = new JeuxDeSociete("Quies", 10, 12, "Hasbro", typeJeuxDeSociete2);

            //Act
            mediathequeService.AddObjet(cd1);
            mediathequeService.AddObjet(cd2);
            mediathequeService.AddObjet(cd3);
            mediathequeService.AddObjet(jeuxDeSociete1);
            mediathequeService.AddObjet(jeuxDeSociete2);

            List<string> actualList = mediathequeService.GetCDList();
            List<string> expectedList = new List<string>();
            expectedList.Add("Polak");
            expectedList.Add("Spectre");
            expectedList.Add("Daft");

            string actual = string.Join(", ", actualList);
            string expected = string.Join(", ", expectedList);


            //To implement but should be Okay
            Assert.AreEqual(expected, actual);
        }

    }
}
