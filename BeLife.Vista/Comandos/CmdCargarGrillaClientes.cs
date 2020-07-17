using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Controlador.DAO;
using BeLife.Controlador.Enumeraciones;

namespace BeLife.Vista.Comandos
{


    public class CmdCargarGrillaClientes : CmdCargarDataGrid, IComando
    {


        // Constructor.
        private CmdCargarGrillaClientes(Form myForm, DataGridView myGrid, TipoFiltro myFiltro, string textoFiltro)
            : base(myForm, myGrid, myFiltro, textoFiltro)
        { }


        // Metodo para crear objeto.
        public static CmdCargarGrillaClientes Crear(Form myForm, DataGridView myGrid, TipoFiltro myFiltro, string textoFiltro)
        {
            return new CmdCargarGrillaClientes(myForm, myGrid, myFiltro, textoFiltro);
        }


        public void Ejecutar()
        {
            this.ObtenerDatos();
            this.asignarResultado(StringResources.ResultadoDataGrid_TipoCliente);
            IList<int> exclusiones = new List<int> { 0, 1, 2, 5, 7 };
            this.OcultarColumnas(exclusiones);
        }


        // Metodo que carga el data grid de clientes.
        protected override void ObtenerDatos()
        {
            this.myGrid.DataSource = null;
            try
            {
                IDaoCliente myDao = DaoCliente.Crear();
                if (this.myFiltro == TipoFiltro.Todo) myGrid.DataSource = myDao.ObtenerListaClientes();
                if (this.myFiltro == TipoFiltro.Rut) myGrid.DataSource = myDao.ObtenerListaClientesPorRut(this.textoFiltro);
                if (this.myFiltro == TipoFiltro.EstadoCivil) myGrid.DataSource = myDao.ObtenerListaClientesPorEstadoCivil(int.Parse(this.textoFiltro));
                if (this.myFiltro == TipoFiltro.Sexo) myGrid.DataSource = myDao.ObtenerListaClientesPorSexo(int.Parse(this.textoFiltro));
            }
            catch (Exception ex)
            {
                this.MostrarMensajeDeError(ex);
            }
        }



    }
}
