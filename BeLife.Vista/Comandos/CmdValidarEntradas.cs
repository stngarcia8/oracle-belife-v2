using System;
using System.Text;
using BeLife.Vista.Controles.MsgBox;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BeLife.Controlador.Comandos;
using BeLife.Aplicacion.Idiomas.Localizacion;

namespace BeLife.Vista.Comandos
{
    public class CmdValidarEntradas
    {

        // Miembros privados.
        public bool FalloValidacion { get; set; }
        private readonly MetroForm myForm;


        // Constructor.
        private CmdValidarEntradas(MetroForm myForm)
        {
            this.myForm = myForm;
            this.FalloValidacion = true;
        }


        // metodo constructor del objeto.
        public static CmdValidarEntradas crear(MetroForm myForm)
        {
            return new CmdValidarEntradas(myForm);
        }


        // Validar campo vacio.
        public void ValidarVacio(MetroTextBox myTextBox, string campo)
        {
            string texto = myTextBox.Text.Trim().ToString();
            if (string.IsNullOrEmpty(texto))
            {
                this.FalloValidacion = true;
                MsgBox.Show(this.myForm, string.Format(StringResources.MensajeValidacion_CampoVacio, campo), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                myTextBox.Focus();
                return;
            }
            this.FalloValidacion = false;
        }


        // Validar edad.
        public void ValidarEdad(MetroDateTime dtPicker)
        {
            int diferencia = DateTime.Now.Year - dtPicker.Value.Year;
            if (diferencia < 18)
            {
                this.FalloValidacion = true;
                MsgBox.Show(this.myForm, StringResources.MensajeValidacion_MenorDeEdad, StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtPicker.Focus();
                return;
            }
            this.FalloValidacion = false;
        }


        // Validar valor base del seguro.
        public void ValidarValorSeguro(MetroTextBox textoValorBase)
        {
            double valor = 0;
            try
            {
                valor = double.Parse(textoValorBase.Text.ToString().Trim());
                if (valor <= 0)
                {
                    this.FalloValidacion = true;
                    MsgBox.Show(this.myForm,StringResources.MensajeValidacion_ValorBaseMenorQueCero, StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textoValorBase.Focus();
                    return;
                }
                this.FalloValidacion = false;
            }
            catch
            {
                this.FalloValidacion = true;
                MsgBox.Show(this.myForm,StringResources.MensajeValidacion_SoloNumeros, StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textoValorBase.Focus();
            }
        }


        // Validar rut.
        public void ValidarRut(MetroTextBox RutTextBox)
        {
            if (string.IsNullOrEmpty(RutTextBox.Text)) return;
            string rut = RutTextBox.Text.Replace(".", "").ToUpper();
            string[] rutTemp = rut.Split('-');
            if (!verificaFormatoRut(RutTextBox.Text))
            {
                this.FalloValidacion = true;
                MsgBox.Show(this.myForm,StringResources.MensajeValidacion_RutIncorrecto, StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                RutTextBox.Focus();
                return;
            }
            string verificadorTemp = this.obtenerDigitoVerificador(int.Parse(rutTemp[0].ToString()));
            if (rutTemp[1].ToString() != verificadorTemp)
            {
                this.FalloValidacion = true;
                MsgBox.Show(this.myForm,StringResources.MensajeValidacion_RutIncorrecto, StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                RutTextBox.Focus();
                return;
            }
            this.FalloValidacion = false;
        }


        // Metodo que evalúa el formato del rut.
        private bool verificaFormatoRut(string rut)
        {
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            return expresion.IsMatch(rut);
        }


        // Metodo que obtiene el digito segun modulo 11.
        private string obtenerDigitoVerificador(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8) multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }


        // Validar seleccion de un combobox.
        public void ValidarSeleccionComboBox(MetroComboBox myComboBox, string campo)
        {
            if (myComboBox.SelectedIndex == 0)
            {
                this.FalloValidacion = true;
                MsgBox.Show(this.myForm,string.Format(StringResources.MensajeValidacion_SeleccionCombobox,campo ), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                myComboBox.Focus();
                return;
            }
            this.FalloValidacion = false;
        }


        public void ValidarExistenciaDeVigenciaDePlan(string rutCliente, string idPlan)
        {
            CmdBuscarContratoVigente myCommand = CmdBuscarContratoVigente.Crear(rutCliente, idPlan);
            myCommand.Ejecutar();
            if (myCommand.OcurrioError)
            {
                MsgBox.Show(this.myForm,myCommand.MensajeError.ToString(), StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.FalloValidacion = true;
                return;
            }
            if (myCommand.fueEncontrado)
            {
                MsgBox.Show(this.myForm,myCommand.MensajeBusqueda.ToString(), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.FalloValidacion = true;
                return;
            }
            this.FalloValidacion = false;
        }




    }
}
