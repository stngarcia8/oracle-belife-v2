using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Controlador.DAO;
using BeLife.Controlador.Enumeraciones;

namespace BeLife.Vista.Comandos
{

    public class CmdCargarGrillaContratos : CmdCargarDataGrid, IComando
    {


        // Constructor.
        private CmdCargarGrillaContratos(Form myForm, DataGridView myGrid, TipoFiltro myFiltro, string textoFiltro)
            : base(myForm, myGrid, myFiltro, textoFiltro)
        { }


        // Metodo para crear objeto.
        public static CmdCargarGrillaContratos crear(Form myForm, DataGridView myGrid, TipoFiltro myFiltro, string textoFiltro)
        {
            return new CmdCargarGrillaContratos(myForm, myGrid, myFiltro, textoFiltro);
        }


        public void Ejecutar()
        {
            this.ObtenerDatos();
            this.asignarResultado(StringResources.ResultadoDataGrid_TipoContrato);
            IList<int> exclusiones = new List<int> { 0, 4, 6, 7, 10 };
            this.OcultarColumnas(exclusiones);
        }



        // Metodo que carga el data grid de clientes.
        protected override void ObtenerDatos()
        {
            this.myGrid.DataSource = null;
            try
            {
                IDaoContrato myDao = DaoContrato.Crear();
                if (this.myFiltro == TipoFiltro.Todo) myGrid.DataSource = myDao.ObtenerListaContratos();
                if (this.myFiltro == TipoFiltro.NumeroContrato) myGrid.DataSource = myDao.ObtenerListaContratosPorNumeroDeContrato(this.textoFiltro);
                if (this.myFiltro == TipoFiltro.Rut) myGrid.DataSource = myDao.ObtenerListaContratosPorRut(this.textoFiltro);
                if (this.myFiltro == TipoFiltro.NumeroPoliza) myGrid.DataSource = myDao.ObtenerListaContratosPorNumeroDePoliza(this.textoFiltro);
            }
            catch (Exception ex)
            {
                this.MostrarMensajeDeError(ex);
            }
        }





    }
}
