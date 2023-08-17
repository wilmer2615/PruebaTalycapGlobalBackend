using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class BodegaRepository : IBodegaRepository
    {
        private readonly AplicationDbContext _context;

        public BodegaRepository(AplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Bodega> AddAsync(Bodega bodega)
        {
            try
            {
                await this._context.Set<Bodega>().AddAsync(bodega);
                await this._context.SaveChangesAsync();

                return bodega;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        public async Task<Bodega> FindAsync(int id)
        {
            return await this._context.Set<Bodega>()
               .FirstOrDefaultAsync(a => a.Id == id);

        }

        public async Task<IEnumerable<Bodega>> GetAllAsync()
        {
            return await this._context.Set<Bodega>()
                .ToListAsync();
        }

        public async Task<Bodega> RemoveAsync(int id)
        {
            var entity = await _context.Set<Bodega>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<Bodega>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public async Task<Bodega> UpdateAsync(int id, Bodega bodega)
        {
            try
            {
                var entity = _context.Set<Bodega>().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.Nombre = bodega.Nombre;
                    entity.Direccion = bodega.Direccion;

                    _context.Set<Bodega>().Update(entity);
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
