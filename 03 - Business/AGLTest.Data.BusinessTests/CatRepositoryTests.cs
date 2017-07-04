using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGLTest.Data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGLTest.Data.DataAccess;
using AGLTest.Data.Model;

namespace AGLTest.Data.Business.Tests
{
    [TestClass()]
    public class CatRepositoryTests
    {
        [TestMethod]
        public async Task GetCatsByMaleOwner()
        {
            // Arrange
            CatBusiness catBusiness = new CatBusiness(new PeopleRepository());
            Dictionary<Gender, IEnumerable<Pet>> result = await catBusiness.GetCatsByOwnerGender();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result[Gender.Male]);
            Assert.AreEqual("Garfield", result[Gender.Male].ToList()[0].Name);
        }

        [TestMethod]
        public async Task GetCatsByFeMaleOwner()
        {
            // Arrange
            CatBusiness catBusiness = new CatBusiness(new PeopleRepository());
            Dictionary<Gender, IEnumerable<Pet>> result = await catBusiness.GetCatsByOwnerGender();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result[Gender.Female]);
            Assert.AreEqual("Garfield", result[Gender.Female].ToList()[0].Name);
        }

    }
}