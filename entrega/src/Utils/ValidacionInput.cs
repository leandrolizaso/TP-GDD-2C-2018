using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PalcoNet.Utils
{
    class ValidacionInput
    {
        public bool cadenaValida(string cadena) 
        {
            return Regex.IsMatch(cadena, @"^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$");
        }

        public bool mailValido(string mail) 
        {
            return Regex.IsMatch(mail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public bool numeroValido(string numero)
        {
            int numeroOut;
            return Int32.TryParse(numero, out numeroOut);

        }
    }
}
