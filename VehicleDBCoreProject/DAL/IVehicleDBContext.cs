using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Vehicle.DAL
{
    public interface IVehicleDBContext
    {
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync();
        EntityEntry Entry(object entity);
        void Dispose();

    }
}
