using System.Globalization;
using System.Threading;
using BeLife.Aplicacion.Configuracion;


namespace BeLife.Aplicacion.Idiomas
{
    public class AsignarIdioma
    {

        // Propiedades.
        public string NomenclaturaDeIdioma{ get; set; }


        // Constructor.
                private AsignarIdioma()
        {
            var myConfigurador = Configurador.Crear();
            this.NomenclaturaDeIdioma = myConfigurador.Idioma.Nomenclatura.ToString();
        }


        public AsignarIdioma(string nomenclaturaDeidioma)
        {
            this.NomenclaturaDeIdioma = nomenclaturaDeidioma;
        }


        // Metodo creador del objeto.
        public static AsignarIdioma Crear()
        {
            return new AsignarIdioma();
        }


        public static AsignarIdioma Crear(string nomenclaturaDeidioma)
        {
            return new AsignarIdioma(nomenclaturaDeidioma);
        }


        public void Fijaridioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(this.NomenclaturaDeIdioma);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(this.NomenclaturaDeIdioma);
        }


    }
}
