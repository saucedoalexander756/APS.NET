using Microsoft.EntityFrameworkCore;
using ApiVete.Models; 

namespace ApiVete.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cat_clientes"); 
                entity.HasKey(e => e.eCodCliente); 
            });

            // 2. Configuración de MASCOTAS
            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.ToTable("cat_mascotas");
                entity.HasKey(e => e.eCodMascota);

                // Relación con Cliente (Opcional, pero recomendada si tienes la propiedad)
                // entity.HasOne(d => d.Cliente).WithMany().HasForeignKey(p => p.eCodCliente);
            });

            
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("cat_productos");
                entity.HasKey(e => e.eCodProducto);
            });

           
            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("cat_ventas");
                entity.HasKey(e => e.eCodVenta);
            });

            
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.ToTable("ret_consultas");
                entity.HasKey(e => e.eCodConsulta);
            });
        }
    }
}
