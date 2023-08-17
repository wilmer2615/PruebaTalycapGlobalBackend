using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class EnvioMaritimoRepository : IEnvioMaritimoRepository
    {
        private readonly AplicationDbContext _context;

        public EnvioMaritimoRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<EnvioMaritimo> AddAsync(EnvioMaritimo envioMaritimo)
        {
            try
            {
                await this._context.Set<EnvioMaritimo>().AddAsync(envioMaritimo);
                await this._context.SaveChangesAsync();

                return envioMaritimo;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        public async Task<EnvioMaritimo> FindAsync(int id)
        {
            return await this._context.Set<EnvioMaritimo>()
                .Include(e => e.Envio)
                .Include(p => p.Puerto)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<EnvioMaritimo>> GetAllAsync()
        {
            return await this._context.Set<EnvioMaritimo>()
                .Include(e => e.Envio)
                .Include(p => p.Puerto)
                .ToListAsync();
        }

        public async Task<EnvioMaritimo> RemoveAsync(int id)
        {
            var entity = await _context.Set<EnvioMaritimo>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<EnvioMaritimo>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public async Task<EnvioMaritimo> UpdateAsync(int id, EnvioMaritimo envioMaritimo)
        {
            try

            {
                var entity = _context.Set<EnvioMaritimo>().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.IdEnvio = envioMaritimo.IdEnvio;
                    entity.IdPuerto = envioMaritimo.IdPuerto;
                    entity.NumeroFlota = envioMaritimo.NumeroFlota;

                    _context.Set<EnvioMaritimo>().Update(entity);
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
