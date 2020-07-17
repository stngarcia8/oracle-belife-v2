using System;
using BeLife.Vista.Controles.MsgBox;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Windows.Forms;

namespace BeLife.Vista.Comandos
{
    public abstract class CmdCargarComboBox
    {

        // Miembros.
        protected readonly ComboBox myComboBox;
        protected readonly Form myForm;
        private bool ocurrioError;


        // Propiedades.
        public bool OcurrioError{get { return this.ocurrioError; } }


        // Constructor.
        protected CmdCargarComboBox(Form myForm, ComboBox myComboBox)
        {
            this.myForm = myForm;
            this.myComboBox = myComboBox;
            this.ocurrioError = false;
        }


        // metodo que prepara el control con los datos.
        protected void PrepararControl(string displayMember, string valueMember)
        {
            this.myComboBox.DisplayMember = displayMember;
            this.myComboBox.ValueMember = valueMember;
            this.myComboBox.EndUpdate();
        }


        // Metodo abstracto para obtener datos del combobox.
        protected abstract void ObtenerDatos();


        // Metodo que muestra el error ocurrido en tiempo de carga de los datos.
        protected void MostrarMensajeDeError(Exception ex)
        {
            this.ocurrioError = true;
            string mensajeError = ex.Source.ToString() + " - " + ex.Message.ToString();
            MsgBox.Show(this.myForm, mensajeError, StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }




    }
}
