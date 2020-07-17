using System;
using System.Windows.Forms;
using BeLife.Aplicacion.Configuracion;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Controlador.Enumeraciones;
using BeLife.Vista.Comandos;
using MetroFramework;
using MetroFramework.Forms;


namespace BeLife.Vista.MetroForms
{
    public partial class MetroListadoDeClientesForm : MetroForm
    {

        // Miembros.
        private Configurador myConfigurador;



        // Propiedades.
        #region "Propiedades."

        public string RutCliente { get; set; }
        public bool IsSearch { get; set; }

        #endregion



        // Manejo del formulario.
        #region "Manejo del formulario."

        public MetroListadoDeClientesForm(MetroThemeStyle myStyle)
        {
            InitializeComponent();
            this.formularioMetroStyleManager.Theme = myStyle;
            this.StyleManager = formularioMetroStyleManager;
            this.formularioMetroToolTip.SetToolTip(this.formularioPictureBox, StringResources.ToolTip_ListadoDeClientes);
        }


        private void MetroListadoDeClientesForm_Load(object sender, EventArgs e)
        {
            myConfigurador = Configurador.Crear();
            this.ayudaMetroLabel.Text = StringResources.Ayuda_ListadoClientes;
            this.ayudaMetroLabel.Visible = (myConfigurador.ModoVisualizacion.AyudaLateral.Equals("True") ? true : false);
            this.CargarComboFiltros();
            this.listadoDataGridView.DataSource = null;
            this.aceptarMetroButton.Visible = this.IsSearch;
            this.formularioMetroContextMenu.Enabled = !this.IsSearch;
            this.formularioMetroContextMenu.Visible = false;
        }

        #endregion



