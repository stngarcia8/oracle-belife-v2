using System;
using System.Drawing;
using System.Windows.Forms;
using BeLife.Aplicacion.Idiomas.Localizacion;
using MetroFramework.Controls;

namespace BeLife.Vista.Controles.MsgBox
{
    public partial class MsgBoxControl : Form
    {

        // Miembros.
        #region "Miembros."

        //private Color colorPorDefecto = Color.FromArgb(57, 179, 215);
        private Color colorPorDefecto = Color.FromArgb(124, 65, 153);

        private Color colorError = Color.FromArgb(210, 50, 45);
        private Color colorWarning = Color.FromArgb(237, 156, 40);
        private Color colorSuccess = Color.FromArgb(71, 164, 71);
        private Color colorQuestion = Color.FromArgb(71, 164, 71);
        private MsgBoxProperties misPropiedades = null;
        private DialogResult resultadoDialogo = DialogResult.None;

        #endregion



        // Propiedades.
        #region "Propiedades."

        public Panel Body { get { return panelbody; } }
        public MsgBoxProperties Properties { get { return misPropiedades; } }
        public DialogResult Resultado { get { return resultadoDialogo; } }

        #endregion 



        // Manejo del formulario.
        public MsgBoxControl()
        {
            InitializeComponent();
            misPropiedades = new MsgBoxProperties(this);
            AsignarEventosAlBoton(metroButton1);
            AsignarEventosAlBoton(metroButton2);
            AsignarEventosAlBoton(metroButton3);
            metroButton1.Click += new EventHandler(button_Click);
            metroButton2.Click += new EventHandler(button_Click);
            metroButton3.Click += new EventHandler(button_Click);
        }


        // Manejo de los botones.
        #region "Manejo de los botones."

        private void button_MouseEnter(object sender, EventArgs e)
        {
            AsignarEventosAlBoton((MetroButton)sender, true);
        }


        private void button_MouseLeave(object sender, EventArgs e)
        {
            AsignarEventosAlBoton((MetroButton)sender);
        }


        private void button_Click(object sender, EventArgs e)
        {
            MetroButton button = (MetroButton)sender;
            if (!button.Enabled) return;
            resultadoDialogo = (DialogResult)button.Tag;
            this.Hide();
        }

        #endregion



        // Metodos del formulario.
        #region "Metodos del formulario."

        // Metodo que organiza los controles en la ventana.
        public void AjustarApariencia()
        {
            titleLabel.Text = misPropiedades.Titulo;
            messageLabel.Text = misPropiedades.Mensaje;
            this.EvaluarEstiloDeBotones();
            this.EvaluarEstiloDeIcono();
        }


        private void EvaluarEstiloDeBotones()
        {
            if (misPropiedades.Buttons.Equals(MessageBoxButtons.OK)) this.MessageButtonsOk();
            if (misPropiedades.Buttons.Equals(MessageBoxButtons.OKCancel)) this.MessageButtonsOkCancel();
            if (misPropiedades.Buttons.Equals(MessageBoxButtons.RetryCancel)) this.MessageButtonsRetryCancel();
            if (misPropiedades.Buttons.Equals(MessageBoxButtons.YesNo)) this.MessageButtonsYesNo();
            if (misPropiedades.Buttons.Equals(MessageBoxButtons.YesNoCancel)) this.MessageButtonsYesNoCancel();
            if (misPropiedades.Buttons.Equals(MessageBoxButtons.AbortRetryIgnore)) this.MessageButtonsAbortRetryIgnore();
        }


        private void MessageButtonsOk()
        {
            this.ConfigurarBoton(metroButton1, StringResources.Msgbox_Aceptar, metroButton3, DialogResult.OK);
            HabilitarBotones(metroButton2, false);
            HabilitarBotones(metroButton3, false);
        }


        private void MessageButtonsOkCancel()
        {
            this.ConfigurarBoton(metroButton1, StringResources.Msgbox_Aceptar, metroButton2, DialogResult.OK);
            this.ConfigurarBoton(metroButton2, StringResources.Msgbox_Cancelar, metroButton3, DialogResult.Cancel);
            HabilitarBotones(metroButton3, false);
        }


        private void MessageButtonsRetryCancel()
        {
            this.ConfigurarBoton(metroButton1, StringResources.Msgbox_Reintentar, metroButton2, DialogResult.Retry);
            this.ConfigurarBoton(metroButton2, StringResources.Msgbox_Cancelar, metroButton3, DialogResult.Cancel);
            HabilitarBotones(metroButton3, false);
        }


