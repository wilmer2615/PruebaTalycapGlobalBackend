using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly AplicationDbContext _context;

        public ClienteRepository(AplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            try
            {
                await this._context.Set<Cliente>().AddAsync(cliente);
                await this._context.SaveChangesAsync();

                return cliente;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        public async Task<Cliente> FindAsync(int id)
        {
            return await this._context.Set<Cliente>()
               .FirstOrDefaultAsync(a => a.Id == id);

        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await this._context.Set<Cliente>()
                .ToListAsync();
        }

        public async Task<Cliente> RemoveAsync(int id)
        {
            var entity = await _context.Set<Cliente>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<Cliente>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public async Task<Cliente> UpdateAsync(int id, Cliente cliente)
        {
            try
            {
                var entity = _context.Set<Cliente>().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.Nombre = cliente.Nombre;
                    entity.Direccion = cliente.Direccion;
                    entity.NumeroIdentificacion = cliente.NumeroIdentificacion;
                    entity.Email = cliente.Email;

                    _context.Set<Cliente>().Update(entity);
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
