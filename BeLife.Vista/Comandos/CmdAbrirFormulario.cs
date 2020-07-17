using System.Windows.Forms;

namespace BeLife.Vista.Comandos
{
    public class CmdAbrirFormulario : IComando
    {

        // Miembros privados.
        private readonly Form myForm;


        // Constructor.
        private CmdAbrirFormulario(Form myForm)
        {
            if (myForm == null)
            {
                this.myForm = null;
                return;
            }
            this.myForm = myForm;
        }


        // Metodo constructor del objeto.
        public static CmdAbrirFormulario Crear(Form myForm)
        {
            return new CmdAbrirFormulario(myForm);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            if (this.myForm != null
                )
            {
                this.AjustarResolucionDePantalla();
                this.myForm.ShowDialog();
                    }
        }

        // Metodo que ajusta la pantalla del formulario.
        private void AjustarResolucionDePantalla()
        {
            Screen myScreen = Screen.PrimaryScreen;
            this.myForm.Height = (this.myForm.Height>(myScreen.Bounds.Height-50)?myScreen.Bounds.Height-50:this.myForm.Height);
            this.myForm.Width= (this.myForm.Width> (myScreen.Bounds.Width- 50) ? myScreen.Bounds.Width-50: this.myForm.Width);
        }




    }
}
