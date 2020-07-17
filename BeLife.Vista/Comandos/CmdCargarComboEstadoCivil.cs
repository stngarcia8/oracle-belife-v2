using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Controlador.DAO;
using BeLife.Aplicacion.Idiomas.Localizacion;
using BeLife.Modelo.Dto;

namespace BeLife.Vista.Comandos
{
    public class CmdCargarComboEstadoCivil : CmdCargarComboBox, IComando
    {


        public IList<DtoEstadoCivil> EstadoCivilList { get; set; }

        // Constructor.
        private CmdCargarComboEstadoCivil(Form myForm,   ComboBox myComboBox)
            : base(myForm, myComboBox)
        {
            this.EstadoCivilList = new List<DtoEstadoCivil>();
        }


        // Metodo creador del objeto.
        public static CmdCargarComboEstadoCivil crear(Form myForm,  ComboBox myComboBox)
        {
            return new CmdCargarComboEstadoCivil(myForm, myComboBox);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            this.myComboBox.BeginUpdate();
            this.ObtenerDatos();
            this.PrepararControl("DESCRIPCION", "IDESTADOCIVIL");
        }


        // Metodo que carga la lista de estados civiles.
        protected override void ObtenerDatos()
        {
            try
            {
                IDaoEstadoCivil myDao = DaoEstadoCivil.crear();
                this.EstadoCivilList = myDao.ObtenerListaEstadoCivil();
                this.InsertarValorInicial(false);
                this.myComboBox.DataSource = this.EstadoCivilList;
            }
            catch (Exception ex)
            {
                this.InsertarValorInicial(true);
                this.MostrarMensajeDeError(ex);
            }
        }


        private void InsertarValorInicial(bool hayError)
        {
            DtoEstadoCivil myDto = new DtoEstadoCivil();
            myDto.IdEstadoCivil = 0;
            myDto.Descripcion = (hayError ? StringResources.ItemInicial_EstadoCivil_Error : StringResources.ItemInicial_EstadoCivil_Correcto);
            this.EstadoCivilList.Insert(0, myDto);
        }


    }
}
