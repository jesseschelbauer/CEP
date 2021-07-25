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

            var response = await client.ExecuteGetAsync<T>(request);

            if (!response.IsSuccessful) 
            {
                // Poderia logar sempre que o serviço via CEP reponder com 500 para sinalizar que o mesmo está fora
                
                return null;    
            }

            return response.Data;
        }
    }
}
