using System.Collections.Generic;
using BeLife.Controlador.Consultas;
using BeLife.Datos.ConsultarDatos;
using BeLife.Modelo.Dto;

namespace BeLife.Controlador.DAO
{
    public class DaoSexo : IDaoSexo
    {
        // Constructor
        private DaoSexo()
        { }


        // Metodo de construccion.
        public static DaoSexo crear()
        {
            return new DaoSexo();
        }


        // Metodo para listar sexos.
        public List<DtoSexo> ObtenerListaSexo()
        {
            try
            {
                var listaSexo = ConsultarDatos.Crear(StringResources.querySexo_ListarTodo);
                return listaSexo.ObtenerResultadosDeConsulta<DtoSexo>();
            }
            catch
            {
                throw;
            }
        }


    }
}
