using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CEP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICEPService<CEPModel> _cepService;
        private readonly ICEPValidator _cepValidator;
        
        public CepController(ICEPService<CEPModel> cepService, ICEPValidator cepValidator)
        {
            _cepService = cepService;
            _cepValidator = cepValidator;
        }

        [HttpGet("{cep}", Name="Get")]
        [Produces("application/json")]
        public async Task<object> GetAsync(string cep) {

            if (!_cepValidator.IsValid(cep))
                return Task.FromResult<object>(new { Erro = "CEP inválido" }).Result; 

            var cepModel = await this._cepService.GetAsync(cep);

            if (cepModel == null)
                return new { Erro = "Bad request" };

            return !string.IsNullOrEmpty(cepModel.Cep) ? cepModel :  Task.FromResult<object>(new { Erro = "Não encontrado" }).Result; ;
        }
    }
}
