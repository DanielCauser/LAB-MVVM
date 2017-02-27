using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_MVVM.Models
{
    public class Repository
    {

        //public async Task<List<Cat>> GetCats()
        //{
        //    List<Cat> Cats;
        //    var URLAPI = "http://demos.ticapacitacion.com/cats";

        //    using (var client = new System.Net.Http.HttpClient())
        //    {
        //        var JSON = await client.GetStringAsync(URLAPI);
        //        Cats = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cat>>(JSON);
        //    }
        //    return Cats;
        //}

        public async Task<List<Cat>> GetCats()
        {
            var Service = new Services.AzureService<Cat>();
            var Items = await Service.GetTable();
            return Items.ToList();
        }

    }
}
