using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class ContactoDatos
    {
        private const string SelectBase =
            "SELECT c.IdContacto, c.Nombre, c.Telefono, c.Correo, c.IdGrupo, g.Nombre AS Grupo " +
            "FROM Contacto c INNER JOIN Grupo g ON g.IdGrupo = c.IdGrupo ";

        public DataTable Listar()
        {
            return Consultar(SelectBase + "ORDER BY c.Nombre");
        }

        public DataTable FiltrarPorGrupo(int idGrupo)
        {
            string sql = SelectBase + "WHERE c.IdGrupo = @IdGrupo ORDER BY c.Nombre";
            return Consultar(sql, new SqlParameter("@IdGrupo", idGrupo));
        }

        public DataTable BuscarPorNombre(string texto)
        {
            string sql = SelectBase + "WHERE c.Nombre LIKE @Texto ORDER BY c.Nombre";
            return Consultar(sql, new SqlParameter("@Texto", "%" + texto + "%"));
        }

        public void Insertar(string nombre, string telefono, string correo, int idGrupo)
        {
            string sql = "INSERT INTO Contacto (Nombre, Telefono, Correo, IdGrupo) " +
                         "VALUES (@Nombre, @Telefono, @Correo, @IdGrupo)";
            Ejecutar(sql,
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Telefono", telefono),
                new SqlParameter("@Correo", correo),
                new SqlParameter("@IdGrupo", idGrupo));
        }

        public void Modificar(int idContacto, string nombre, string telefono, string correo, int idGrupo)
        {
            string sql = "UPDATE Contacto SET Nombre = @Nombre, Telefono = @Telefono, " +
                         "Correo = @Correo, IdGrupo = @IdGrupo WHERE IdContacto = @IdContacto";
            Ejecutar(sql,
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Telefono", telefono),
                new SqlParameter("@Correo", correo),
                new SqlParameter("@IdGrupo", idGrupo),
                new SqlParameter("@IdContacto", idContacto));
        }

        public void Eliminar(int idContacto)
        {
            string sql = "DELETE FROM Contacto WHERE IdContacto = @IdContacto";
            Ejecutar(sql, new SqlParameter("@IdContacto", idContacto));
        }

        // Para nuevo contacto pasa idContacto = 0. Para modificar, pasa el id del contacto.
        public bool ExisteTelefono(string telefono, int idContacto)
        {
            string sql = "SELECT COUNT(*) FROM Contacto WHERE Telefono = @Telefono AND IdContacto <> @IdContacto";
            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add(new SqlParameter("@Telefono", telefono));
                cmd.Parameters.Add(new SqlParameter("@IdContacto", idContacto));
                cn.Open();
                int cantidad = (int)cmd.ExecuteScalar();
                if (cantidad > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private DataTable Consultar(string sql, params SqlParameter[] parametros)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(parametros);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }

        private void Ejecutar(string sql, params SqlParameter[] parametros)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(parametros);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}