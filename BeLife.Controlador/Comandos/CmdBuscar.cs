using System;

namespace BeLife.Controlador.Comandos
{
    public abstract class CmdBuscar
    {

        // Miembros.
        protected readonly string textoQueBuscar;
        protected readonly string textoQueBuscar2;

        // Propiedades.
        public bool fueEncontrado { get; set; }
        public string MensajeBusqueda { get; set; }
        public string MensajeError { get; set; }
        public bool OcurrioError { get; set; }


        // Constructores.
        protected CmdBuscar(string textoQueBuscar)
        {
            this.textoQueBuscar = textoQueBuscar;
            this.textoQueBuscar2 = string.Empty;
            this.fueEncontrado = false;
            this.MensajeBusqueda = string.Empty;
            this.MensajeError = string.Empty;
            this.OcurrioError = false;
        }


        protected CmdBuscar(string textoQueBuscar, string textoQueBuscar2)
        {
            this.textoQueBuscar = textoQueBuscar;
            this.textoQueBuscar2 = textoQueBuscar2;
            this.fueEncontrado = false;
            this.MensajeBusqueda = string.Empty;
            this.MensajeError = string.Empty;
            this.OcurrioError = false;
        }


        // Metodo abstracto para obtener datos del objeto que este buscando.
        protected abstract bool ObtenerDatos();


        protected void MarcarError(Exception ex)
        {
            this.MensajeError = ex.Source.ToString() + " - " + ex.Message.ToString();
            this.OcurrioError = true;
            this.fueEncontrado = false;
        }





    }
}
