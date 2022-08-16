using JobPortal_API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal_API.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        private readonly ApplicationDbContext _db;
        private string secretKey;

        //public UserRepository(ApplicationDbContext db, IConfiguration configuration)
        //{
        //    _db = db;
        //    secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        //}


        public virtual DbSet<AplicacaoTrabalho> AplicacaoTrabalho { get; set; }
        public virtual DbSet<Candidato> Candidato { get; set; }
        public virtual DbSet<CV> CV { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Foto> Foto { get; set; }
        public virtual DbSet<LogoEmpresa> LogoEmpresa { get; set; }
        public virtual DbSet<OfertaEmprego> OfertaEmprego { get; set; }
        public virtual DbSet<FileCV> FileCV { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<LocalUser> LocalUsers { get; set; }

    }
}
