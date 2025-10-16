using Biblioteca.Dtos;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBibliotecaSv _bibliotecaSv;

        public BibliotecaController(IBibliotecaSv bibliotecaSv)
        {
            _bibliotecaSv = bibliotecaSv;
        }


        // GET: api/<BibliotecaController>
        [HttpGet]
        public LibroDisponibleDto Get()
        {
            return _bibliotecaSv.ObtenerLibrosDisponibles();
        }

        // GET: api/<BibliotecaController>
        [HttpGet("Disponibles")]
        public LibroDisponibleListResult Get(int page = 1, int pageSize = 10)
        {
            return _bibliotecaSv.ListarLibrosDisponibles(page, pageSize);
        }

        // POST api/<BibliotecaController>
        [HttpPost]
        public void Post([FromBody] int libroId, int usuarioId)
        {
            _bibliotecaSv.RegistrarPrestamo(libroId, usuarioId);
        }
    }
}
