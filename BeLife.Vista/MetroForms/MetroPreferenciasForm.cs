using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using BeLife.Aplicacion.Clases;
using BeLife.Aplicacion.Configuracion;
using BeLife.Aplicacion.Idiomas;
using BeLife.Aplicacion.Idiomas.Localizacion;
using MetroFramework;
using MetroFramework.Forms;


namespace BeLife.Vista.MetroForms
{
    public partial class MetroPreferenciasForm : MetroForm
    {

        // Miembros.
        private Configurador myConfigurador;


        // Propiedades.
        public bool CambioDeIdioma { get; set; }



        // Manejo del formulario.
        #region "Manejo del formulario."

        public MetroPreferenciasForm(MetroThemeStyle myStyle)
        {
            InitializeComponent();
            this.formularioMetroStyleManager.Theme = myStyle;
            this.StyleManager = formularioMetroStyleManager;
        }

        private void MetroPreferenciasForm_Load(object sender, EventArgs e)
        {
            this.CambioDeIdioma = false;
            myConfigurador = Configurador.Crear();
            this.CargarDatosEnControlesDeVisualizacion();
            this.CargarDatosEnControlesDeIdioma();
            this.temaMetroComboBox.Focus();
        }

        #endregion



        // Manejo de los botones.
        #region "Manejo de los botones."

        private void idiomasMetroButton_Click(object sender, EventArgs e)
        {
            this.visualizacionMetroPanel.Visible = false;
            this.idiomaMetroPanel.Visible = true;
            this.ayudaMetroLabel.Text = StringResources.Ayuda_CambiarIdioma;
            this.nuevoIdiomaMetroComboBox.Focus();
        }


        private void colorMetroButton_Click(object sender, EventArgs e)
        {
            this.idiomaMetroPanel.Visible = false;
            this.visualizacionMetroPanel.Visible = true;
            this.ayudaMetroLabel.Text = StringResources.Ayuda_CambiarColor;
            this.temaMetroComboBox.Focus();
        }


        private void cancelarMetroButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void aceptarMetroButton_Click(object sender, EventArgs e)
        {
            this.AplicarCambios();
            this.DialogResult = DialogResult.OK;
        }

        #endregion



        // Manejo de los combobox.
        #region "Manejo de los combobox."

