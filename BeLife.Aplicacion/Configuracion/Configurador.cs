using System.IO;
using System.Threading;
using System.Xml.Linq;
using BeLife.Aplicacion.Clases;

namespace BeLife.Aplicacion.Configuracion
{
    public class Configurador:IConfigurador
    {

        // Miembros.
        private readonly string archivoConfiguracion;
        private Bdd myBdd;


        // Propiedades.
        public IBdd Bdd { get { return this.myBdd; } }
        public ILanguage Idioma { get; set; }
        public IVisualizacion ModoVisualizacion { get; set; }


        // Constructor.
        private Configurador()
        {
            this.archivoConfiguracion = "belife.conf";
            this.myBdd = new Bdd();
            this.Idioma = new Language();
            this.ModoVisualizacion = new Visualizacion();
            if (!File.Exists(this.archivoConfiguracion))
            {
                ValoresIniciales();
                GrabarConfiguraciones();
            }
            CargarConfiguraciones();
        }


        // Metodo creador del objeto.
        public static Configurador Crear()
        {
            return new Configurador();
        }


        private void ValoresIniciales()
        {
            this.myBdd.DataSource = "localhost";
            this.myBdd.User = "belife";
            this.myBdd.Pwd = "belife";
            this.Idioma.Idioma= Thread.CurrentThread.CurrentUICulture.DisplayName.ToString();
            this.Idioma.Nomenclatura= Thread.CurrentThread.CurrentUICulture.Name.ToString();
            this.ModoVisualizacion.Theme = "Default";
            this.ModoVisualizacion.AyudaLateral = "True";
        }


        public void GrabarConfiguraciones()
        {
            XDocument documentoXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            XElement nodoRaiz = new XElement("Configuraciones");
            documentoXML.Add(nodoRaiz);
            var seccion = new AgregarSeccion();
            seccion.AgregarElemento(nodoRaiz, "BDD", this.myBdd);
            seccion.AgregarElemento(nodoRaiz, "Idiomas", this.Idioma);
            seccion.AgregarElemento(nodoRaiz, "Visualizacion", this.ModoVisualizacion);
            documentoXML.Save(this.archivoConfiguracion);
        }


        private void CargarConfiguraciones()
        {
            XDocument documentoXML = XDocument.Load(this.archivoConfiguracion);
            var seccion = new ObtenerSeccion();
            this.myBdd= seccion.LeerSeccion<Bdd>(documentoXML, "BDD");
            this.Idioma = seccion.LeerSeccion<Language>(documentoXML, "Idiomas");
            this.ModoVisualizacion= seccion.LeerSeccion<Visualizacion>(documentoXML, "Visualizacion");
        }





    }
}
