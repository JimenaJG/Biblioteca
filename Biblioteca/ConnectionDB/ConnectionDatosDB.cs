using Microsoft.Data.SqlClient;
using System;

class Program
{
    static void Main()
    {
        string connectionString = "Server=nombre_servidor;Database=nombre_base_datos;User Id=usuario;Password=contraseña;";

        // Crear la conexión
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexión exitosa!");

                // Ejecutar un procedimiento almacenado
                using (SqlCommand command = new SqlCommand("nombre_del_procedimiento", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Si el procedimiento tiene parámetros
                    command.Parameters.AddWithValue("@parametro1", "valor1");
                    command.Parameters.AddWithValue("@parametro2", "valor2");

                    // Ejecutar el comando
                    command.ExecuteNonQuery();
                    Console.WriteLine("Procedimiento ejecutado con éxito.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
