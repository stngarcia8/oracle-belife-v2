using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Collections.Generic;
using System.Windows.Forms;
using BeLife.Controlador.DAO;
using BeLife.Modelo.Dto;

namespace BeLife.Vista.Comandos
{
    public class CmdCargarComboPlan : CmdCargarComboBox, IComando
    {

        // Propiedades.
        public IList<DtoPlan> PlanList { get; set; }

        // Constructor.
        private CmdCargarComboPlan(Form myForm, ComboBox myComboBox)
            : base(myForm, myComboBox)
        {
            this.PlanList = new List<DtoPlan>();
        }


        // Metodo creador del objeto.
        public static CmdCargarComboPlan Crear(Form myForm, ComboBox myComboBox)
        {
            return new CmdCargarComboPlan(myForm, myComboBox);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            this.myComboBox.BeginUpdate();
            this.ObtenerDatos();
            this.PrepararControl("Nombre", "IDPlan");
        }


        // Metodo que carga la lista de planes.
        protected override void ObtenerDatos()
        {
            try
            {
                IDaoPlan myDao = DaoPlan.Crear();
                this.PlanList = myDao.ObtenerListaDePlanes();
                this.myComboBox.DataSource = this.PlanList;
                this.InsertarValorInicial(false);
            }
            catch (Exception ex)
            {
                this.PlanList = new List<DtoPlan>();
                this.InsertarValorInicial(false);
                this.MostrarMensajeDeError(ex);
            }
        }


        private void InsertarValorInicial(bool hayError)
        {
            DtoPlan myDto = new DtoPlan();
            myDto.IdPlan = "0";
            myDto.Nombre = (hayError?StringResources.ItemInicial_Plan_Error:StringResources.ItemInicial_Plan_Correcto);
            myDto.PolizaActual = string.Empty;
            myDto.PrimaBase = 0;
            this.PlanList.Insert(0, myDto);
        }

    }
}
