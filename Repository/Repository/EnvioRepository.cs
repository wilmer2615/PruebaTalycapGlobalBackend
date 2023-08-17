using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class EnvioRepository : IEnvioRepository
    {
        private readonly AplicationDbContext _context;

        public EnvioRepository(AplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Envio> AddAsync(Envio envio)
        {
            try
            {
                envio.FechaRegistro = DateTime.Now;
                await this._context.Set<Envio>().AddAsync(envio);
                await this._context.SaveChangesAsync();

                return envio;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        public async Task<Envio> FindAsync(int id)
        {
            return await this._context.Set<Envio>()
                .Include(p => p.Producto)
                .Include(c => c.Cliente)
                .Include(em => em.EnvioMaritimo)
                .Include(et => et.EnvioTerrestre)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Envio>> GetAllAsync()
        {
            return await this._context.Set<Envio>()
                .Include(p => p.Producto)
                .Include(c => c.Cliente)
                .Include(em => em.EnvioMaritimo)
                .Include(et => et.EnvioTerrestre)
                .ToListAsync();
        }

        public async Task<Envio> RemoveAsync(int id)
        {
            var entity = await _context.Set<Envio>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<Envio>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public async Task<Envio> UpdateAsync(int id, Envio envio)
        {
            try

            {
                var entity = _context.Set<Envio>().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.PrecioEnvio = envio.PrecioEnvio;
                    entity.CantidadProducto = envio.CantidadProducto;
                    entity.FechaEntrega = envio.FechaEntrega;
                    entity.FechaRegistro = envio.FechaRegistro;
                    entity.IdCliente = envio.IdCliente;
                    entity.NumeroGuia = envio.NumeroGuia;
                    entity.IdProducto = envio.IdProducto;

                    _context.Set<Envio>().Update(entity);
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
