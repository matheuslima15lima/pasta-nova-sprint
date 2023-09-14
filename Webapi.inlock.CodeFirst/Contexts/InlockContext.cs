using Microsoft.EntityFrameworkCore;
using Webapi.inlock.CodeFirst.Domains;

namespace Webapi.inlock.CodeFirst.Contexts
{
    public class InlockContext : DbContext
    {
        /// <summary>
        /// Definicao das entidades do banco de dados
        /// </summary>
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Estudio> Estudio { get; set; }

        public DbSet<Jogo> Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE18-S15 ; Database = inlock_games_codeFirst_tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = True");
            base.OnConfiguring(optionsBuilder);
        }



    }
}
