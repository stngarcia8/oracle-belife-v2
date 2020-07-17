using System.Collections.Generic;
using System.Data;

namespace BeLife.Datos.ConsultarDatos
{
    public interface IConsultarDatos
    {

        void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoParametro);
        List<Entidad> ObtenerResultadosDeConsulta<Entidad>() where Entidad : class;

    }
}
