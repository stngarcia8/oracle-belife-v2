using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BeLife.Aplicacion.Configuracion;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Controlador.Comandos;
using BeLife.Controlador.Enumeraciones;
using BeLife.Modelo.Clases;
using BeLife.Modelo.Dto;
using BeLife.Vista.Comandos;
using BeLife.Vista.Controles.MsgBox;
using MetroFramework;
using MetroFramework.Forms;

namespace BeLife.Vista.MetroForms
{
    public partial class MetroMaestroDeContratosForm : MetroForm
    {

        // Miembros y propiedades.
        #region "Miembros y propiedades."

        private TipoGrabacion accionGrabar;
        private IList<DtoPlan> myPlanList;

        public string NumeroContratoExterno { get; set; }
        public string RutClienteExterno { get; set; }
        public bool IsChildForm { get; set; }
        public bool HayCambios { get; set; }
        public EstadoFormulario EstadoForm { get; set; }
        public TipoGrabacion AccionGrabar { get { return this.accionGrabar; } set { this.accionGrabar = value; } }

        #endregion



        // Manejo del formulario.
        #region "Manejo del formulario."


        public MetroMaestroDeContratosForm(MetroThemeStyle myStyle)
        {
            InitializeComponent();
            this.formularioMetroStyleManager.Theme = myStyle;
            this.StyleManager = formularioMetroStyleManager;
            Configurador myConfigurador = Configurador.Crear();
            this.ayudaMetroLabel.Visible = (myConfigurador.ModoVisualizacion.AyudaLateral.Equals("True") ? true : false);
            this.ayudaMetroLabel.Text = StringResources.Ayuda_MaestroDeContratos;
        }


        private void MetroMaestroDeContratosForm_Activated(object sender, EventArgs e)
        {
            this.numeroContratoTextBox.Focus();
        }


        private void MetroMaestroDeContratosForm_Load(object sender, EventArgs e)
        {
            this.cargarComboDePlanes();
            this.planComboBox.SelectedIndex = 0;
            this.CargarControlesDeValorDePrima();
            this.RealizarCalculoDePrima();
            this.numeroContratoTextBox.Text = string.Empty;
            this.ActivarControles();
            this.formularioMetroToolTip.SetToolTip(this.formularioPictureBox, StringResources.ToolTip_MaestroDeContratos);
            if (this.IsChildForm && !string.IsNullOrEmpty(this.NumeroContratoExterno))
            {
                this.nuevoButton.Visible = false;
                this.numeroContratoTextBox.Text = this.NumeroContratoExterno;
                this.BuscarInformacionDeContrato();
                return;
            }
        }

        #endregion



        // Manejo de los botones de accion.
        #region "Manejo de los botones de accion."

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            this.NuevoContrato();
            this.rutTextBox.Focus();
        }


        private void editarButton_Click(object sender, EventArgs e)
        {
            this.EditarContrato();
        }


        private void eliminarButton_Click(object sender, EventArgs e)
        {
            this.TerminarContrato();
        }


        private void cerrarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



        //  Manejo de los botones.
        #region "Manejo de los botones."

