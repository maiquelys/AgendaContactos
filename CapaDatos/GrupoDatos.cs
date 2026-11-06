using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class GrupoDatos
    {
        public DataTable Listar()
        {
            string sql = "SELECT IdGrupo, Nombre FROM Grupo ORDER BY Nombre";
            return Consultar(sql);
        }

        public DataTable ContarContactosPorGrupo()
        {
            string sql = "SELECT g.Nombre AS Grupo, COUNT(c.IdContacto) AS Cantidad " +
                         "FROM Grupo g " +
                         "LEFT JOIN Contacto c ON c.IdGrupo = g.IdGrupo " +
                         "GROUP BY g.Nombre ORDER BY g.Nombre";
            return Consultar(sql);
        }

        private DataTable Consultar(string sql)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }
    }
}