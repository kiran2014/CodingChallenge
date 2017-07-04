using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGLTest.Data.Model;

namespace AGLTest.Data.Business
{
    interface ICatBusiness
    {
        Task<Dictionary<Gender, IEnumerable<Pet>>> GetCatsByOwnerGender();
    }
}
