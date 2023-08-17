using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class EnvioTerrestreRepository : IEnvioTerrestreRepository
    {
        private readonly AplicationDbContext _context;

        public EnvioTerrestreRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<EnvioTerrestre> AddAsync(EnvioTerrestre envioTerrestre)
        {
            try
            {
                await this._context.Set<EnvioTerrestre>().AddAsync(envioTerrestre);
                await this._context.SaveChangesAsync();

                return envioTerrestre;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        public async Task<EnvioTerrestre> FindAsync(int id)
        {
            return await this._context.Set<EnvioTerrestre>()
                .Include(e => e.Envio)
                .Include(b => b.Bodega)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<EnvioTerrestre>> GetAllAsync()
        {
            return await this._context.Set<EnvioTerrestre>()
                .Include(e => e.Envio)
                .Include(b => b.Bodega)
                .ToListAsync();
        }

        public async Task<EnvioTerrestre> RemoveAsync(int id)
        {
            var entity = await _context.Set<EnvioTerrestre>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<EnvioTerrestre>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public async Task<EnvioTerrestre> UpdateAsync(int id, EnvioTerrestre envioTerrestre)
        {
            try

            {
                var entity = _context.Set<EnvioTerrestre>().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.IdEnvio = envioTerrestre.IdEnvio;
                    entity.IdBodega = envioTerrestre.IdBodega;
                    entity.PlacaVehiculo = envioTerrestre.PlacaVehiculo;

                    _context.Set<EnvioTerrestre>().Update(entity);
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
