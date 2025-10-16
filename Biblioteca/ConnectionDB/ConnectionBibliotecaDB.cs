using Microsoft.Data.SqlClient;

namespace Biblioteca.ConnectionDB
{
    public static class ConnectionBibliotecaDB
    {
        // Make connectionString static so it can be accessed from the static method
        private static string connectionString = "Server=192.168.137.1,1433;Database=Biblioteca;User Id=Biblioteca;Password=12345678;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
