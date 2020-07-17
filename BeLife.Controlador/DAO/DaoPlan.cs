using System.Collections.Generic;
using BeLife.Controlador.Consultas;
using BeLife.Datos.ConsultarDatos;
using BeLife.Modelo.Dto;

namespace BeLife.Controlador.DAO
{
    public class DaoPlan : IDaoPlan
    {

        // Constructor
        private DaoPlan()
        { }


        // Metodo de construccion.
        public static DaoPlan Crear()
        {
            return new DaoPlan();
        }


        // Metodo para listar los planes.
        public List<DtoPlan> ObtenerListaDePlanes()
        {
            try
            {
                var listaPlan = ConsultarDatos.Crear(StringResources.queryPlan_ListarTodo);
                return listaPlan.ObtenerResultadosDeConsulta<DtoPlan>();
            }
            catch
            {
                throw;
            }
        }


    }
}
