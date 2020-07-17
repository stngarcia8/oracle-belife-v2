using System.Collections.Generic;
using System.Data;
using BeLife.Controlador.Consultas;
using BeLife.Datos.ConsultarDatos;
using BeLife.Modelo.Clases;
using BeLife.Modelo.Dto;

namespace BeLife.Controlador.DAO
{
    public class DaoContrato : IDaoContrato
    {

        // Constructor.
        private DaoContrato()
        { }


        // metodos de creacion de objeto.
        public static DaoContrato Crear()
        {
            return new DaoContrato();
        }


        // Metodo para crear un contrato.
        public int NuevoContrato(Contrato myContrato)
        {
            int registro = 0;
            try
            {
                var nuevoContrato = EjecutarConsultas.Crear(StringResources.queryContrato_Insertar);
                nuevoContrato.AgregarParametro("numero", myContrato.NumeroContrato, DbType.String);
                this.establecerParametros(nuevoContrato, myContrato, true);
                registro = nuevoContrato.Ejecutar();
                nuevoContrato.CerrarConsulta();
            }
            catch
            {
                throw;
            }
            return registro;
        }


        // Metodo para actualizar un contrato.
        public int ActualizarContrato(Contrato myContrato)
        {
            int registro = 0;
            try
            {
                var actualizaContrato = EjecutarConsultas.Crear(StringResources.queryContrato_Actualizar);
                this.establecerParametros(actualizaContrato, myContrato, false);
                actualizaContrato.AgregarParametro("numero", myContrato.NumeroContrato, DbType.String);
                actualizaContrato.AgregarParametro("rutCliente", myContrato.RutCliente, DbType.String);
                registro = actualizaContrato.Ejecutar();
                actualizaContrato.CerrarConsulta();
            }
            catch
            {
                throw;
            }
            return registro;
        }


        // Metodo para agregar los parametros a la consulta.
        private void establecerParametros(EjecutarConsultas ejecutor, Contrato myContrato, bool insertando)
        {
            ejecutor.AgregarParametro("fechaInicioContrato", myContrato.FechaInicioContrato, DbType.Date);
            ejecutor.AgregarParametro("fechaTerminoContrato", myContrato.FechaTerminoContrato, DbType.Date);
            if (insertando) ejecutor.AgregarParametro("rutCliente", myContrato.RutCliente, DbType.String);
            ejecutor.AgregarParametro("idPlan", myContrato.IdPlan, DbType.String);
            ejecutor.AgregarParametro("inicioVigencia", myContrato.FechaInicioDeVigencia, DbType.Date);
            ejecutor.AgregarParametro("terminoVigencia", myContrato.FechaTerminoDeVigencia, DbType.Date);
            ejecutor.AgregarParametro("vigente", myContrato.VigenciaContrato, DbType.Int16);
            ejecutor.AgregarParametro("salud", myContrato.DeclaracionDeSalud, DbType.Int16);
            ejecutor.AgregarParametro("primaAnual", myContrato.PrimaAnual, DbType.Double);
            ejecutor.AgregarParametro("primaMensual", myContrato.PrimaMensual, DbType.Double);
            ejecutor.AgregarParametro("observaciones", myContrato.Observaciones, DbType.String);
        }


        // Metodo para listar los contratos.
        public List<DtoContrato> ObtenerListaContratos()
        {
            try
            {
                var listaContrato = ConsultarDatos.Crear(StringResources.queryContrato_ListarTodo);
                return listaContrato.ObtenerResultadosDeConsulta<DtoContrato>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar los contratos por numero de contrato.
        public List<DtoContrato> ObtenerListaContratosPorNumeroDeContrato(string numero)
        {
            try
            {
                var listaContrato = ConsultarDatos.Crear(StringResources.queryContrato_ListarPorNumeroContrato);
                listaContrato.AgregarParametro("numero", numero, DbType.String);
                return listaContrato.ObtenerResultadosDeConsulta<DtoContrato>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar los contratos por rut.
        public List<DtoContrato> ObtenerListaContratosPorRut(string rutCliente)
        {
            try
            {
                var listaContrato = ConsultarDatos.Crear(StringResources.queryContrato_ListarPorRut);
                listaContrato.AgregarParametro("RutCliente", rutCliente, DbType.String);
                return listaContrato.ObtenerResultadosDeConsulta<DtoContrato>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar los contratos por numero de poliza
        public List<DtoContrato> ObtenerListaContratosPorNumeroDePoliza(string poliza)
        {
            try
            {
                var listaContrato = ConsultarDatos.Crear(StringResources.queryContrato_ListarPorNumeroDePoliza);
                listaContrato.AgregarParametro("poliza", poliza, DbType.String);
                return listaContrato.ObtenerResultadosDeConsulta<DtoContrato>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar el contrato de un cliente con el numero de contrato especificado y que este vigente.
        public List<DtoContrato> VerificarVigenciaDeContratoDeCliente(string rutCliente, string idPlan)
        {
            try
            {
                var listaContrato = ConsultarDatos.Crear(StringResources.queryContrato_VerificarVigenciaDeContrato);
                listaContrato.AgregarParametro("rutCliente", rutCliente, DbType.String);
                listaContrato.AgregarParametro("idPlan", idPlan, DbType.String);
                return listaContrato.ObtenerResultadosDeConsulta<DtoContrato>();
            }
            catch
            {
                throw;
            }
        }


    }
}
