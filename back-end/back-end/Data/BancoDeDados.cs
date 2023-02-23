using back_end.Data.Map;
using back_end.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data
{
    public class BancoDeDados : IdentityDbContext<IdentityUser>
    {
        public BancoDeDados(DbContextOptions<BancoDeDados> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(builder);
        }

        

    }
}
