using System;
using System.Data.SqlClient;

namespace CODIGO
{
    public class Connection
    {
        private string connectionString;
        private SqlConnection connection;

        public Connection()
        {
            
            connectionString = @"Server=(localdb)\pruebas;Integrated Security=true;Database=exam;";
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection AbrirConexion()
        {
            try
            {
                connection.Open(); 
                return connection;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
                return null;
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}
