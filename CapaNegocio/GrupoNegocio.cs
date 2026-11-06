using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class GrupoNegocio
    {
        private GrupoDatos datos = new GrupoDatos();

        public DataTable Listar()
        {
            return datos.Listar();
        }

        public DataTable ContarContactosPorGrupo()
        {
            return datos.ContarContactosPorGrupo();
        }
    }
}