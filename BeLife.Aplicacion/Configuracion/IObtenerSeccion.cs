using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Aplicacion.Configuracion
{
    interface IObtenerSeccion
    {

        TObjeto LeerSeccion<TObjeto>(XDocument documentoXML, string nombreDeSeccion) where TObjeto : class;

    }
}
