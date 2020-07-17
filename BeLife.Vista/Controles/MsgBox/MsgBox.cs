using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;


namespace BeLife.Vista.Controles.MsgBox
{
    public static class MsgBox
    {


        public static DialogResult Show(IWin32Window owner, String message)
        {
            return Show(owner, message, "Notification", 211);
        }


        public static DialogResult Show(IWin32Window owner, String message, int height)
        {
            return Show(owner, message, "Notification", height);
        }


        public static DialogResult Show(IWin32Window owner, String message, String title)
        {
            return Show(owner, message, title, MessageBoxButtons.OK, 211);
        }


        public static DialogResult Show(IWin32Window owner, String message, String title, int height)
        {
            return Show(owner, message, title, MessageBoxButtons.OK, height);
        }


        public static DialogResult Show(IWin32Window owner, String message, String title, MessageBoxButtons buttons)
        {
            return Show(owner, message, title, buttons, MessageBoxIcon.None, 211);
        }


        public static DialogResult Show(IWin32Window owner, String message, String title, MessageBoxButtons buttons, int height)
        {
            return Show(owner, message, title, buttons, MessageBoxIcon.None, height);
        }


        public static DialogResult Show(IWin32Window owner, String message, String title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(owner, message, title, buttons, icon, MessageBoxDefaultButton.Button1, 211);
        }


        public static DialogResult Show(IWin32Window owner, String message, String title, MessageBoxButtons buttons, MessageBoxIcon icon, int height)
        {
            return Show(owner, message, title, buttons, icon, MessageBoxDefaultButton.Button1, height);
        }


        public static DialogResult Show(IWin32Window owner, String message, String title, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton)
        {
            return Show(owner, message, title, buttons, icon, defaultbutton, 211);
        }


        public static DialogResult Show(IWin32Window owner, String message, String title, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton, int height)
        {
            DialogResult _result = DialogResult.None;
            if (owner != null)
            {
                Form formularioPadre = (owner as Form == null) ? ((UserControl)owner).ParentForm : (Form)owner;
                AjustarSonidos(icon);
                MsgBoxControl myMsgBoxControl = AjustarVentanaDeDialogo(message, title, buttons, icon, defaultbutton, height, formularioPadre);
                Action<MsgBoxControl> myDelegado = new Action<MsgBoxControl>(ModalState);
                IAsyncResult asyncResult = myDelegado.BeginInvoke(myMsgBoxControl, null, myDelegado);
                bool cancelado= false;
                try
                {
                    while (!asyncResult.IsCompleted)
                    {
                        Thread.Sleep(1);
                        Application.DoEvents();
                    }
                }
                catch
                {
                    cancelado = true;
                    if (!asyncResult.IsCompleted)
                    {
                        try
                        {
                            asyncResult = null;
                        }
                        catch { }
                    }
                    myDelegado = null;
                }
                if (!cancelado)
                {
                    _result = myMsgBoxControl.Resultado;
                    myMsgBoxControl.Dispose(); myMsgBoxControl = null;
                }
            }
            return _result;
        }

        private static MsgBoxControl AjustarVentanaDeDialogo(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton, int height, Form formularioPadre)
        {
            MsgBoxControl myMsgBoxControl = new MsgBoxControl();
            myMsgBoxControl.BackColor = formularioPadre.BackColor;
            myMsgBoxControl.Properties.Buttons = buttons;
            myMsgBoxControl.Properties.DefaultButton = defaultbutton;
            myMsgBoxControl.Properties.Icono = icon;
            myMsgBoxControl.Properties.Mensaje = message;
            myMsgBoxControl.Properties.Titulo = title;
            myMsgBoxControl.Padding = new Padding(0, 0, 0, 0);
            myMsgBoxControl.ControlBox = false;
            myMsgBoxControl.ShowInTaskbar = false;
            myMsgBoxControl.TopMost = true;
            myMsgBoxControl.Size = new Size(formularioPadre.Size.Width - 100, height);
            //myMsgBoxControl.Location = new Point(_owner.Location.X, _owner.Location.Y + (_owner.Height - myMsgBoxControl.Height) / 2);
            myMsgBoxControl.Location = new Point(formularioPadre.Location.X + (formularioPadre.Width - myMsgBoxControl.Width) / 2, formularioPadre.Location.Y + (formularioPadre.Height - myMsgBoxControl.Height) / 2);
            myMsgBoxControl.AjustarApariencia();
            int _overlaySizes = Convert.ToInt32(Math.Floor(myMsgBoxControl.Size.Height * 0.28));
            myMsgBoxControl.ShowDialog();
            myMsgBoxControl.BringToFront();
            myMsgBoxControl.EstablecerBotonPredeterminado();
            return myMsgBoxControl;
        }

        private static void AjustarSonidos(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    SystemSounds.Hand.Play(); break;
                case MessageBoxIcon.Exclamation:
                    SystemSounds.Exclamation.Play(); break;
                case MessageBoxIcon.Question:
                    SystemSounds.Beep.Play(); break;
                default:
                    SystemSounds.Asterisk.Play(); break;
            }
        }

        private static void ModalState(MsgBoxControl control)
        {
            while (control.Visible)
            { }
        }



    }
}
