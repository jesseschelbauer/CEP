using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CEP
{
    public class ViaCepService<T> : ICEPService<T> where T : class
    {
        public async Task<T> GetAsync(string cep) 
        {
            var client = new RestClient($"https://viacep.com.br/ws/{cep}/json/");
            var request = new RestRequest(Method.GET);
            return await client.GetAsync<T>(request);
        }
    }
}
