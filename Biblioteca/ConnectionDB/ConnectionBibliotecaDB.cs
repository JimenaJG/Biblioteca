using Microsoft.Data.SqlClient;

namespace Biblioteca.ConnectionDB
{
    public static class ConnectionBibliotecaDB
    {
        // Make connectionString static so it can be accessed from the static method
        private static string connectionString = "Server=localhost;Database=Mundo_EscolarDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
