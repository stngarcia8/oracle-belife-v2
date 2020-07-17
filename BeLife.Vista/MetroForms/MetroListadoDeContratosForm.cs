using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Aplicacion.Configuracion;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Controlador.Enumeraciones;
using BeLife.Modelo.Clases;
using BeLife.Vista.Comandos;
using MetroFramework;
using MetroFramework.Forms;



namespace BeLife.Vista.MetroForms
{
    public partial class MetroListadoDeContratosForm : MetroForm
    {

        // Miembros y Propiedades.
        #region "Miembros y propiedades."

        private IList<DetalleGrid> myDetalle;
        private Configurador myConfigurador;

        public string NumeroContrato { get; set; }
        public bool IsSearch { get; set; }

        #endregion



        // Manejo del formulario.
        #region "Manejo del formulario."

        public MetroListadoDeContratosForm(MetroThemeStyle myStyle)
        {
            InitializeComponent();
            this.formularioMetroStyleManager.Theme = myStyle;
            this.StyleManager = formularioMetroStyleManager;
            this.formularioMetroToolTip.SetToolTip(this.formularioPictureBox, StringResources.ToolTip_ListadoDeContratos);
            this.myDetalle = new List<DetalleGrid>();
        }


        private void MetroListadoDeContratosForm_Load(object sender, EventArgs e)
        {
            myConfigurador = Configurador.Crear();
            this.ayudaMetroLabel.Text = StringResources.Ayuda_ListadoContratos;
            this.ayudaMetroLabel.Visible = (myConfigurador.ModoVisualizacion.AyudaLateral.Equals("True") ? true : false);
            this.CargarComboFiltros();
            this.valorFiltroTextBox.Text = string.Empty;
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
            this.AbrirMaestroContratosModoChild(EstadoFormulario.Crear, TipoGrabacion.Agregar, string.Empty);
        }


        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ObtenerNumeroDeContrato();
            if (string.IsNullOrEmpty(this.NumeroContrato)) return;
            this.AbrirMaestroContratosModoChild(EstadoFormulario.Editar, TipoGrabacion.Actualizar, this.NumeroContrato);
        }

        #endregion



        // Manejo de los filtros.
        #region "Manejo de los filtros."

