using System;
using System.Collections.Generic;
using System.Text;

namespace _1er_ParcialAPI_1_20.UI.Registros
{
    public static class Utilidad
    {
        public static decimal TODECIMAL(this string num)
        {
            decimal numero = 0;
            decimal.TryParse(num, out numero);
            return numero;
        }
    }
}

