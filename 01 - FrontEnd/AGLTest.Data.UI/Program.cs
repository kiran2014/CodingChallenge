using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGLTest.Data.Business;
using AGLTest.Data.DataAccess;
using AGLTest.Data.Model;

namespace AGLTest.Data.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadLine();
        }

        private static async Task RunAsync()
        {
            // This can be injected Using Unity Framework incase if we are using MVC.
            CatBusiness peopleRepository = new CatBusiness(new PeopleRepository());

            Dictionary<Gender, IEnumerable<Pet>> petsByGender = await peopleRepository.GetCatsByOwnerGender();
            foreach (var petWithOwnerGender in petsByGender)
            {
                Console.WriteLine(petWithOwnerGender.Key);
                Console.WriteLine("********");
                foreach (Pet pet in petWithOwnerGender.Value)
                {
                    Console.WriteLine(pet.Name);
                }
                Console.WriteLine("");
            }

        }

    }
}
