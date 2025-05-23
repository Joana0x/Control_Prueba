using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ControlEscolarCore.Utilities;

namespace ControlEscolar.Bussines
{
    public class EstudianteNegocio
    {
        public static bool EsCorreoValido (string correo)
        {
            return Validaciones.EsCorreroValido(correo);
        }

        public static bool EsCURPValido (string curp)
        {
            return Validaciones.EsCURPValido(curp);
        }

        public static bool EsNoControlValido (String nocontrol)
        {
            string patron = @"^(T|M)-\d{4}-\d{3,5}$";
            return Regex.IsMatch(nocontrol, patron);
        }
    }
}
