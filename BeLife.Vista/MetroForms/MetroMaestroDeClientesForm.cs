using System;
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
    public partial class MetroMaestroDeClientesForm : MetroForm
    {

        // Miembros y propiedades.
        #region "Miembros y propiedades."

        private TipoGrabacion accionGrabar;

        public string RutExterno { get; set; }
        public bool IsChildForm { get; set; }
        public bool HayCambios { get; set; }
        public EstadoFormulario EstadoForm { get; set; }
        public TipoGrabacion AccionGrabar { get { return this.accionGrabar; } set { this.accionGrabar = value; } }

        #endregion


        // Manejo del formulario.
        #region "Manejo del formulario."

        public MetroMaestroDeClientesForm(MetroThemeStyle myStyle)
        {
            InitializeComponent();
            this.formularioMetroStyleManager.Theme = myStyle;
            this.StyleManager = formularioMetroStyleManager;
            Configurador myConfigurador = Configurador.Crear();
            this.ayudaMetroLabel.Visible = (myConfigurador.ModoVisualizacion.AyudaLateral.Equals("True") ? true : false);
            this.ayudaMetroLabel.Text = StringResources.Ayuda_MaestroDeClientes;
        }

        private void MetroMaestroDeClientesForm_Activated(object sender, EventArgs e)
        {
            this.rutTextBox.Focus();
        }

        private void MetroMaestroDeClientesForm_Load(object sender, EventArgs e)
        {
            this.cargarCombos();
            this.nacimientoDateTimePicker.MaxDate = DateTime.Today.AddDays(1);
            this.rutTextBox.Text = string.Empty;
            this.activarControles();
            this.formularioMetroToolTip.SetToolTip(this.formularioPictureBox, StringResources.ToolTip_MaestroDeClientes);
            if (this.IsChildForm && !string.IsNullOrEmpty(this.RutExterno))
            {
                this.rutTextBox.Text = this.RutExterno;
                this.BuscarInformacionDeCliente();
            }
        }

        #endregion



        // Manejo de los botones de acciones.
        #region "Manejo de los botones de acciones."

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            this.NuevoCliente();
        }


        private void editarButton_Click(object sender, EventArgs e)
        {
            this.EditarCliente();
        }


        private void eliminarButton_Click(object sender, EventArgs e)
        {
            this.EliminarCliente();
        }


        private void cerrarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



        // Manejo de los botones.
        #region "Manejo de los botones."

        private void grabarButton_Click(object sender, EventArgs e)
        {
            this.HayCambios = false;
            if (!this.validarControles()) return;
            if (!this.GrabarCliente()) return;
            if (this.IsChildForm)
            {
                this.HayCambios = true;
                this.Close();
                return;
            }
            this.EstadoForm = EstadoFormulario.Buscar;
            this.activarControles();
        }


        private void cancelarButton_Click(object sender, EventArgs e)
        {
            if (this.IsChildForm)
            {
                this.HayCambios = false;
                this.Close();
                return;
            }
            this.rutTextBox.Text = string.Empty;
            this.EstadoForm = EstadoFormulario.Buscar;
            this.activarControles();
        }


        private void buscarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.rutTextBox.Text))
            {
                this.abrirListaDeClientes(true);
                if (string.IsNullOrEmpty(this.rutTextBox.Text)) return;
            }
            if (!this.ValidaRut()) return;
            this.BuscarInformacionDeCliente();
        }


        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.EstadoForm = EstadoFormulario.Buscar;
            this.activarControles();
            this.rutTextBox.Focus();
        }

        #endregion



        // Metodos del formulario.
        #region "Metodos del formulario."

        private void NuevoCliente()
        {
            this.EstadoForm = EstadoFormulario.Crear;
            this.accionGrabar = TipoGrabacion.Agregar;
            this.activarControles();
        }


        private void EditarCliente()
        {
            this.EstadoForm = EstadoFormulario.Editar;
            this.accionGrabar = TipoGrabacion.Actualizar;
            this.activarControles();
        }


        private void cargarCombos()
        {
            var myCommandEstadoCivil = CmdCargarComboEstadoCivil.crear(this, this.estadoCivilComboBox);
            myCommandEstadoCivil.Ejecutar();
            var myCommandSexo = CmdCargarComboSexo.crear(this, this.sexoComboBox);
            myCommandSexo.Ejecutar();
        }


        // Metodo para activar o desactivar controles segun modo del formulario.
        private void activarControles()
        {
            if (this.EstadoForm == EstadoFormulario.Buscar) this.controlesModoBusqueda();
            if (this.EstadoForm == EstadoFormulario.Crear) this.controlesModoCrear();
            if (this.EstadoForm == EstadoFormulario.Editar) this.controlesModoEditar();
        }


        private void controlesModoBusqueda()
        {
            this.accionGrabar = TipoGrabacion.Nada;
            this.habilitarControles(false);
            this.LimpiarControles();
            this.HabilitarMenus(false);
            this.rutTextBox.Enabled = true;
            this.nuevoButton.Visible = true;
            this.grabarButton.Visible = false;
            this.cancelarButton.Visible = false;
            this.textoMetroLabel.Text = StringResources.MaestroClientes_MensajeModoBusqueda; ;
            this.rutTextBox.Focus();
            FijarImagenDeAccion(Properties.Resources.ClientSearch, StringResources.MaestroClientes_MensajeModoBusqueda);
        }

        private void FijarImagenDeAccion(Image myImagen, string myToolTip)
        {
            this.accionPictureBox.Image = myImagen;
            this.formularioMetroToolTip.SetToolTip(this.accionPictureBox, myToolTip);
        }

        private void controlesModoCrear()
        {
            this.habilitarControles(true);
            this.LimpiarControles();
            this.HabilitarMenus(false);
            this.grabarButton.Visible = true;
            this.grabarButton.Enabled = false;
            this.cancelarButton.Visible = true;
            this.textoMetroLabel.Text = StringResources.MaestroClientes_MensajeModoNuevoCliente;
            this.rutTextBox.Focus();
            FijarImagenDeAccion(Properties.Resources.ClientAdd, StringResources.MaestroClientes_MensajeModoNuevoCliente);
        }


        private void controlesModoEditar()
        {
            this.habilitarControles(true);
            this.HabilitarMenus(false);
            this.rutTextBox.Enabled = false;
            this.grabarButton.Visible = true;
            this.grabarButton.Enabled = true;
            this.cancelarButton.Visible = true;
            this.textoMetroLabel.Text = string.Format(StringResources.MaestroClientes_MensajeModoEdicion, this.nombreTextBox.Text + " " + this.apellidoTextBox.Text);
            this.nombreTextBox.Focus();
            FijarImagenDeAccion(Properties.Resources.ClientUpdate, StringResources.MaestroClientes_MensajeModoEdicion);
        }


        private void LimpiarControles()
        {
            this.rutTextBox.Text = string.Empty;
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.nacimientoDateTimePicker.Value = DateTime.Now;
            this.sexoComboBox.SelectedIndex = 0;
            this.estadoCivilComboBox.SelectedIndex = 0;
            this.contratosDataGridView.DataSource = null;
            this.cantidadContratosLabel.Text = string.Empty;
        }


        private void habilitarControles(bool estado)
        {
            this.rutTextBox.Enabled = estado;
            this.nombreTextBox.Enabled = estado;
            this.apellidoTextBox.Enabled = estado;
            this.nacimientoDateTimePicker.Enabled = estado;
            this.sexoComboBox.Enabled = estado;
            this.estadoCivilComboBox.Enabled = estado;
        }


        private void HabilitarMenus(bool estado)
        {
            this.nuevoButton.Visible = estado;
            this.editarButton.Visible = estado;
            this.eliminarButton.Visible = estado;
        }


        private void abrirListaDeClientes(bool esUnaBusqueda)
        {
            MetroListadoDeClientesForm myForm = new MetroListadoDeClientesForm(this.StyleManager.Theme);
            myForm.IsSearch = esUnaBusqueda;
            CmdAbrirFormulario myCommand = CmdAbrirFormulario.Crear(myForm);
            myCommand.Ejecutar();
            if (esUnaBusqueda) this.rutTextBox.Text = myForm.RutCliente;
        }


        private bool validarControles()
        {
            var myCommand = CmdValidarEntradas.crear(this);
            myCommand.ValidarVacio(this.rutTextBox, "rut");
            if (!myCommand.FalloValidacion) myCommand.ValidarRut(this.rutTextBox);
            if (!myCommand.FalloValidacion) myCommand.ValidarVacio(this.nombreTextBox, "nombre cliente");
            if (!myCommand.FalloValidacion) myCommand.ValidarVacio(this.apellidoTextBox, "apellido cliente");
            if (!myCommand.FalloValidacion) myCommand.ValidarEdad(this.nacimientoDateTimePicker);
            if (!myCommand.FalloValidacion) myCommand.ValidarSeleccionComboBox(this.sexoComboBox, "sexo");
            if (!myCommand.FalloValidacion) myCommand.ValidarSeleccionComboBox(this.estadoCivilComboBox, "estado civil");
            return !myCommand.FalloValidacion;
        }


        private bool GrabarCliente()
        {
            if (this.accionGrabar == TipoGrabacion.Nada) return false;
            Cliente myCliente = Cliente.Crear();
            myCliente.Rut = this.rutTextBox.Text.ToString().Trim().ToUpper();
            myCliente.Nombre = this.nombreTextBox.Text.ToString().Trim().ToUpper();
            myCliente.Apellido = this.apellidoTextBox.Text.ToString().Trim().ToUpper();
            myCliente.Nacimiento = this.nacimientoDateTimePicker.Value;
            myCliente.IdSexo = int.Parse(this.sexoComboBox.SelectedValue.ToString());
            myCliente.IdEstadoCivil = int.Parse(this.estadoCivilComboBox.SelectedValue.ToString());
            var myCommand = CmdGrabarCliente.Crear(myCliente, this.accionGrabar);
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


        private bool ValidaRut()
        {
            var myCommand = CmdValidarEntradas.crear(this);
            myCommand.ValidarVacio(this.rutTextBox, "rut cliente");
            myCommand.ValidarRut(this.rutTextBox);
            return !myCommand.FalloValidacion;
        }


        private void BuscarInformacionDeCliente()
        {
            var myCommand = CmdBuscarCliente.Crear(this.rutTextBox.Text.ToString().Trim().ToUpper());
            myCommand.Ejecutar();
            if (this.EstadoForm == EstadoFormulario.Crear)
            {
                if (myCommand.fueEncontrado)
                {
                    MsgBox.Show(this, StringResources.MaestroClientes_MensajeRutExistente, StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.grabarButton.Enabled = false;
                    this.rutTextBox.Focus();
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
                MsgBox.Show(this, StringResources.MaestroClientes_MensajeRutNoExiste, StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.asignarValorEnControles(myCommand.MyCliente);
            this.CargarContratosDelCliente();
            this.habilitarMenusDeEdicion();
        }


        private void asignarValorEnControles(DtoCliente myCliente)
        {
            this.nombreTextBox.Text = myCliente.Nombre;
            this.apellidoTextBox.Text = myCliente.Apellido;
            this.nacimientoDateTimePicker.Value = myCliente.Fecha;
            this.sexoComboBox.Text = myCliente.Sexo;
            this.estadoCivilComboBox.Text = myCliente.EstadoCivil;
        }


        private void CargarContratosDelCliente()
        {
            var myCommand = CmdCargarGrillaContratosCliente.Crear(this, this.contratosDataGridView, this.rutTextBox.Text);
            myCommand.Ejecutar();
            this.cantidadContratosLabel.Text = myCommand.TextoResultado;
        }


        private void habilitarMenusDeEdicion()
        {
            this.HabilitarMenus(true);
            this.nuevoButton.Visible = false;
        }


        // Metodo para eliminar cliente.
        private void EliminarCliente()
        {
            string nombreCliente = this.nombreTextBox.Text + " " + this.apellidoTextBox.Text;
            if (this.contratosDataGridView.Rows.Count > 0)
            {
                MsgBox.Show(this, string.Format(StringResources.MaestroClientes_Eliminar_NoPuedeEliminarCliente, nombreCliente, this.contratosDataGridView.Rows.Count.ToString()), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult myResult = MsgBox.Show(this, string.Format(StringResources.MaestroClientes_Eliminar_PreguntaSiQuiereEliminar, nombreCliente), StringResources.TituloMensajes_Atencion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (myResult == DialogResult.No) return;
            this.HayCambios = false;
            this.RutExterno = string.Empty;
            Cliente myCliente = Cliente.Crear();
            myCliente.Rut = this.rutTextBox.Text.ToString().Trim().ToUpper();
            myCliente.Nombre = this.nombreTextBox.Text.ToString().Trim().ToUpper();
            myCliente.Apellido = this.apellidoTextBox.Text.ToString().Trim().ToUpper();
            var myCommand = CmdGrabarCliente.Crear(myCliente, TipoGrabacion.Eliminar);
            myCommand.Ejecutar();
            if (myCommand.OcurrioError)
            {
                MsgBox.Show(this, myCommand.MensajeError.ToString(), StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MsgBox.Show(this, myCommand.MensajeGrabacion.ToString(), StringResources.TituloMensajes_Atencion, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (this.IsChildForm)
            {
                this.HayCambios = true;
                this.Close();
                return;
            }
            this.EstadoForm = EstadoFormulario.Buscar;
            this.activarControles();
        }





        #endregion


    }
}
