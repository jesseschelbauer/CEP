using System.Text.RegularExpressions;

namespace CEP
{
    public class CEPValidator: ICEPValidator
    {
        public bool IsValid(string cep)
        {
            if (cep.Length != 8)
                return false;

            var regex = new Regex("[0-9]{8}");
            return regex.IsMatch(cep);
        }
    }
}
