using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Collections.Generic;
using System.Linq;
using BeLife.Controlador.DAO;
using BeLife.Modelo.Dto;

namespace BeLife.Controlador.Comandos
{
    public class CmdBuscarContratoVigente : CmdBuscar, IComando
    {

        // Propiedades.
        public DtoContrato MyContrato { get; set; }

        // Constructor.
        private CmdBuscarContratoVigente(string rutCliente, string idPlan)
            : base(rutCliente, idPlan)
        {
            MyContrato = null;
        }


        // Metodo creador del comando.
        public static CmdBuscarContratoVigente Crear(string rutCliente, string idPlan)
        {
            return new CmdBuscarContratoVigente(rutCliente, idPlan);
        }


        // Metodo que ejecuta el comando.
        public void Ejecutar()
        {
            this.fueEncontrado = this.ObtenerDatos();
        }


        // Metodo que busca la informacion del contrato.
        protected override bool ObtenerDatos()
        {
            try
            {
                IDaoContrato myDao = DaoContrato.Crear();
                List<DtoContrato> myList = myDao.VerificarVigenciaDeContratoDeCliente(this.textoQueBuscar, textoQueBuscar2);
                this.MyContrato = myList.FirstOrDefault<DtoContrato>();
                this.MensajeBusqueda = (this.MyContrato != null ?
                    string.Format(StringResources.BuscarContratoVigente_Existente, MyContrato.Cliente,  MyContrato.Nombre_plan, MyContrato.Termino_vigencia):
                    StringResources.BuscarContratoVigente_NoExiste);
                return (this.MyContrato != null ? true : false);
            }
            catch (Exception ex)
            {
                this.MarcarError(ex);
                return false;
            }
        }

    }
}
