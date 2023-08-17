using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PuertoRepository : IPuertoRepository
    {
        private readonly AplicationDbContext _context;

        public PuertoRepository(AplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Puerto> AddAsync(Puerto puerto)
        {
            try
            {
                await this._context.Set<Puerto>().AddAsync(puerto);
                await this._context.SaveChangesAsync();

                return puerto;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        public async Task<Puerto> FindAsync(int id)
        {
            return await this._context.Set<Puerto>()
               .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Puerto>> GetAllAsync()
        {
            return await this._context.Set<Puerto>()
                .ToListAsync();
        }

        public async Task<Puerto> RemoveAsync(int id)
        {
            var entity = await _context.Set<Puerto>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<Puerto>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public async Task<Puerto> UpdateAsync(int id, Puerto puerto)
        {
            try
            {
                var entity = _context.Set<Puerto>().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.Nombre = puerto.Nombre;
                    entity.Ubicacion = puerto.Ubicacion;

                    _context.Set<Puerto>().Update(entity);
                    await _context.SaveChangesAsync();

                    return entity;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }
    }
}
