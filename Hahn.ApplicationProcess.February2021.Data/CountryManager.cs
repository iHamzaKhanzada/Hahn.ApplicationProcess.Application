using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data
{
    public class CountryManager : ICountryManager
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<bool> CountryIsValid(string name)
        {
            var response = await client.GetAsync($"https://restcountries.eu/rest/v2/name/{name}?fullText=true");
            return response.IsSuccessStatusCode;
        }
    }
}
