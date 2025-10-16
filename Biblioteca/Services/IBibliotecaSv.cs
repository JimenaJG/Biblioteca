using Biblioteca.Dtos;

namespace Biblioteca.Services
{
    public interface IBibliotecaSv
    {
        public void RegistrarPrestamo(int libroId, int usuarioId);
        public LibroDisponibleDto ObtenerLibrosDisponibles();
        public LibroDisponibleListResult ListarLibrosDisponibles(int page = 1, int pageSize = 10);

    }
}
