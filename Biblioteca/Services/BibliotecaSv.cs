using Biblioteca.ConnectionDB;
using Biblioteca.Dtos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Biblioteca.Services
{
    public class BibliotecaSv
    {
        private static LibroDisponibleDto MapLibroDisponible(SqlDataReader rd)
        {
            int iId = rd.GetOrdinal("id");
            int iTitulo = rd.GetOrdinal("titulo");
            int iAutor = rd.GetOrdinal("autor");
            int iGenero = rd.GetOrdinal("genero");
            int iAnio = rd.GetOrdinal("anio");
            int iStockTotal = rd.GetOrdinal("stock_total");
            int iStockDisponible = rd.GetOrdinal("stock_disponible");

            return new LibroDisponibleDto
            {
                Id = rd.IsDBNull(iId) ? 0 : rd.GetInt32(iId),
                Titulo = rd.IsDBNull(iTitulo) ? "" : rd.GetString(iTitulo),
                Autor = rd.IsDBNull(iAutor) ? "" : rd.GetString(iAutor),
                Genero = rd.IsDBNull(iGenero) ? "" : rd.GetString(iGenero),
                Anio = rd.IsDBNull(iAnio) ? 0 : rd.GetInt32(iAnio),
                StockTotal = rd.IsDBNull(iStockTotal) ? 0 : rd.GetInt32(iStockTotal),
                StockDisponible = rd.IsDBNull(iStockDisponible) ? 0 : rd.GetInt32(iStockDisponible)
            };
        }

        public void RegistrarPrestamo(int libroId, int usuarioId)
        {
            using var cn = ConnectionBibliotecaDB.GetConnection();
            cn.Open();
            using var cmd = new SqlCommand("dbo.sp_registrar_prestamo", cn)
            {
                CommandType = CommandType.StoredProcedure
            };

            // SP params: @libro_id, @usuario_id
            cmd.Parameters.AddWithValue("@libro_id", libroId);
            cmd.Parameters.AddWithValue("@usuario_id", usuarioId);

            cmd.ExecuteNonQuery();
        }

        public LibroDisponibleDto ObtenerLibrosDisponibles()
        {
            using var cn = ConnectionBibliotecaDB.GetConnection();
            cn.Open();
            using var cmd = new SqlCommand("SELECT * FROM dbo.v_libros_disponibles", cn)
            {
                CommandType = CommandType.Text
            };

            using var rd = cmd.ExecuteReader();
            if (rd.Read())
                return MapLibroDisponible(rd);

            throw new InvalidOperationException("No se encontró libros disponibles.");
        }

        public LibroDisponibleListResult ListarLibrosDisponibles(int page = 1, int pageSize = 10)
        {
            var result = new LibroDisponibleListResult { Page = page, PageSize = pageSize };

            using var cn = ConnectionBibliotecaDB.GetConnection();
            cn.Open();
            using var cmd = new SqlCommand("SELECT * FROM dbo.v_libros_disponibles", cn)
            {
                CommandType = CommandType.Text
            };

            using var rd = cmd.ExecuteReader();

            // Result set 1: items
            while (rd.Read())
                result.Items.Add(MapLibroDisponible(rd));

            // Result set 2: total
            if (rd.NextResult() && rd.Read())
                result.Total = rd.IsDBNull(0) ? 0 : rd.GetInt32(0);

            return result;
        }
    }
}
