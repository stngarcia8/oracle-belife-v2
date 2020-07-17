using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace BeLife.Aplicacion.Configuracion
{
    class ObtenerSeccion:IObtenerSeccion
    {

        public TObjeto LeerSeccion<TObjeto>(XDocument documentoXML, string nombreDeSeccion) where TObjeto : class
        {
                        var nodoActual = (from x in documentoXML.Root.Elements(nombreDeSeccion)
                              select x).ToList();
            Type tipo = typeof(TObjeto);
            PropertyInfo[] propiedades = tipo.GetProperties();
            var myObjeto = Activator.CreateInstance<TObjeto>();
            string valor = string.Empty;
            foreach (PropertyInfo propiedad in propiedades)
            {
                valor = (from x in nodoActual.Elements()
                         where x.Name.ToString() == propiedad.Name.ToString()
                         select x.Value).FirstOrDefault();
                propiedad.SetValue(myObjeto, valor, null);
            }
            return myObjeto;
        }

    }
}
