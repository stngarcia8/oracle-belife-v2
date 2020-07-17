using System;
using System.Windows.Forms;
using BeLife.Aplicacion.Configuracion;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Controlador.Enumeraciones;
using BeLife.Vista.Comandos;
using BeLife.Vista.Controles.MsgBox;
using MetroFramework;
using MetroFramework.Forms;

namespace BeLife.Vista.MetroForms
{
    public partial class MetroBeLifeForm : MetroForm
    {


        // Miembros.
        private bool reiniciarApp;

        // Manejo del formulario
        #region "Manejo del formulario."

        public MetroBeLifeForm()
        {
            InitializeComponent();
            var myConfigurador = Configurador.Crear();
            this.formularioMetroStyleManager.Theme = (myConfigurador.ModoVisualizacion.Theme.Equals("Dark") ? MetroThemeStyle.Dark : MetroThemeStyle.Light);
            this.StyleManager = this.formularioMetroStyleManager;
            this.EvaluarTemaFormulario();
            this.DefinirToolTips();
            this.AjustarResolucionDePantalla();
        }


        private void BeLife_Load(object sender, EventArgs e)
        {
            this.reiniciarApp = false;
        }


        private void MetroBeLifeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.reiniciarApp)
            {
                e.Cancel = false;
                return;
            }
            DialogResult myResult = MsgBox.Show(this, StringResources.principalForm_MensajeSalida, StringResources.TituloMensajes_Atencion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (myResult == DialogResult.Yes ? false : true);
        }

        #endregion



        // Manejo de las tiles.
        #region "Manejo de las tiles."

        private void listadoClientesMetroTile_Click(object sender, EventArgs e)
        {
            MetroListadoDeClientesForm myForm = new MetroListadoDeClientesForm(this.formularioMetroStyleManager.Theme);
            myForm.IsSearch = false;
            this.AbrirUnFormulario(myForm);
        }


        private void maestroClientesMetroTile_Click(object sender, EventArgs e)
        {
            MetroMaestroDeClientesForm myForm = new MetroMaestroDeClientesForm(this.formularioMetroStyleManager.Theme);
            myForm.RutExterno = string.Empty;
            myForm.IsChildForm = false;
            myForm.EstadoForm = EstadoFormulario.Buscar;
            this.AbrirUnFormulario(myForm);
        }


        private void listadoContratosMetroTile_Click(object sender, EventArgs e)
        {
            MetroListadoDeContratosForm myForm = new MetroListadoDeContratosForm(this.StyleManager.Theme);
            myForm.IsSearch = false;
            this.AbrirUnFormulario(myForm);
        }


        private void maestroContratosMetroTile_Click(object sender, EventArgs e)
        {
            MetroMaestroDeContratosForm myForm = new MetroMaestroDeContratosForm(this.formularioMetroStyleManager.Theme);
            myForm.NumeroContratoExterno = string.Empty;
            myForm.IsChildForm = false;
            myForm.EstadoForm = EstadoFormulario.Buscar;
            this.AbrirUnFormulario(myForm);
        }


        private void darkModeMetroTile_Click(object sender, EventArgs e)
        {
            this.formularioMetroStyleManager.Theme = (this.formularioMetroStyleManager.Theme.Equals(MetroThemeStyle.Light) ? MetroThemeStyle.Dark : MetroThemeStyle.Light);
            this.EvaluarTemaFormulario();
            this.registrarCambioDeTema();
        }


        private void metroTile_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



        // Manejo de los botones.
        #region "Manejo de los botones."

        private void acercaMetroButton_Click(object sender, EventArgs e)
        {
            MetroAcerca myForm = new MetroAcerca(this.formularioMetroStyleManager.Theme);
            this.AbrirUnFormulario(myForm);
        }


        private void preferenciasMetroButton_Click(object sender, EventArgs e)
        {
            MetroPreferenciasForm myForm = new MetroPreferenciasForm(this.formularioMetroStyleManager.Theme);
            this.AbrirUnFormulario(myForm);
            if (myForm.DialogResult.Equals(DialogResult.OK) && myForm.CambioDeIdioma)
            {
                this.reiniciarApp = true;
                Application.Restart();
            }
        }

        #endregion



        // Metodos del formulario.
        #region "Metodos del formulario."

        // Metodo que evalua el tema del formulario.
        private void EvaluarTemaFormulario()
        {
            if (this.formularioMetroStyleManager.Theme == MetroThemeStyle.Dark)
            {
                this.darkModeMetroTile.Style = MetroColorStyle.Yellow;
                this.darkModeMetroTile.TileImage = Properties.Resources.sunLightTheme;
                this.darkModeMetroTile.AccessibleName = StringResources.Tema_Mensaje_OscuroClaro;
                this.formularioMetroToolTip.SetToolTip(this.darkModeMetroTile, StringResources.Tema_Mensaje_OscuroClaro);
            }
            else
            {
                this.darkModeMetroTile.Style = MetroColorStyle.Pink;
                this.darkModeMetroTile.TileImage = Properties.Resources.moonDarkTheme;
                this.darkModeMetroTile.AccessibleName = StringResources.Tema_Mensaje_ClaroOscuro;
                this.formularioMetroToolTip.SetToolTip(this.darkModeMetroTile, StringResources.Tema_Mensaje_ClaroOscuro);
            }
        }


        private void registrarCambioDeTema()
        {
            var myConfigurador = Configurador.Crear();
            myConfigurador.ModoVisualizacion.Theme = this.formularioMetroStyleManager.Theme.ToString();
            myConfigurador.GrabarConfiguraciones();
        }


        private void AbrirUnFormulario(MetroForm myForm)
        {
            this.Hide();
            CmdAbrirFormulario myCommand = CmdAbrirFormulario.Crear(myForm);
            myCommand.Ejecutar();
            this.Show();
        }


        private void AjustarResolucionDePantalla()
        {
            Screen myScreen = Screen.PrimaryScreen;
            this.Height = (this.Height > (myScreen.Bounds.Height - 50) ? myScreen.Bounds.Height - 50 : this.Height);
            this.Width = (this.Width > (myScreen.Bounds.Width - 50) ? myScreen.Bounds.Width - 50 : this.Width);
        }


        private void DefinirToolTips()
        {
            this.formularioMetroToolTip.SetToolTip(this.metroTile, StringResources.ToolTip_SalirButton);
            this.formularioMetroToolTip.SetToolTip(this.formularioPictureBox, StringResources.ToolTip_LogoBeLiffe);
            this.formularioMetroToolTip.SetToolTip(this.atencionClientePictureBox, StringResources.ToolTip_PrincipalForm);
            this.formularioMetroToolTip.SetToolTip(this.listadoClientesMetroTile, StringResources.Ayuda_ListadoClientes);
            this.formularioMetroToolTip.SetToolTip(this.maestroClientesMetroTile, StringResources.Ayuda_MaestroDeClientes);
            this.formularioMetroToolTip.SetToolTip(this.listadoContratosMetroTile, StringResources.Ayuda_ListadoContratos);
            this.formularioMetroToolTip.SetToolTip(this.maestroContratosMetroTile, StringResources.Ayuda_MaestroDeContratos);
            this.formularioMetroToolTip.SetToolTip(this.preferenciasMetroButton, StringResources.ToolTip_PreferenciasForm);
            this.formularioMetroToolTip.SetToolTip(this.acercaMetroButton, StringResources.ToolTip_AcercaDEForm);
        }

        #endregion


    }
}
