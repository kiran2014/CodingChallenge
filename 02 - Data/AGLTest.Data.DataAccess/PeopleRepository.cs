using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AGLTest.Data.Model;
using Newtonsoft.Json;

namespace AGLTest.Data.DataAccess
{
    public class PeopleRepository : IPeopleRepository
    {
        private const string EndPoint = "http://agl-developer-test.azurewebsites.net/people.json";

        public async Task<IEnumerable<Person>> GetPeople()
        {
            var http = new HttpClient();
            var url = String.Format(EndPoint);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            IEnumerable<Person> peopleinfo = JsonConvert.DeserializeObject<List<Person>>(result);
            return peopleinfo;

        }

    }
}
