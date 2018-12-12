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
        public bool palabrasValidas(string cadena) 
        {
            return Regex.IsMatch(cadena, @"^[\D]+$");
        }

        public bool alfaNumericoValido(string cadena) 
        {
            return Regex.IsMatch(cadena, @"^[\w]+$");
        }

        public bool alfaNumericoYespaciosValido(string cadena)
        {
            return Regex.IsMatch(cadena, @"^[\w\s]+$");
        }

        public bool mailValido(string mail) 
        {
            return Regex.IsMatch(mail, @"^([\w\.\-_]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public bool numeroValido(string numero)
        {
            long numeroOut;
            return long.TryParse(numero, out numeroOut);

        }

    }
}
