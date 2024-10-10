using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EcoSolution.Infra.Data.Context
{
    public class EcoSolutionContext : DbContext
    {
        public EcoSolutionContext(DbContextOptions<EcoSolutionContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        #region DbSets

        public DbSet<Arquivo> Arquivo { get; set; }

        public DbSet<ArquivoVinculado> ArquivoVinculado { get; set; }

        public DbSet<Equipamento> Equipamento { get; set; }

        public DbSet<Manual> Manual { get; set; }

        public DbSet<Material> Material { get; set; }

        public DbSet<Tarefa> Tarefa { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);   
        }

    }
}