        private void numeroContratoButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.numeroContratoTextBox.Text))
            {
                this.AbrirListaDeContratos(true);
                if (string.IsNullOrEmpty(this.numeroContratoTextBox.Text)) return;
            }
            this.BuscarInformacionDeContrato();
        }


        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.EstadoForm = EstadoFormulario.Buscar;
            this.ActivarControles();
            this.numeroContratoTextBox.Text = string.Empty;
            this.numeroContratoTextBox.Focus();
        }


        private void rutButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.rutTextBox.Text))
            {
                this.AbrirListaDeClientes(true);
                if (string.IsNullOrEmpty(this.rutTextBox.Text)) return;
            }
            if (!this.ValidaRut()) return;
            this.BuscarInformacionDeCliente();
        }


        private void grabarButton_Click(object sender, EventArgs e)
        {
            this.HayCambios = false;
            if (!this.ValidarEntradasDeControles()) return;
            if (!this.GrabarContrato()) return;
            if (this.IsChildForm)
            {
                this.HayCambios = true;
                this.Close();
                return;
            }
            this.numeroContratoTextBox.Text = string.Empty;
            this.EstadoForm = EstadoFormulario.Buscar;
            this.ActivarControles();
            this.numeroContratoTextBox.Focus();
        }


        private void cancelarButton_Click(object sender, EventArgs e)
        {
            if (this.IsChildForm)
            {
                this.HayCambios = false;
                this.Close();
                return;
            }
            this.numeroContratoTextBox.Text = string.Empty;
            this.EstadoForm = EstadoFormulario.Buscar;
            this.ActivarControles();
            this.numeroContratoTextBox.Focus();
        }

        #endregion



        // Manejo de planes.
        #region "Manejo de planes."

        private void planComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarControlesDeValorDePrima();
        }

        #endregion



        // Manejo del control de inicio de vigencia.
        #region "Manejo del control de inicio de vigencia."

        private void inicioVigenciaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.CalcularTerminoVigencia();
        }

        #endregion



        // Metodos del formulario.
        #region "Metodos del formulario."

        private void NuevoContrato()
        {
            this.EstadoForm = EstadoFormulario.Crear;
            this.accionGrabar = TipoGrabacion.Agregar;
            this.ActivarControles();
        }


        private void EditarContrato()
        {
            this.EstadoForm = EstadoFormulario.Editar;
            this.accionGrabar = TipoGrabacion.Actualizar;
            this.ActivarControles();
        }


        private void GeneraNumeroDeContrato()
        {
            DateTime fecha = DateTime.Now;
            string year = fecha.Year.ToString();
            string month = (fecha.Month < 10 ? "0" + fecha.Month.ToString() : fecha.Month.ToString());
            string day = (fecha.Day < 10 ? "0" + fecha.Day.ToString() : fecha.Day.ToString());
            string hour = (fecha.Hour < 10 ? "0" + fecha.Hour.ToString() : fecha.Hour.ToString());
            string minute = (fecha.Minute < 10 ? "0" + fecha.Minute.ToString() : fecha.Minute.ToString());
            string seconds = (fecha.Second < 10 ? "0" + fecha.Second.ToString() : fecha.Second.ToString());
            this.numeroContratoTextBox.Text = year + month + day + hour + minute + seconds;
        }


        private void restringirFechas()
        {
            DateTime fecha = DateTime.Now;
            this.inicioVigenciaDateTimePicker.Value = fecha;
            this.inicioVigenciaDateTimePicker.MinDate = fecha;
            this.inicioVigenciaDateTimePicker.MaxDate = fecha.AddMonths(1);
        }


        private void cargarComboDePlanes()
        {
            CmdCargarComboPlan myCommand = CmdCargarComboPlan.Crear(this, this.planComboBox);
            myCommand.Ejecutar();
            myPlanList = myCommand.PlanList;
        }


        private void ActivarControles()
        {
            if (this.EstadoForm == EstadoFormulario.Buscar) this.controlesModoBusqueda();
            if (this.EstadoForm == EstadoFormulario.Crear) this.controlesModoCrear();
            if (this.EstadoForm == EstadoFormulario.Editar) this.controlesModoEditar();
        }


        private void controlesModoBusqueda()
        {
            this.accionGrabar = TipoGrabacion.Nada;
            this.habilitarControles(false);
            this.planComboBox.Visible = false;
            this.planTextBox.Visible = true;
            this.LimpiarControles();
            this.HabilitarMenus(false);
            this.numeroContratoTextBox.Enabled = true;
            this.numeroContratoButton.Enabled = true;
            this.nuevoButton.Visible = true;
            this.grabarButton.Visible = false;
            this.cancelarButton.Visible = false;
            this.FijarImagen(Properties.Resources.ContractSearch, StringResources.MaestroContratos_MensajeModoBusqueda);
            this.textoMetroLabel.Text = StringResources.MaestroContratos_MensajeModoBusqueda;
            this.numeroContratoTextBox.Focus();
        }


        private void FijarImagen(Image myImagen, string myToolTip)
        {
            this.accionPictureBox.Image = myImagen;
            this.formularioMetroToolTip.SetToolTip(this.accionPictureBox, myToolTip);
        }


        private void controlesModoCrear()
        {
            this.habilitarControles(true);
            this.LimpiarControles();
            this.planTextBox.Visible = false;
            this.planComboBox.Visible = true;
            this.contratoVigenteCheckBox.Checked = true;
            this.numeroContratoTextBox.Enabled = false;
            this.numeroContratoButton.Enabled = false;
            this.HabilitarMenus(false);
            this.grabarButton.Visible = true;
            this.grabarButton.Enabled = true;
            this.cancelarButton.Visible = true;
            this.FijarImagen(Properties.Resources.ContractAdd, StringResources.MaestroContratos_MensajeModoNuevoContrato);
            this.textoMetroLabel.Text = StringResources.MaestroContratos_MensajeModoNuevoContrato;
            this.GeneraNumeroDeContrato();
            this.restringirFechas();
            this.CalcularTerminoVigencia();
            this.numeroContratoTextBox.Focus();
        }


        private void controlesModoEditar()
        {
            this.habilitarControles(true);
            this.HabilitarMenus(false);
            this.numeroContratoTextBox.Enabled = false;
            this.planTextBox.Visible = false;
            this.planComboBox.Visible = true;
            this.grabarButton.Visible = true;
            this.grabarButton.Enabled = true;
            this.cancelarButton.Visible = true;
            this.FijarImagen(Properties.Resources.ContractUpdate, string.Format(StringResources.MaestroContratos_MensajeModoEdicion, this.nombreTextBox.Text + " " + this.apellidoTextBox.Text));
            this.textoMetroLabel.Text = string.Format(StringResources.MaestroContratos_MensajeModoEdicion, this.nombreTextBox.Text + " " + this.apellidoTextBox.Text);
            this.AjustarTiemposDeControlInicioDeVigencia(this.inicioVigenciaDateTimePicker.Value, DateTime.Today);
            this.inicioVigenciaDateTimePicker.Focus();
        }


        private void LimpiarControles()
        {
            this.LimpiarControlesCliente();
            this.rutTextBox.Text = string.Empty;
            this.planComboBox.SelectedIndex = 0;
            this.planTextBox.Text = string.Empty;
            DateTime fecha = DateTime.Now;
            this.inicioContratoTextBox.Text = fecha.ToShortDateString().ToString();
            this.terminoContratoTextBox.Text = string.Empty;
            this.AjustarTiemposDeControlInicioDeVigencia(DateTime.Today, DateTime.Today);
            this.terminoVigenciaTextBox.Text = string.Empty;
            this.contratoVigenteCheckBox.Checked = false;
            this.declaracionDeSaludCheckBox.Checked = false; ;
            this.observacionesTextBox.Text = string.Empty;
            this.CalcularTerminoVigencia();
        }


        private void AjustarTiemposDeControlInicioDeVigencia(DateTime minFechaReferencia, DateTime maxFechaReferencia)
        {
            DateTimePicker myPicker = new DateTimePicker();
            myPicker.Value = maxFechaReferencia;
            this.inicioVigenciaDateTimePicker.MinDate = myPicker.MinDate;
            this.inicioVigenciaDateTimePicker.MaxDate = myPicker.MaxDate;
            this.inicioVigenciaDateTimePicker.Value = DateTime.Now;
            this.inicioVigenciaDateTimePicker.MinDate = minFechaReferencia;
            this.inicioVigenciaDateTimePicker.MaxDate = myPicker.Value.AddMonths(1);
        }


        private void LimpiarControlesCliente()
        {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.nacimientoTextBox.Text = string.Empty;
            this.sexoTextBox.Text = string.Empty;
            this.estadoCivilTextBox.Text = string.Empty;
        }


        private void habilitarControles(bool estado)
        {
            this.HabilitarControlesDeUsuario(estado);
            this.HabilitarControlesDePlan(estado);
            this.HabilitarControlesDeContratos(estado);
        }


        private void HabilitarControlesDeUsuario(bool estado)
        {
            this.rutTextBox.Enabled = estado;
            this.nombreTextBox.Enabled = estado;
            this.apellidoTextBox.Enabled = estado;
            this.nacimientoTextBox.Enabled = estado;
            this.sexoTextBox.Enabled = estado;
            this.estadoCivilTextBox.Enabled = estado;
            this.rutButton.Enabled = estado;
        }


        private void HabilitarControlesDePlan(bool estado)
        {
            this.planComboBox.Enabled = estado;
            this.planTextBox.Enabled = estado;
            this.numeroDePolizaTextBox.Enabled = estado;
            this.valorPlanTextBox.Enabled = estado;
        }


        private void HabilitarControlesDeContratos(bool estado)
        {
            this.inicioContratoTextBox.Enabled = estado;
            this.inicioVigenciaDateTimePicker.Enabled = estado;
            this.terminoContratoTextBox.Enabled = estado;
            this.terminoVigenciaTextBox.Enabled = estado;
            this.valorBaseContratoTextBox.Enabled = estado;
            this.recargoTextBox.Enabled = estado;
            this.primaAnualTextBox.Enabled = estado;
            this.explicacionRecargoTextBox.Enabled = estado;
            this.declaracionDeSaludCheckBox.Enabled = estado;
            this.observacionesTextBox.Enabled = estado;
        }


        private void HabilitarMenus(bool estado)
        {
            this.nuevoButton.Visible = estado;
            this.editarButton.Visible = estado;
            this.eliminarButton.Visible = estado;
        }


        private void AbrirListaDeContratos(bool esUnaBusqueda)
        {
            MetroListadoDeContratosForm myForm = new MetroListadoDeContratosForm(formularioMetroStyleManager.Theme);
            myForm.IsSearch = esUnaBusqueda;
            CmdAbrirFormulario myCommand = CmdAbrirFormulario.Crear(myForm);
            myCommand.Ejecutar();
            if (esUnaBusqueda) this.numeroContratoTextBox.Text = myForm.NumeroContrato;
        }


        private void BuscarInformacionDeContrato()
        {
            var myCommand = CmdBuscarContrato.Crear(this.numeroContratoTextBox.Text.ToString().Trim().ToUpper());
            myCommand.Ejecutar();
            if (myCommand.OcurrioError)
            {
                MsgBox.Show(this, myCommand.MensajeError.ToString(), StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.EstadoForm == EstadoFormulario.Crear)
            {
                if (myCommand.fueEncontrado)
                {
                    MsgBox.Show(this, myCommand.MensajeBusqueda.ToString(), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.grabarButton.Enabled = false;
                    this.numeroContratoTextBox.Focus();
                    return;
                }
                else
                {
                    this.grabarButton.Enabled = true;
                    return;
                }
            }
            if (!myCommand.fueEncontrado)
            {
                MsgBox.Show(this, myCommand.MensajeBusqueda.ToString(), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.AsignarValorEnControlesDeContrato(myCommand.MyContrato);
            this.habilitarControles(true);
            this.rutButton.Enabled = false;
            this.rutTextBox.ReadOnly = true;
            this.HabilitarMenus(this.contratoVigenteCheckBox.Checked);
            this.nuevoButton.Visible = true;
        }


        private void AsignarValorEnControlesDeContrato(DtoContrato myContrato)
        {
            this.numeroContratoTextBox.Text = myContrato.Numero.ToString();
            this.rutTextBox.Text = myContrato.Rut.ToString();
            this.BuscarInformacionDeCliente();
            this.planComboBox.Text = myContrato.Nombre_plan.ToString();
            this.planComboBox.Visible = false;
            this.planTextBox.Text = myContrato.Nombre_plan.ToString();
            this.planTextBox.Visible = true;
            this.inicioContratoTextBox.Text = myContrato.Inicio_contrato.ToString();
            int año = int.Parse(myContrato.Inicio_vigencia.ToString().Substring(6, 4));
            int mes = int.Parse(myContrato.Inicio_vigencia.ToString().Substring(3, 2));
            int dia = int.Parse(myContrato.Inicio_vigencia.ToString().Substring(0, 2));
            DateTime myFecha = new DateTime(año, mes, dia);
            DateTime myMaxFecha = new DateTime(año + 1, mes, dia, 23, 59, 59);
            DateTime myMinFecha = new DateTime(año, mes, dia, 0, 0, 0);
            this.inicioVigenciaDateTimePicker.MaxDate = myMaxFecha;
            this.inicioVigenciaDateTimePicker.MinDate = myMinFecha;
            this.inicioVigenciaDateTimePicker.Value = myFecha;
            this.terminoContratoTextBox.Text = myContrato.Termino_contrato.ToString();
            this.terminoVigenciaTextBox.Text = myContrato.Termino_vigencia.ToString();
            this.contratoVigenteCheckBox.Checked = (myContrato.Vigente.ToLower().Equals("si") ? true : false);
            this.declaracionDeSaludCheckBox.Checked = (myContrato.Declaracion_salud.ToLower().Equals("si") ? true : false);
            this.observacionesTextBox.Text = (!string.IsNullOrEmpty(myContrato.Observaciones) ? myContrato.Observaciones.ToString() : string.Empty);
        }

        private void AbrirListaDeClientes(bool esUnaBusqueda)
        {
            MetroListadoDeClientesForm myForm = new MetroListadoDeClientesForm(formularioMetroStyleManager.Theme);
            myForm.IsSearch = esUnaBusqueda;
            CmdAbrirFormulario myCommand = CmdAbrirFormulario.Crear(myForm);
            myCommand.Ejecutar();
            if (esUnaBusqueda) this.rutTextBox.Text = myForm.RutCliente;
        }


        private bool ValidaRut()
        {
            var myCommand = CmdValidarEntradas.crear(this);
            myCommand.ValidarVacio(this.rutTextBox, "rut cliente");
            myCommand.ValidarRut(this.rutTextBox);
            return !myCommand.FalloValidacion;
        }


        private void BuscarInformacionDeCliente()
        {
            this.LimpiarControlesCliente();
            var myCommand = CmdBuscarCliente.Crear(this.rutTextBox.Text.ToString().Trim().ToUpper());
            myCommand.Ejecutar();
            if (!myCommand.fueEncontrado)
            {
                MsgBox.Show(this, StringResources.MaestroClientes_MensajeRutNoExiste, StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.AsignarValorEnControlesDeCliente(myCommand.MyCliente);
            this.RealizarCalculoDePrima();
        }


        private void AsignarValorEnControlesDeCliente(DtoCliente myCliente)
        {
            this.nombreTextBox.Text = myCliente.Nombre;
            this.apellidoTextBox.Text = myCliente.Apellido;
            this.nacimientoTextBox.Text = myCliente.Fecha.ToShortDateString();
            this.sexoTextBox.Text = myCliente.Sexo;
            this.estadoCivilTextBox.Text = myCliente.EstadoCivil;
        }


        private void RealizarCalculoDePrima()
        {
            double valPrima = (string.IsNullOrEmpty(this.valorPlanTextBox.Text) ? 0 : double.Parse(this.valorPlanTextBox.Text));
            DateTime fecha = (string.IsNullOrEmpty(this.nacimientoTextBox.Text) ? DateTime.Now : DateTime.Parse(this.nacimientoTextBox.Text));
            string sexo = (string.IsNullOrEmpty(this.sexoTextBox.Text) ? string.Empty : this.sexoTextBox.Text);
            string estadoCivil = (string.IsNullOrEmpty(this.estadoCivilTextBox.Text) ? string.Empty : this.estadoCivilTextBox.Text);
            Prima myPrima = Prima.Crear(valPrima, fecha, sexo, estadoCivil);
            this.recargoTextBox.Text = myPrima.Recargo.ToString();
            this.primaAnualTextBox.Text = myPrima.ValorTotal.ToString();
            this.explicacionRecargoTextBox.Text = myPrima.ToString();
        }


        private void CalcularTerminoVigencia()
        {
            string myDay = (this.inicioVigenciaDateTimePicker.Value.Day < 10 ? "0" + this.inicioVigenciaDateTimePicker.Value.Day.ToString() : this.inicioVigenciaDateTimePicker.Value.Day.ToString());
            string myMonth = (this.inicioVigenciaDateTimePicker.Value.Month < 10 ? "0" + this.inicioVigenciaDateTimePicker.Value.Month.ToString() : this.inicioVigenciaDateTimePicker.Value.Month.ToString());
            string myYear = (this.inicioVigenciaDateTimePicker.Value.Year + 1).ToString();
            this.terminoVigenciaTextBox.Text = myDay + "/" + myMonth + "/" + myYear;
            this.terminoContratoTextBox.Text = this.terminoVigenciaTextBox.Text;
        }


        private void CargarControlesDeValorDePrima()
        {
            this.recargoTextBox.Text = "0";
            this.primaAnualTextBox.Text = "0";
            if (this.myPlanList == null) return;
            foreach (DtoPlan plan in myPlanList)
            {
                if (plan.IdPlan.Equals(this.planComboBox.SelectedValue.ToString()))
                {
                    this.numeroDePolizaTextBox.Text = plan.PolizaActual;
                    this.valorPlanTextBox.Text = plan.PrimaBase.ToString();
                    this.valorBaseContratoTextBox.Text = plan.PrimaBase.ToString();
                }
            }
            this.RealizarCalculoDePrima();
        }


        private bool ValidarEntradasDeControles()
        {
            var myCommand = CmdValidarEntradas.crear(this);
            myCommand.ValidarVacio(this.numeroContratoTextBox, "número de contrato");
            if (!myCommand.FalloValidacion) myCommand.ValidarVacio(this.rutTextBox, "rut cliente");
            if (!myCommand.FalloValidacion) myCommand.ValidarRut(this.rutTextBox);
            if (string.IsNullOrEmpty(this.nombreTextBox.Text))
            {
                MsgBox.Show(this, StringResources.MaestroContratos_MensajeDatosClienteSinConfirmar, StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.rutTextBox.Focus();
                return false;
            }
            if (!myCommand.FalloValidacion) myCommand.ValidarSeleccionComboBox(this.planComboBox, "plan");
            if (this.accionGrabar == TipoGrabacion.Agregar && !myCommand.FalloValidacion)
            {
                myCommand.ValidarExistenciaDeVigenciaDePlan(this.rutTextBox.Text, this.planComboBox.SelectedValue.ToString());
            }
            return !myCommand.FalloValidacion;
        }


        private bool GrabarContrato()
        {
            if (this.accionGrabar == TipoGrabacion.Nada) return false;
            Contrato myContrato = Contrato.Crear();
            myContrato.NumeroContrato = this.numeroContratoTextBox.Text.Trim();
            myContrato.FechaInicioContrato = DateTime.Parse(this.inicioContratoTextBox.Text.Trim());
            myContrato.FechaTerminoContrato = DateTime.Parse(this.terminoContratoTextBox.Text.Trim());
            myContrato.RutCliente = this.rutTextBox.Text.Trim();
            myContrato.IdPlan = this.planComboBox.SelectedValue.ToString().Trim();
            myContrato.FechaInicioDeVigencia = this.inicioVigenciaDateTimePicker.Value;
            myContrato.FechaTerminoDeVigencia = DateTime.Parse(this.terminoVigenciaTextBox.Text);
            myContrato.VigenciaContrato = (this.contratoVigenteCheckBox.Checked ? 1 : 0);
            myContrato.DeclaracionDeSalud = (this.declaracionDeSaludCheckBox.Checked ? 1 : 0);
            myContrato.PrimaAnual = double.Parse(this.primaAnualTextBox.Text.Trim());
            myContrato.PrimaMensual = double.Parse(this.valorBaseContratoTextBox.Text.Trim());
            myContrato.Observaciones = this.observacionesTextBox.Text.Trim();
            CmdGrabarContrato myCommand = CmdGrabarContrato.Crear(myContrato, this.accionGrabar);
            myCommand.Ejecutar();
            if (myCommand.OcurrioError)
            {
                MsgBox.Show(this, myCommand.MensajeError.ToString(), StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MsgBox.Show(this, myCommand.MensajeGrabacion.ToString(), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return myCommand.fueAlmacenado;
        }


        private void TerminarContrato()
        {
            DialogResult myResult = MsgBox.Show(this, string.Format(StringResources.MaestroContratos_MensajePreguntaDETerminoDeContrato, this.numeroContratoTextBox.Text, this.nombreTextBox.Text + " " + this.apellidoTextBox.Text, this.planComboBox.Text), StringResources.TituloMensajes_Atencion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (myResult == DialogResult.No) return;
            DateTime fecha = DateTime.Today;
            this.terminoContratoTextBox.Text = fecha.ToShortDateString().ToString();
            this.contratoVigenteCheckBox.Checked = false;
            this.grabarButton.Visible = true;
            this.cancelarButton.Visible = true;
            this.accionGrabar = TipoGrabacion.Actualizar;
            MsgBox.Show(this, string.Format(StringResources.MaestroContratos_MensajeCambioFechaDETerminoDeContrato, fecha.ToShortDateString().ToString()), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        #endregion








    }
}
