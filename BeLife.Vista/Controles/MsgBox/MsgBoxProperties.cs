using System.Windows.Forms;

namespace BeLife.Vista.Controles.MsgBox
{
    public class MsgBoxProperties
    {

        // Miembros.
        private MsgBoxControl owner = null;


        // Propiedades.
        public MessageBoxButtons Buttons { get; set; }
        public MessageBoxDefaultButton DefaultButton { get; set; }
        public MessageBoxIcon Icono { get; set; }
        public string Mensaje { get; set; }
        public MsgBoxControl Owner { get { return owner; } }
        public string Titulo { get; set; }


        // Constructor.
        public MsgBoxProperties(MsgBoxControl owner)
        {
            this.owner = owner;
        }





    }
}
