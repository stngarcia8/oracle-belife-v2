using System;
using System.Text;
using BeLife.Aplicacion.Idiomas.Localizacion;
using MetroFramework;
using MetroFramework.Forms;
namespace BeLife.Vista.MetroForms
{
    public partial class MetroAcerca : MetroForm
    {
        public MetroAcerca(MetroThemeStyle myStyle)
        {
            InitializeComponent();
            formularioMetroStyleManager.Theme = myStyle;
            this.StyleManager = formularioMetroStyleManager;
        }

        private void MetroAcerca_Load(object sender, EventArgs e)
        {
            this.textoMetroLabel.Text = this.generarTexto();
        }


        // Generar texto del textbox.
        private string generarTexto()
        {
            StringBuilder myTexto = new StringBuilder();
            myTexto.Append(StringResources.AcercaDeForm_Aplicacion + "\n");
            myTexto.Append(StringResources.AcercaDeForm_Version + "\n\n");
            myTexto.Append(StringResources.AcercaDeForm_ProgramadoPara + "\n");
            myTexto.Append(StringResources.AcercaDeForm_Ramo + "\n");
            myTexto.Append(string.Format(StringResources.AcercaDeForm_Profesor, "Andrea Silva Loncón.") + "\n\n");
            myTexto.Append(StringResources.AcercaDeForm_Equipo + "\n");
            myTexto.Append("- Hector Celis Villarroel.\n");
            myTexto.Append("- Elias García Carvajal.\n");
            myTexto.Append("- Daniel García Loyola.\n\n");
            return myTexto.ToString();
        }


        private void cerrarMetroButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = this.cerrarMetroButton.DialogResult;
        }


    }
}
