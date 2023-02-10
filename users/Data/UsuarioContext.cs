using Microsoft.EntityFrameworkCore;
using users.Model;

namespace users.Data {
    public class UsuarioContext : DbContext {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options) {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            var usuario = modelBuilder.Entity<UsuarioModel>();
            usuario.ToTable("usuario");
            usuario.HasKey(x => x.Id);
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            usuario.Property(x => x.DataNascimento).HasColumnName("data_nascimento");
        }
        
    }
}
