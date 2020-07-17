using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Vista.Controles.MsgBox;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Controlador.Enumeraciones;

namespace BeLife.Vista.Comandos
{
    public abstract class CmdCargarDataGrid
    {

        // Miembros privados.
        protected string textoFiltro;
        protected Form myForm;
        protected DataGridView myGrid;
        protected TipoFiltro myFiltro;
        private bool ocurrioError;

        // Propiedades.
        public bool OcurrioError { get { return this.ocurrioError; } }


        // Propiedades.
        public string TextoResultado { get; set; }


        // Constructores.
        protected CmdCargarDataGrid(Form myForm, DataGridView myGrid, TipoFiltro myFiltro, string textoFiltro)
        {
            this.ocurrioError = false;
            this.myForm= myForm;
            this.myGrid = myGrid;
            this.myFiltro = myFiltro;
            this.textoFiltro = textoFiltro;
        }


        protected CmdCargarDataGrid(Form myForm, DataGridView myGrid, string textoFiltro)
        {
            this.ocurrioError = false;
            this.myForm = myForm;
            this.myGrid = myGrid;
            this.textoFiltro = textoFiltro;
        }


        // Metodo abstracto para cargar los datos a la grilla.
        protected abstract void ObtenerDatos();


        // Metodo que muestra el error ocurrido en tiempo de carga de los datos.
        protected void MostrarMensajeDeError(Exception ex)
        {
            this.ocurrioError = true;
            string mensajeError =ex.Source.ToString()+" - "+ex.Message.ToString();
            MsgBox.Show(this.myForm, mensajeError, StringResources.TituloMensajes_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        // Asigna el resultado de la carga de datos en la grilla.
        protected void asignarResultado(string tipoResultado)
        {
            if (myGrid.Rows.Count > 0) this.TextoResultado = string.Format(StringResources.ResultadoDataGrid_ItemsEncontrados, myGrid.Rows.Count.ToString(),tipoResultado );
            else this.TextoResultado = string.Format(StringResources.ResultadoDataGrid_SinRegistros,tipoResultado);
        }


        // Metodo para configurar las columnas de la grilla de contratos.
        protected void OcultarColumnas(IList<int> exclusiones)
        {
            foreach (DataGridViewColumn myColumn in this.myGrid.Columns)
            {
                myColumn.Visible = false;
                if (exclusiones.Contains(myColumn.Index))
                {
                    myColumn.Visible = true;
                    myColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }




    }
}
