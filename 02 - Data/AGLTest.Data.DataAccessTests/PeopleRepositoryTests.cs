using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGLTest.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLTest.Data.DataAccess.Tests
{
    [TestClass()]
    public class PeopleRepositoryTests
    {

        [TestMethod]
        public async Task FindPeopledataServiceIsUp()
        {
            // Arrange
            PeopleRepository repository = new PeopleRepository();
            // Act
            var peopleList = await repository.GetPeople();
            // Assert
            Assert.IsTrue(peopleList.ToList().Count > 0);
        }
    }
}