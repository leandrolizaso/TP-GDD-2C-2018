using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PalcoNet.Utils
{
    public class SqlExceptionTransformer {

        public static string obtenerMensajeCustom(SqlException ex){
            Match match;
            switch (ex.Number) {
                case 515: //Not NULL
                    match = Regex.Match(ex.Message,@"No se puede insertar el valor NULL en la columna '(\w+)',");
                    return string.Format("El atributo {0} no puede estar vacio.", match.Groups[1].Value.Substring(match.Groups[1].Value.IndexOf('_')+1).Replace("_", " ").ToUpper());
                case 547: //Check constraint
                    match = Regex.Match(ex.Message, @"'(\w+)'");
                    return string.Format("El atributo {0} es invalido.", match.Groups[1].Value.Substring(match.Groups[1].Value.IndexOf('_') + 1).Replace("_", " ").ToUpper());
                case 2627: //Unique constraint
                    match = Regex.Match(ex.Message, @"El valor de la clave duplicada es \((.+)\)\.");
                    return string.Format("El valor \"{0}\" ya existe en la base de datos, por favor ingrese otro.", match.Groups[1].Value);
                default:
                    return "ERROR DESCONOCIDO EN LA BASE DE DATOS (" +ex.Number + ")\n\n" + ex.Message;
            }
            
        }
    }
}
