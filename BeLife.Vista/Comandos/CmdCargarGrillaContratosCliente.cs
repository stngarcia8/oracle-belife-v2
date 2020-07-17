using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Controlador.DAO;
using BeLife.Aplicacion.Idiomas.Localizacion;

namespace BeLife.Vista.Comandos
{

    public class CmdCargarGrillaContratosCliente : CmdCargarDataGrid, IComando
    {


        // Constructor.
        private CmdCargarGrillaContratosCliente(Form myForm, DataGridView myGrid, string textoFiltro)
            : base(myForm, myGrid, textoFiltro)
        { }


        // Metodo para crear objeto.
        public static CmdCargarGrillaContratosCliente Crear(Form myForm, DataGridView myGrid, string textoFiltro)
        {
            return new CmdCargarGrillaContratosCliente(myForm, myGrid, textoFiltro);
        }


        public void Ejecutar()
        {
            this.ObtenerDatos();
            this.asignarResultado(StringResources.ResultadoDataGrid_TipoContrato);
            IList<int> exclusiones = new List<int> { 0, 4, 5, 6, 7 };
            this.OcultarColumnas(exclusiones);
        }


        // Metodo que carga el data grid de contratos de clientes.
        protected override void ObtenerDatos()
        {
            this.myGrid.DataSource = null;
            try
            {
                IDaoCliente myDao = DaoCliente.Crear();
                myGrid.DataSource = myDao.ObtenerListaContratossPorRut(this.textoFiltro);
            }
            catch (Exception ex)
            {
                this.MostrarMensajeDeError(ex);
            }
        }



    }
}
