using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AplicationDbContext _context;

        public ProductoRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Producto> AddAsync(Producto producto)
        {
            try
            {
                await this._context.Set<Producto>().AddAsync(producto);
                await this._context.SaveChangesAsync();

                return producto;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        public async Task<Producto> FindAsync(int id)
        {
            return await this._context.Set<Producto>()
               .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await this._context.Set<Producto>()
                .ToListAsync();
        }

        public async Task<Producto> RemoveAsync(int id)
        {
            var entity = await _context.Set<Producto>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<Producto>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public async Task<Producto> UpdateAsync(int id, Producto producto)
        {
            try
            {
                var entity = _context.Set<Producto>().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.TipoProducto = producto.TipoProducto;
                    entity.DescripcionProducto = producto.DescripcionProducto;

                    _context.Set<Producto>().Update(entity);
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
