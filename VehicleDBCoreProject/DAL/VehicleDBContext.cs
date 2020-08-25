using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using Vehicle.DAL.Entities;

namespace Vehicle.DAL
{
    public class VehicleDBContext : DbContext, IVehicleDBContext
    {
        public VehicleDBContext()
        {

        }
        public VehicleDBContext(DbContextOptions<VehicleDBContext> options) : base(options)
        {

        }

        public DbSet<VehicleMakeEntity> VehicleMakers { get; set; }
        public DbSet<VehicleModelEntity> VehicleModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = (localDB)\\mssqllocaldb; Database = VehicleDBApiContext; Trusted_Connection = True; MultipleActiveResultSets = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehicleMakeEntity>().ToTable("VehicleMakers");

            modelBuilder.Entity<VehicleMakeEntity>().HasData(
                new VehicleMakeEntity { VehicleMakeId = 1, Name = "Bmw", Abrv = "BMW" },
                new VehicleMakeEntity { VehicleMakeId = 2, Name = "Jaguar", Abrv = "JAG" },
                new VehicleMakeEntity { VehicleMakeId = 3, Name = "Ford", Abrv = "FRD" },
                new VehicleMakeEntity { VehicleMakeId = 4, Name = "Nissan", Abrv = "NIS" },
                new VehicleMakeEntity { VehicleMakeId = 5, Name = "VolksWagen", Abrv = "VW" }
                );

            modelBuilder.Entity<VehicleModelEntity>().ToTable("VehicleModels");

            modelBuilder.Entity<VehicleModelEntity>().HasData(
                new VehicleModelEntity { VehicleModelId = 1, Name = "Touareg2", Abrv = "TO2", VehicleMakeId = 5 },
                new VehicleModelEntity { VehicleModelId = 2, Name = "340 Gran Turismo", Abrv = "340", VehicleMakeId = 1 },
                new VehicleModelEntity { VehicleModelId = 3, Name = "F-150", Abrv = "F15", VehicleMakeId = 3 },
                new VehicleModelEntity { VehicleModelId = 4, Name = "XE", Abrv = "XE", VehicleMakeId = 2 },
                new VehicleModelEntity { VehicleModelId = 5, Name = "GT-R", Abrv = "GTR", VehicleMakeId = 4 },
                new VehicleModelEntity { VehicleModelId = 6, Name = "Focus", Abrv = "FCS", VehicleMakeId = 3 },
                new VehicleModelEntity { VehicleModelId = 7, Name = "M550", Abrv = "550", VehicleMakeId = 1 },
                new VehicleModelEntity { VehicleModelId = 8, Name = "Jetta GLI", Abrv = "GLI", VehicleMakeId = 5 },
                new VehicleModelEntity { VehicleModelId = 9, Name = "350Z", Abrv = "350", VehicleMakeId = 4 },
                new VehicleModelEntity { VehicleModelId = 10, Name = "I-Pace", Abrv = "IPC", VehicleMakeId = 2 },
                new VehicleModelEntity { VehicleModelId = 11, Name = "Frontier", Abrv = "FRN", VehicleMakeId = 4 },
                new VehicleModelEntity { VehicleModelId = 12, Name = "F-Type Coupe", Abrv = "FTP", VehicleMakeId = 2 },
                new VehicleModelEntity { VehicleModelId = 13, Name = "Mustang", Abrv = "MST", VehicleMakeId = 3 },
                new VehicleModelEntity { VehicleModelId = 14, Name = "Arteon", Abrv = "ART", VehicleMakeId = 5 },
                new VehicleModelEntity { VehicleModelId = 15, Name = "228 Gran Coupe", Abrv = "228", VehicleMakeId = 1 }
                );
        }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public override EntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
