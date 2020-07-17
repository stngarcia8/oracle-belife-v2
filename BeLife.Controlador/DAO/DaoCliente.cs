using System.Collections.Generic;
using System.Data;
using BeLife.Controlador.Consultas;
using BeLife.Datos.ConsultarDatos;
using BeLife.Modelo.Clases;
using BeLife.Modelo.Dto;

namespace BeLife.Controlador.DAO
{
    public class DaoCliente : IDaoCliente
    {

        // Constructor.
        private DaoCliente()

        { }


        // metodos de creacion de objeto.
        public static DaoCliente Crear()
        {
            return new DaoCliente();
        }


        // Metodo para crear un cliente.
        public int NuevoCliente(Cliente myCliente)
        {
            int registro = 0;
            try
            {
                var nuevoCliente = EjecutarConsultas.Crear(StringResources.queryCliente_Insertar);
                nuevoCliente.AgregarParametro("rutCliente", myCliente.Rut, DbType.String);
                this.establecerParametros(nuevoCliente, myCliente);
                registro = nuevoCliente.Ejecutar();
                nuevoCliente.CerrarConsulta();
            }
            catch
            {
                throw;
            }
            return registro;
        }


        // Metodo para actualizar un cliente.
        public int ActualizarCliente(Cliente myCliente)
        {
            int registro = 0;
            try
            {
                var actualizaCliente = EjecutarConsultas.Crear(StringResources.queryCliente_Actualizar);
                this.establecerParametros(actualizaCliente, myCliente);
                actualizaCliente.AgregarParametro("rutCliente", myCliente.Rut, DbType.String);
                registro = actualizaCliente.Ejecutar();
                actualizaCliente.CerrarConsulta();
            }
            catch
            {
                throw;
            }
            return registro;
        }


        // Metodo para agregar los parametros a la consulta.
        private void establecerParametros(EjecutarConsultas ejecutor, Cliente myCliente)
        {
            ejecutor.AgregarParametro("nombreCliente", myCliente.Nombre, DbType.String);
            ejecutor.AgregarParametro("apellidosCliente", myCliente.Apellido, DbType.String);
            ejecutor.AgregarParametro("fechaNacimiento", myCliente.Nacimiento, DbType.Date);
            ejecutor.AgregarParametro("idSexo", myCliente.IdSexo, DbType.Int16);
            ejecutor.AgregarParametro("idEstadoCivil", myCliente.IdEstadoCivil, DbType.Int16);
        }


        // Metodo para eliminar un cliente de la basede datos.
        public int eliminarCliente(string rutCliente)
        {
            try
            {
                int registro = 0;
                var eliminaCliente = EjecutarConsultas.Crear(StringResources.queryCliente_Eliminar);
                eliminaCliente.AgregarParametro("RutCliente", rutCliente, System.Data.DbType.String);
                registro = eliminaCliente.Ejecutar();
                eliminaCliente.CerrarConsulta();
                return registro;
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar los clientes.
        public List<DtoCliente> ObtenerListaClientes()
        {
            try
            {
                var listaCliente = ConsultarDatos.Crear(StringResources.queryCliente_ListarTodo);
                return listaCliente.ObtenerResultadosDeConsulta<DtoCliente>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar los clientes por rut.
        public List<DtoCliente> ObtenerListaClientesPorRut(string rutCliente)
        {
            try
            {
                var listaCliente = ConsultarDatos.Crear(StringResources.queryCliente_ListarPorRut);
                listaCliente.AgregarParametro("RutCliente", rutCliente, DbType.String);
                return listaCliente.ObtenerResultadosDeConsulta<DtoCliente>();
            }
            catch
            {
                throw;
            }
        }



        // Metodo para listar los clientes por estado civil.
        public List<DtoCliente> ObtenerListaClientesPorEstadoCivil(int idEstadoCivil)
        {
            try
            {
                var listaCliente = ConsultarDatos.Crear(StringResources.queryCliente_ListarPorEstadoCivil);
                listaCliente.AgregarParametro("idEstadoCivil", idEstadoCivil, DbType.Int16);
                return listaCliente.ObtenerResultadosDeConsulta<DtoCliente>();
            }
            catch
            {
                throw;
            }
        }


        // Metodo para listar los clientes por sexo.
        public List<DtoCliente> ObtenerListaClientesPorSexo(int idSexo)
        {
            try
            {
                var listaCliente = ConsultarDatos.Crear(StringResources.queryCliente_ListarPorSexo);
                listaCliente.AgregarParametro("idSexo", idSexo, DbType.Int16);
                return listaCliente.ObtenerResultadosDeConsulta<DtoCliente>();
            }
            catch
            {
                throw;
            }
        }



        // Metodo para listar los clientes por rut.
        public List<DtoContratoCliente> ObtenerListaContratossPorRut(string rutCliente)
        {
            try
            {
                var listaCliente = ConsultarDatos.Crear(StringResources.queryCliente_ListaContratos);
                listaCliente.AgregarParametro("RutCliente", rutCliente, DbType.String);
                return listaCliente.ObtenerResultadosDeConsulta<DtoContratoCliente>();
            }
            catch
            {
                throw;
            }
        }





    }
}
