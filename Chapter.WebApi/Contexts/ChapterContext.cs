using Chapter.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter.WebApi.Contexts
{
    // dbcontext é a ponte entre o modelo de classe e o banco de dados
    public class ChapterContext : DbContext
    {
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options)
        {
        }
        // Método para configurar banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação
                optionsBuilder.UseSqlServer("Data Source=PE07ZKZL\\SQLEXPRESS; initial catalog=ChapterContext; Integrated Security=SSPI");
            }
        }
        // dbset representa as entidades que serão utilizadas nas operações do crud;
        public DbSet<Livro> Livros { get; set; }
    }
}
