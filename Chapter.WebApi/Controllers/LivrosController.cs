using Chapter.WebApi.Models;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Chapter.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivrosController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;

        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_livroRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var livro = _livroRepository.ObterPorId(id);
            
            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        [HttpPost]
        public IActionResult Adicionar(Livro livro)
        {
            _livroRepository.Adicionar(livro);
            return StatusCode(201);
            //return CreatedAtAction(nameof(Listar), new { id = livro.Id }, livro);
        }
    }
}
