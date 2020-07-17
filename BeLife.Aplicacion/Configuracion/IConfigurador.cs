using System;
using BeLife.Aplicacion.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Aplicacion.Configuracion
{
    public interface IConfigurador
    {

        IBdd Bdd { get; }
        ILanguage Idioma { get; set; }

    }
}
