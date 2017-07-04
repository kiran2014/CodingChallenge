using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGLTest.Data.DataAccess;
using AGLTest.Data.Model;

namespace AGLTest.Data.Business
{
    public class CatBusiness : ICatBusiness
    {
        public IPeopleRepository _peopleRepository{ get; set; }
        public CatBusiness(IPeopleRepository peopleRepository)
        {
            this._peopleRepository = peopleRepository;
        }
        public async Task<Dictionary<Gender, IEnumerable<Pet>>> GetCatsByOwnerGender()
        {
            Dictionary<Gender, IEnumerable<Pet>> catByGender = new Dictionary<Gender, IEnumerable<Pet>>();
            IEnumerable<Person> Persons = await this._peopleRepository.GetPeople();

            catByGender.Add(Gender.Male, GetCats(Persons, Gender.Male));
            catByGender.Add(Gender.Female, GetCats(Persons, Gender.Female));

            return catByGender;

        }

        private IEnumerable<Pet> GetCats(IEnumerable<Person> persons, Gender gender)
        {
            List<Pet> pets =
                persons.ToList().FindAll(x => x.Gender == gender.ToString() && x.Pets != null)
                    .SelectMany(q => q.Pets)
                    .Where(a => a.Type == "Cat")
                    .Select(c => new Pet() { Name = c.Name, Type = c.Type })
                    .OrderBy(z => z.Name)
                    .ToList();
            return pets;
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