        // Manejo del menu contextual.
        #region "Manejo del menu contextual."

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirMaestroClientesModoChild(EstadoFormulario.Crear, TipoGrabacion.Agregar, string.Empty);
        }


        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.obtenerRutCliente();
            if (string.IsNullOrEmpty(this.RutCliente)) return;
            this.AbrirMaestroClientesModoChild(EstadoFormulario.Editar, TipoGrabacion.Actualizar, this.RutCliente);
        }

        #endregion



        // Manejo de los filtros.
        #region "Manejo de los filtros."

        private void filtrosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.filtrosComboBox.SelectedIndex == 0) this.controlesSinFiltro();
            if (this.filtrosComboBox.SelectedIndex == 1) this.controlesFiltroPorRut();
            if (this.filtrosComboBox.SelectedIndex == 2) this.controlesFiltroPorEstadoCivil();
            if (this.filtrosComboBox.SelectedIndex == 3) this.controlesFiltroPorSexo();
        }


        private void buscarButton_Click(object sender, EventArgs e)
        {
            this.CargarClientes();
        }

        #endregion



        // Manejo de los botones de accion.
        #region "Manejo de los botones de accion."

        private void aceptarMetroButton_Click(object sender, EventArgs e)
        {
            this.obtenerRutCliente();
            this.DialogResult = DialogResult.OK;
        }

        private void cancelarMetroButton_Click(object sender, EventArgs e)
        {
            this.RutCliente = string.Empty;
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion



        // Manejo de la grilla de datos.
        #region "Manejo de la grilla de datos."

        private void listadoDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.IsSearch) this.obtenerRutCliente();
        }


        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (this.IsSearch)
            {
                this.obtenerRutCliente();
                this.DialogResult = DialogResult.OK;
            }
        }

        #endregion




        // Metodos del formulario.
        #region "Metodos del formulario."

        private void CargarComboFiltros()
        {
            this.filtrosComboBox.BeginUpdate();
            this.filtrosComboBox.Items.Clear();
            this.filtrosComboBox.Items.Add(StringResources.FiltrosClientes_SinFiltro);
            this.filtrosComboBox.Items.Add(StringResources.FiltrosClientes_PorRut);
            this.filtrosComboBox.Items.Add(StringResources.FiltrosClientes_PorEstadoCivil);
            this.filtrosComboBox.Items.Add(StringResources.FiltrosClientes_PorSexo);
            this.filtrosComboBox.EndUpdate();
            this.filtrosComboBox.SelectedIndex = 0;
        }

        private void controlesSinFiltro()
        {
            this.valorFiltroComboBox.Visible = false;
            this.valorFiltroLabel.Visible = false;
            this.valorFiltroTextBox.Visible = false;
        }


        private void controlesFiltroPorRut()
        {
            this.valorFiltroComboBox.Visible = false;
            this.valorFiltroLabel.Visible = true;
            this.valorFiltroLabel.Text = StringResources.ListadoClientes_CampoRut;
            this.valorFiltroTextBox.Visible = true;
            this.valorFiltroTextBox.Text = string.Empty;
            this.valorFiltroTextBox.AccessibleName = StringResources.FiltrosClientes_PorRut;
        }


        private void controlesFiltroPorEstadoCivil()
        {
            var myCommand = CmdCargarComboEstadoCivil.crear(this, this.valorFiltroComboBox);
            myCommand.Ejecutar();
            MessageBox.Show(myCommand.OcurrioError.ToString(), "Hay error?");

            if (myCommand.OcurrioError)
            {
                this.Close();
                return;
            }
            this.valorFiltroLabel.Text = StringResources.ListadoClientes_CampoEstadoCivil;
            this.valorFiltroComboBox.AccessibleName = StringResources.FiltrosClientes_PorEstadoCivil;
            this.activarFiltrosComboBox();
        }


        private void controlesFiltroPorSexo()
        {
            var myCommand = CmdCargarComboSexo.crear(this, this.valorFiltroComboBox);
            myCommand.Ejecutar();
            this.valorFiltroLabel.Text = StringResources.ListadoClientes_CampoSexo;
            this.valorFiltroComboBox.AccessibleName = StringResources.FiltrosClientes_PorSexo;
            this.activarFiltrosComboBox();
        }


        private void activarFiltrosComboBox()
        {
            this.valorFiltroComboBox.Visible = true;
            this.valorFiltroLabel.Visible = true;
            this.valorFiltroTextBox.Visible = false;
            this.valorFiltroTextBox.Text = string.Empty;
        }


        // Metodo para cargar los clientes.
        private void CargarClientes()
        {
            TipoFiltro myTipo = TipoFiltro.Todo;
            string valorFiltro = string.Empty;
            if (this.filtrosComboBox.SelectedIndex == 0) myTipo = TipoFiltro.Todo;
            if (this.filtrosComboBox.SelectedIndex == 1)
            {
                if (!this.ValidaRut()) return;
                myTipo = TipoFiltro.Rut;
                valorFiltro = this.valorFiltroTextBox.Text;
            }
            if (this.filtrosComboBox.SelectedIndex == 2)
            {
                myTipo = TipoFiltro.EstadoCivil;
                valorFiltro = this.valorFiltroComboBox.SelectedValue.ToString();
            }
            if (this.filtrosComboBox.SelectedIndex == 3)
            {
                myTipo = TipoFiltro.Sexo;
                valorFiltro = this.valorFiltroComboBox.SelectedValue.ToString();
            }
            var myCommand = CmdCargarGrillaClientes.Crear(this, this.listadoDataGridView, myTipo, valorFiltro);
            myCommand.Ejecutar();
            this.textoMetroLabel.Text = myCommand.TextoResultado.ToString();
            if (this.listadoDataGridView.Rows.Count > 0)
            {
                this.listadoDataGridView.Rows[0].Selected = true;
                this.listadoDataGridView.Focus();
            }
        }


        // Validar rut para realizar busqueda.
        private bool ValidaRut()
        {
            var myCommand = CmdValidarEntradas.crear(this);
            myCommand.ValidarVacio(this.valorFiltroTextBox, "rut cliente");
            myCommand.ValidarRut(this.valorFiltroTextBox);
            return !myCommand.FalloValidacion;
        }


        // Metodo que obtiene el rut del cliente que esta seleccionado en la grilla de datos.))
        private void obtenerRutCliente()
        {
            if (this.listadoDataGridView.Rows.Count == 0)
            {
                this.RutCliente = string.Empty;
                return;
            }
            DataGridViewRow myRow = this.listadoDataGridView.CurrentRow;
            if (myRow == null)
            {
                this.RutCliente = string.Empty;
                return;
            }
            this.RutCliente = myRow.Cells[0].Value.ToString();
        }


        private void AbrirMaestroClientesModoChild(EstadoFormulario estado, TipoGrabacion accion, string rutQueBuscar)
        {
            MetroMaestroDeClientesForm myForm = new MetroMaestroDeClientesForm(this.StyleManager.Theme);
            myForm.RutExterno = rutQueBuscar;
            myForm.EstadoForm = estado;
            myForm.AccionGrabar = accion;
            myForm.IsChildForm = true;
            var myCommand = CmdAbrirFormulario.Crear(myForm);
            myCommand.Ejecutar();
            if (myForm.HayCambios) this.CargarClientes();
        }

        #endregion





    }
}