        private void filtrosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.filtrosComboBox.SelectedIndex == 0) this.controlesFiltro(string.Empty, false, 0, string.Empty);
            if (this.filtrosComboBox.SelectedIndex == 1) this.controlesFiltro(StringResources.ListadoContratos_EtiquetaValorFiltro_PorNumeroDeContrato, true, 14, StringResources.ListadoContratos_EtiquetaValorFiltro_PorNumeroDeContrato);
            if (this.filtrosComboBox.SelectedIndex == 2) this.controlesFiltro(StringResources.ListadoContratos_EtiquetaValorFiltro_PorRut, true, 10, StringResources.ListadoContratos_EtiquetaValorFiltro_PorRut);
            if (this.filtrosComboBox.SelectedIndex == 3) this.controlesFiltro(StringResources.ListadoContratos_EtiquetaValorFiltro_PorNumeroDePoliza, true, 15, StringResources.ListadoContratos_EtiquetaValorFiltro_PorNumeroDePoliza);
        }


        private void buscarButton_Click(object sender, EventArgs e)
        {
            this.CargarContratos();
        }

        #endregion



        // Manejo de los botones de accion.
        #region "Manejo de los botones de accion."

        private void aceptarMetroButton_Click(object sender, EventArgs e)
        {
            this.ObtenerNumeroDeContrato();
            this.Close();
        }


        private void cancelarMetroButton_Click(object sender, EventArgs e)
        {
            this.NumeroContrato = string.Empty;
            this.Close();
        }

        #endregion



        // Manejo de la grilla de datos.
        #region "Manejo de la grilla de datos."

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (this.IsSearch)
            {
                this.ObtenerNumeroDeContrato();
                this.Close();
            }
        }


        private void listadoDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.IsSearch) this.ObtenerNumeroDeContrato();
            if (this.listadoDataGridView.Rows.Count > 0) this.MostrarDetalleDeContrato();
        }

        #endregion




        // Metodos del formulario.
        #region "Metodos del formulario."

        private void CargarComboFiltros()
        {
            this.filtrosComboBox.BeginUpdate();
            this.filtrosComboBox.Items.Clear();
            this.filtrosComboBox.Items.Add(StringResources.FiltrosContratos_SinFiltro);
            this.filtrosComboBox.Items.Add(StringResources.FiltrosContratos_PorNumeroContrato);
            this.filtrosComboBox.Items.Add(StringResources.FiltrosContratos_PorRutCliente);
            this.filtrosComboBox.Items.Add(StringResources.FiltrosContratos_PorNumeroDePoliza);
            this.filtrosComboBox.EndUpdate();
            this.filtrosComboBox.SelectedIndex = 0;
        }


        private void controlesFiltro(string etiqueta, bool esVisible, int largoCampo, string descripcion)
        {
            this.valorFiltroLabel.Visible = esVisible;
            this.valorFiltroTextBox.MaxLength = largoCampo;
            this.valorFiltroTextBox.AccessibleDescription = etiqueta;
            this.valorFiltroTextBox.AccessibleName = descripcion;
            this.valorFiltroLabel.Text = etiqueta;
            this.valorFiltroTextBox.Visible = esVisible;
            this.valorFiltroTextBox.Text = string.Empty;
        }


        private void CargarContratos()
        {
            TipoFiltro myTipo = TipoFiltro.Todo;
            string valorFiltro = string.Empty;
            if (this.filtrosComboBox.SelectedIndex == 0) myTipo = TipoFiltro.Todo;
            if (this.filtrosComboBox.SelectedIndex == 1)
            {
                myTipo = TipoFiltro.NumeroContrato;
                valorFiltro = this.valorFiltroTextBox.Text.Trim().ToUpper();
            }
            if (this.filtrosComboBox.SelectedIndex == 2)
            {
                if (!this.ValidaRut()) return;
                myTipo = TipoFiltro.Rut;
                valorFiltro = this.valorFiltroTextBox.Text.ToUpper().Trim();
            }
            if (this.filtrosComboBox.SelectedIndex == 3)
            {
                myTipo = TipoFiltro.NumeroPoliza;
                valorFiltro = this.valorFiltroTextBox.Text.ToUpper().Trim();
            }
            var myCommand = CmdCargarGrillaContratos.crear(this, this.listadoDataGridView, myTipo, valorFiltro);
            myCommand.Ejecutar();
            this.textoMetroLabel.Text = myCommand.TextoResultado.ToString();
            this.AsignarNombresDeColumnas();
            if (this.listadoDataGridView.Rows.Count > 0)
            {
                this.listadoDataGridView.Rows[0].Selected = true;
                this.listadoDataGridView.CurrentCell = this.listadoDataGridView.Rows[0].Cells[0];
                this.MostrarDetalleDeContrato();
                this.listadoDataGridView.Focus();
            }
        }


        private void AsignarNombresDeColumnas()
        {
            if (this.listadoDataGridView.Rows.Count.Equals(0))
            {
                this.detalleDataGridView.DataSource = null;
                return;
            }
            this.myDetalle = new List<DetalleGrid>();
            if (this.listadoDataGridView.Rows.Count.Equals(0)) return;
            string nombreCampo = string.Empty;
            for (int i = 0; i < this.listadoDataGridView.Columns.Count; i++)
            {
                nombreCampo = this.listadoDataGridView.Columns[i].Name.Replace('_', ' ').ToLower();
                nombreCampo = nombreCampo.Substring(0, 1).ToUpper() + nombreCampo.Substring(1, nombreCampo.Length - 1);
                this.myDetalle.Add(DetalleGrid.Crear(nombreCampo, string.Empty));
            }
            this.detalleDataGridView.DataSource = myDetalle;
        }


        // Validar rut para realizar busqueda.
        private bool ValidaRut()
        {
            var myCommand = CmdValidarEntradas.crear(this);
            myCommand.ValidarVacio(this.valorFiltroTextBox, "rut cliente");
            myCommand.ValidarRut(this.valorFiltroTextBox);
            return !myCommand.FalloValidacion;
        }


        // Metodo que obtiene el numero de contrato seleccionado.
        private void ObtenerNumeroDeContrato()
        {
            if (this.listadoDataGridView.Rows.Count.Equals(0))
            {
                this.NumeroContrato = string.Empty;
                return;
            }
            DataGridViewRow myRow = this.listadoDataGridView.CurrentRow;
            if (myRow == null)
            {
                this.NumeroContrato = string.Empty;
                return;
            }
            this.NumeroContrato = myRow.Cells[0].Value.ToString();
        }


        private void MostrarDetalleDeContrato()
        {
            DataGridViewRow myRow = this.listadoDataGridView.CurrentRow;
            if (myRow == null) return;
            if (this.myDetalle.Count.Equals(0)) return;
            this.detalleDataGridView.DataSource = null;
            int i = 0;
            foreach (DetalleGrid myDetails in this.myDetalle)
            {
                myDetails.Valor = (myRow.Cells[i].Value == null ? "---" : myRow.Cells[i].Value.ToString());
                i++;
            }
            this.detalleDataGridView.DataSource = this.myDetalle;
        }


        private void AbrirMaestroContratosModoChild(EstadoFormulario estado, TipoGrabacion accion, string NumeroContratoQueBuscar)
        {
            MetroMaestroDeContratosForm myForm = new MetroMaestroDeContratosForm(this.formularioMetroStyleManager.Theme);
            myForm.NumeroContratoExterno = NumeroContratoQueBuscar;
            myForm.EstadoForm = estado;
            myForm.AccionGrabar = accion;
            myForm.IsChildForm = true;
            CmdAbrirFormulario myCommand = CmdAbrirFormulario.Crear(myForm);
            myCommand.Ejecutar();
            if (myForm.HayCambios) this.CargarContratos();
        }

        #endregion








    }
}
