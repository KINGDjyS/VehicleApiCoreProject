using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehicle.DAL;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly IVehicleDBContext Context;

        public GenericRepository(IVehicleDBContext context)
        {
            Context = context;
        }

        public async Task<T> Add(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            //await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            //Context.Set<T>().Attach(entity);
            Context.Set<T>().Remove(entity);
            //await Context.SaveChangesAsync();
            return await Task.FromResult(entity);
        }

        public Task<IQueryable<T>> Get()
        {
           return Task.FromResult(Context.Set<T>().AsQueryable());
        }

        public Task<T> GetById(int id)
        {
            return Task.FromResult(Context.Set<T>().Find(id));
        }

        public async Task<T> Update(int id, T entity)
        {
            //var maker = Context.Set<T>().Find(entity);
            //maker.GetType.entity = EntityState.Modified;
            //Context.Set<T>().Attach(entity).State = EntityState.Modified;
            //Context.Entry();
            //Context.Entity<T>(entity).State = EntityState.Modified;
            //Context.Set<T>().Attach(entity);
            //Console.WriteLine(maker.EntityType);
            //Context.Set<T>().Update(entity).State = EntityState.Detached;
            //Context.Set<T>().Attach(entity).State = EntityState.Modified;
            //maker.State = EntityState.Modified;
            var maker = await Context.Set<T>().FindAsync(id);
            Context.Entry(maker).CurrentValues.SetValues(entity);
            //Context.Entry(entity).State = EntityState.Modified;
            //await Context.SaveChangesAsync();
            return maker;
        }
    }
}
