using System;
using BeLife.Aplicacion.Idiomas.Localizacion;
using System.Collections.Generic;
using System.Linq;
using BeLife.Controlador.DAO;
using BeLife.Modelo.Dto;

namespace BeLife.Controlador.Comandos
{
    public class CmdBuscarContrato : CmdBuscar, IComando
    {

        // Propiedades.
        public DtoContrato MyContrato { get; set; }

        // Constructor.
        private CmdBuscarContrato(string nroContrato)
            : base(nroContrato)
        {
            MyContrato = null;
        }


        // Metodo creador del comando.
        public static CmdBuscarContrato Crear(string nroContrato)
        {
            return new CmdBuscarContrato(nroContrato);
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
                List<DtoContrato> myList = myDao.ObtenerListaContratosPorNumeroDeContrato(this.textoQueBuscar);
                this.MyContrato = myList.FirstOrDefault<DtoContrato>();
                this.MensajeBusqueda = (this.MyContrato != null ?
                    string.Format(StringResources.BuscarContrato_Existente,MyContrato.Numero) :
                    StringResources.BuscarContrato_NoExiste);
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
