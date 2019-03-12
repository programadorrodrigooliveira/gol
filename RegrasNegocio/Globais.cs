using System;
using System.Collections.Generic;
using System.Text;
using Database;

namespace RegrasNegocio
{
    internal class Globais
    {
        private static FacadesClass _controles;

        public static FacadesClass Controles
        {
            get { return _controles ?? (_controles = new FacadesClass()); }
        }
    }
}
