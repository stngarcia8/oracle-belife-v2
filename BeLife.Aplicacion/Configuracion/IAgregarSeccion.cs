using System.Xml.Linq;

namespace BeLife.Aplicacion.Configuracion
{
    interface IAgregarSeccion
    {

        void AgregarElemento<TObjeto>(XElement nodoPadre, string nombreNodoHijo, TObjeto objetoDeConfiguracion) where TObjeto : class;

    }
}