        private void MessageButtonsYesNo()
        {
            this.ConfigurarBoton(metroButton1, StringResources.Msgbox_si, metroButton2, DialogResult.Yes);
            this.ConfigurarBoton(metroButton2, StringResources.Msgbox_No, metroButton3, DialogResult.No);
            HabilitarBotones(metroButton3, false);
        }


        private void MessageButtonsYesNoCancel()
        {
            this.ConfigurarBoton(metroButton1, StringResources.Msgbox_si, DialogResult.Yes);
            this.ConfigurarBoton(metroButton2, StringResources.Msgbox_No, DialogResult.No);
            this.ConfigurarBoton(metroButton3, StringResources.Msgbox_Cancelar, DialogResult.Cancel);
        }


        private void MessageButtonsAbortRetryIgnore()
        {
            this.ConfigurarBoton(metroButton1, StringResources.Msgbox_Abortar, DialogResult.Abort);
            this.ConfigurarBoton(metroButton2, StringResources.Msgbox_Reintentar, DialogResult.Retry);
            this.ConfigurarBoton(metroButton3, StringResources.Msgbox_Ignorar, DialogResult.Ignore);
        }


        private void ConfigurarBoton(MetroButton myBoton, string texto, MetroButton myButon2, DialogResult myResult)
        {
            HabilitarBotones(myBoton);
            myBoton.Text = texto;
            myBoton.Location = myButon2.Location;
            myBoton.Tag = myResult;
        }


        private void ConfigurarBoton(MetroButton myBoton, string texto, DialogResult myResult)
        {
            HabilitarBotones(myBoton);
            myBoton.Text = texto;
            myBoton.Tag = myResult;
        }


        private void HabilitarBotones(MetroButton button)
        {
            HabilitarBotones(button, true);
        }


        private void HabilitarBotones(MetroButton button, bool enabled)
        {
            button.Enabled = enabled; button.Visible = enabled;
        }


        private void EvaluarEstiloDeIcono()
        {
            this.MessageStyle(Color.DarkGray, -1);
            if (misPropiedades.Icono.Equals(MessageBoxIcon.Error) || misPropiedades.Icono.Equals(MessageBoxIcon.Hand) || misPropiedades.Icono.Equals(MessageBoxIcon.Stop)) this.MessageStyle(colorError, 0);
            if (misPropiedades.Icono.Equals(MessageBoxIcon.Warning) || misPropiedades.Icono.Equals(MessageBoxIcon.Exclamation)) this.MessageStyle(colorWarning, 3);
            if (misPropiedades.Icono.Equals(MessageBoxIcon.Information) || misPropiedades.Icono.Equals(MessageBoxIcon.Asterisk)) this.MessageStyle(colorPorDefecto, 1);
            if (misPropiedades.Icono.Equals(MessageBoxIcon.Question)) this.MessageStyle(colorQuestion, 2);
        }


        private void MessageStyle(Color myColor, int imageIndex)
        {
            panelbody.BackColor = myColor;
            iconLabel.ImageIndex = imageIndex;
        }


        public void EstablecerBotonPredeterminado()
        {
            if (misPropiedades.DefaultButton.Equals(MessageBoxDefaultButton.Button1)) this.ConfigurarBotonPredeterminado(metroButton1);
            if (misPropiedades.DefaultButton.Equals(MessageBoxDefaultButton.Button2)) this.ConfigurarBotonPredeterminado(metroButton2);
            if (misPropiedades.DefaultButton.Equals(MessageBoxDefaultButton.Button3)) this.ConfigurarBotonPredeterminado(metroButton3);
        }


        private void ConfigurarBotonPredeterminado(MetroButton myButton)
        {
            if (myButton != null && myButton.Enabled) myButton.Focus();
        }


        private void AsignarEventosAlBoton(MetroButton button)
        {
            AsignarEventosAlBoton(button, false);
        }


        private void AsignarEventosAlBoton(MetroButton button, bool hovered)
        {
            button.Cursor = Cursors.Hand;
            button.MouseEnter -= button_MouseEnter;
            button.MouseEnter += button_MouseEnter;
            button.MouseLeave -= button_MouseLeave;
            button.MouseLeave += button_MouseLeave;
        }

        #endregion


    }
}
