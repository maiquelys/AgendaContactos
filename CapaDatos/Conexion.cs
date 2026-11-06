using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        private static readonly string cadena =
            "Server=localhost;Database=AgendaContactos;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}