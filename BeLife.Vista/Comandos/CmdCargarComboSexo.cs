using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Controlador.DAO;
using BeLife.Modelo.Dto;

namespace BeLife.Vista.Comandos
{
    public class CmdCargarComboSexo : CmdCargarComboBox, IComando
    {

        // Propiedades.
        public IList<DtoSexo> SexoList { get; set; }

        // Constructor.
        private CmdCargarComboSexo(Form myForm, ComboBox myComboBox)
            : base(myForm, myComboBox)
        {
            this.SexoList = new List<DtoSexo>();
        }


        // Metodo creador del objeto.
        public static CmdCargarComboSexo crear(Form myForm, ComboBox myComboBox)
        {
            return new CmdCargarComboSexo(myForm, myComboBox);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            this.myComboBox.BeginUpdate();
            this.ObtenerDatos();
            this.PrepararControl("DESCRIPCION", "IDSEXO");
        }


        // metodo que carga la lista de sexos.
        protected override void ObtenerDatos()
        {
            try
            {
                IDaoSexo myDao = DaoSexo.crear();
                this.SexoList = myDao.ObtenerListaSexo();
                this.InsertarValorInicial(false);
                this.myComboBox.DataSource = this.SexoList;
            }
            catch (Exception ex)
            {
                this.InsertarValorInicial(true);
                this.MostrarMensajeDeError(ex);
            }
        }


        private void InsertarValorInicial(bool hayError)
        {
            DtoSexo myDto = new DtoSexo();
            myDto.IdSexo = 0;
            myDto.Descripcion = (hayError?StringResources.ItemInicial_Sexo_Error:StringResources.ItemInicial_Sexo_Correcto);
            this.SexoList.Insert(0, myDto);
        }


    }
}
