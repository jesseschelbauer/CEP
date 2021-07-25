using System.Threading.Tasks;

namespace CEP
{
    public interface ICEPService<T> where T : class
    {
        Task<T> GetAsync(string cep);        
    }
}