using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BeLife.Controlador.Comandos;

namespace BeLife.Vista.Comandos
{
    public class ComandoValidarEntradas
    {

        // Miembros privados.
        public bool FalloValidacion { get; set; }


        // Constructor.
        private ComandoValidarEntradas()
        {
            this.FalloValidacion = true;
        }


        // metodo constructor del objeto.
        public static ComandoValidarEntradas crear()
        {
            return new ComandoValidarEntradas();
        }


        // Validar campo vacio.
        public void ValidarVacio(TextBox myTextBox, string campo)
        {
            string texto = myTextBox.Text.Trim().ToString();
            if (string.IsNullOrEmpty(texto))
            {
                this.FalloValidacion = true;
                MessageBox.Show("El campo " + campo + " no puede quedar vacio.", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                myTextBox.Focus();
                return;
            }
            this.FalloValidacion = false;
        }



        // Validar edad.
        public void ValidarEdad(DateTimePicker dtPicker)
        {
            int diferencia = DateTime.Now.Year - dtPicker.Value.Year;
            if (diferencia < 18)
            {
                this.FalloValidacion = true;
                MessageBox.Show("El cliente debe tener al menos 18 años de edad.", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtPicker.Focus();
                return;
            }
            this.FalloValidacion = false;
        }


        // Validar valor base del seguro.
        public void ValidarValorSeguro(TextBox textoValorBase)
        {
            double valor = 0;
            try
            {
                valor = double.Parse(textoValorBase.Text.ToString().Trim());
                if (valor <= 0)
                {
                    this.FalloValidacion = true;
                    MessageBox.Show("El valor base del plan   debe ser mayor a 0 UF.", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textoValorBase.Focus();
                    return;
                }
                this.FalloValidacion = false;
            }
            catch
            {
                this.FalloValidacion = true;
                MessageBox.Show("El campo valor base admite solo numeros.", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textoValorBase.Focus();
            }
        }



        // Validar rut.
        public void ValidarRut(TextBox RutTextBox)
        {
            if (string.IsNullOrEmpty(RutTextBox.Text)) return;
            string rut = RutTextBox.Text.Replace(".", "").ToUpper();
            string[] rutTemp = rut.Split('-');
            if (!verificaFormatoRut(RutTextBox.Text))
            {
                this.FalloValidacion = true;
                MessageBox.Show("Formato del rut incorrecto, ejemplo 12345678-9.", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RutTextBox.Focus();
                return;
            }
            string verificadorTemp = this.obtenerDigitoVerificador(int.Parse(rutTemp[0].ToString()));
            if (rutTemp[1].ToString() != verificadorTemp)
            {
                this.FalloValidacion = true;
                MessageBox.Show("El rut ingresado no es correcto.", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        public void ValidarSeleccionComboBox(ComboBox myComboBox, string campo)
        {
            if (myComboBox.SelectedIndex == 0)
            {
                this.FalloValidacion = true;
                MessageBox.Show("Debe seleccionar un " + campo + ".", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show(myCommand.MensajeError.ToString(), "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.FalloValidacion = true;
                return;
            }
            if (myCommand.fueEncontrado)
            {
                MessageBox.Show(myCommand.MensajeBusqueda.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.FalloValidacion = true;
                return;
            }
            this.FalloValidacion = false;
        }




    }
}
