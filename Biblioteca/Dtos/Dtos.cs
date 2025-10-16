namespace Biblioteca.Dtos
{
    public class LibroDisponibleDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Anio { get; set; }
        public int StockTotal { get; set; }
        public int StockDisponible { get; set; }
    }

    public class LibroDisponibleListResult
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public List<LibroDisponibleDto> Items { get; set; } = new List<LibroDisponibleDto>();
    }

    public class RegistrarPrestamoDto
    {
        public int LibroId { get; set; }
        public int UsuarioId { get; set; }
    }

    public class PrestamoDto
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public string Estado { get; set; } // 'prestado', 'devuelto', etc.
    }

}