        private void nuevoIdiomaMetroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.nuevoIdiomaMetroComboBox.DataSource.Equals(null)) return;
            this.CambioDeIdioma = (this.nuevoIdiomaMetroComboBox.Text.Equals(this.idiomaActualMetroTextBox.Text) ? false : true);
            this.nuevaNomenclaturaMetroTextBox.Text = this.nuevoIdiomaMetroComboBox.SelectedValue.ToString();
        }

        #endregion



        // Manejo del toogle control.
        #region "Manejo del toogle control."

        private void mostrarAyudaMetroToggle_Click(object sender, EventArgs e)
        {
            this.ayudaMetroLabel.Visible = this.mostrarAyudaMetroToggle.Checked;
        }

        #endregion



        // Metodos del formulario.
        #region "Metodos del formulario."

        private void CargarDatosEnControlesDeVisualizacion()
        {
            this.mostrarAyudaMetroToggle.Checked = (myConfigurador.ModoVisualizacion.AyudaLateral.Equals("True") ? true : false);
            this.mostrarTemaPictureBox.Image = (this.myConfigurador.ModoVisualizacion.Theme.Equals("Dark") ? Properties.Resources.beLifeOscuro : Properties.Resources.beLifeClaro);
            this.temaActualMetroLabel.Text = this.temaActualMetroLabel.Text + (myConfigurador.ModoVisualizacion.Theme.Equals("Dark") ? StringResources.Tema_Oscuro : StringResources.Tema_Claro);
            this.CargarComboboxDETemas();
            this.temaMetroComboBox.Text = (this.myConfigurador.ModoVisualizacion.Theme.Equals("Dark") ? StringResources.Tema_Oscuro : StringResources.Tema_Claro);
            this.idiomaMetroPanel.Visible = false;
            this.ayudaMetroLabel.Visible = (this.myConfigurador.ModoVisualizacion.AyudaLateral.Equals("True") ? true : false);
            this.ayudaMetroLabel.Text = StringResources.Ayuda_CambiarColor;
        }


        private void CargarDatosEnControlesDeIdioma()
        {
            this.idiomaActualMetroTextBox.Text = Thread.CurrentThread.CurrentUICulture.DisplayName.ToString();
            this.nomenclaturaActualMetroTextBox.Text = Thread.CurrentThread.CurrentUICulture.Name.ToString();
            this.nuevoIdiomaMetroComboBox.BeginUpdate();
            this.nuevoIdiomaMetroComboBox.DataSource = this.DefinirListaDeIdiomas();
            this.nuevoIdiomaMetroComboBox.DisplayMember = "Idioma";
            this.nuevoIdiomaMetroComboBox.ValueMember = "Nomenclatura";
            this.nuevoIdiomaMetroComboBox.Text = this.idiomaActualMetroTextBox.Text;
            this.nuevoIdiomaMetroComboBox.EndUpdate();
        }


        private void CargarComboboxDETemas()
        {
            this.temaMetroComboBox.BeginUpdate();
            this.temaMetroComboBox.DataSource = this.DefinirListaDeTemas();
            this.temaMetroComboBox.DisplayMember = "Nombre";
            this.temaMetroComboBox.ValueMember = "Nomenclatura";
            this.temaMetroComboBox.EndUpdate();
        }


        private IList<ITema> DefinirListaDeTemas()
        {
            IList<ITema> myList = new List<ITema>();
            myList.Add(this.AgregarTema(StringResources.Tema_Claro, "Light"));
            myList.Add(this.AgregarTema(StringResources.Tema_Oscuro, "Dark"));
            return myList;
        }


        private ITema AgregarTema(string nombre, string nomenclatura)
        {
            ITema myTema = new Tema();
            myTema.Nombre = nombre;
            myTema.Nomenclatura = nomenclatura;
            return myTema;
        }


        private IList<ILanguage> DefinirListaDeIdiomas()
        {
            IList<ILanguage> myList = new List<ILanguage>();
            myList.Add(this.AgregarIdioma(StringResources.Idioma_Predeterminado, "es-ES"));
            myList.Add(this.AgregarIdioma(StringResources.Idioma_Español, "es-ES"));
            myList.Add(this.AgregarIdioma(StringResources.Idioma_Ingles, "en-US"));
            return myList;
        }


        private ILanguage AgregarIdioma(string idioma, string nomenclatura)
        {
            ILanguage myIdioma = new Language();
            myIdioma.Nomenclatura = nomenclatura;
            myIdioma.Idioma = idioma;
            return myIdioma;
        }


        private void AplicarCambios()
        {
            if (this.CambioDeIdioma)
            {
                myConfigurador.Idioma.Idioma = this.nuevoIdiomaMetroComboBox.Text;
                myConfigurador.Idioma.Nomenclatura = this.nuevoIdiomaMetroComboBox.SelectedValue.ToString();
            }
            myConfigurador.ModoVisualizacion.Theme = this.temaMetroComboBox.SelectedValue.ToString();
            myConfigurador.ModoVisualizacion.AyudaLateral = (this.mostrarAyudaMetroToggle.Checked ? "True" : "False");
            myConfigurador.GrabarConfiguraciones();
            this.StyleManager.Theme = (this.temaMetroComboBox.SelectedValue.ToString().Equals("Dark") ? MetroThemeStyle.Dark : MetroThemeStyle.Light);
            if (this.CambioDeIdioma)
            {
                var myAsignador = AsignarIdioma.Crear();
                myAsignador.Fijaridioma();
            }
        }




        #endregion


    }
}
