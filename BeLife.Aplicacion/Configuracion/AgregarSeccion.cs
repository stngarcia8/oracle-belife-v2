using System;
using System.Reflection;
using System.Xml.Linq;

namespace BeLife.Aplicacion.Configuracion
{
    class AgregarSeccion:IAgregarSeccion
    {

        public void AgregarElemento<TObjeto>(XElement nodoPadre, string nombreNodoHijo, TObjeto objetoDeConfiguracion) where TObjeto : class
        {
            XElement nuevoElementoXML = new XElement(nombreNodoHijo);
            AsignarValores<TObjeto>(nuevoElementoXML, objetoDeConfiguracion);
            nodoPadre.Add(nuevoElementoXML);
        }


        private void AsignarValores<TObjeto>(XElement elementoXML, TObjeto myObjeto)
        {
            Type tipoObjeto = typeof(TObjeto);
            PropertyInfo[] propiedades = tipoObjeto.GetProperties();
            foreach (PropertyInfo propiedad in propiedades)
            {
                XElement elementoHijo = new XElement(propiedad.Name.ToString());
                elementoHijo.Add((propiedad.GetValue(myObjeto, null) == null ? string.Empty : propiedad.GetValue(myObjeto, null)));
                elementoXML.Add(elementoHijo);
            }
        }


    }
}
