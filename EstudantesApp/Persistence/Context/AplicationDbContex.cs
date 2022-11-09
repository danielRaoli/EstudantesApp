using EstudantesApp.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using EstudantesApp.Transporte;

namespace EstudantesApp.Persistence.Context
{
    public class AplicationDbContex : DbContext
    {
        public DbSet<Estudante> Estudantes { get; set; }
        public AplicationDbContex(DbContextOptions<AplicationDbContex> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder); 
    }
        public DbSet<EstudantesApp.Transporte.EstudanteDTO> EstudanteDTO { get; set; }
    }
}
