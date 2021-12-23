using Chapter.WebApi.Contexts;
using Chapter.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Chapter.WebApi.Repositories
{
    public class LivroRepository
    {
        // Possui acesso aos dados
        private readonly ChapterContext _context;

        public LivroRepository(ChapterContext context)
        {
            _context = context;
        }

        public List<Livro> Listar()
        {
            // SELECT Id, Titulo, NumPaginas, Disponível FROM livros;
            return _context.Livros.ToList();
        }

        public Livro ObterPorId(int id)
        {
            return _context.Livros.FirstOrDefault(x => x.Id == id);
        }

        public void Adicionar(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }
    }
}
