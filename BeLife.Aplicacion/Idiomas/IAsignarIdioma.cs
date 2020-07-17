using System.Globalization;
using System.Threading;
using BeLife.Aplicacion.Configuracion;

namespace BeLife.Aplicacion.Idiomas
{
    public interface IAsignarIdioma
    {

        string NomenclaturaDeIdioma { get; set; }
        void Fijaridioma();

    }
}
