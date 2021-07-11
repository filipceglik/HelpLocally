using HelpLocally.Domain;
using HelpLocally.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpLocally.Services
{
    public class BaseService
    {
        protected readonly HelpLocallyContext _context;

        public BaseService(HelpLocallyContext context)
        {
            _context = context;
        }

        public async Task SaveDbAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RegenerateDbAsync()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            return await Task.FromResult(_context.Set<TEntity>().AsEnumerable());
        }

        public async Task AddAsync<TEntity>(TEntity value) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<TEntity>(TEntity value) where TEntity : class
        {
            await Task.FromResult(_context.Set<TEntity>().Remove(value));
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetEntityByIdAsync<TEntity>(Guid id)
            where TEntity : BaseEntity
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
