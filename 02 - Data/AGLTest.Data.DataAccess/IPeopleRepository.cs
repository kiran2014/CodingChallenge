using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGLTest.Data.Model;

namespace AGLTest.Data.DataAccess
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<Person>> GetPeople();
    }
}
