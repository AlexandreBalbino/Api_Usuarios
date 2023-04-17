using Domain.Models;
using Infradata.IRepositorys;
using Microsoft.EntityFrameworkCore;

namespace Infradata.Repositorys
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Usuario> _table;

        public UsuariosRepository(ApplicationDbContext context)
        {
            _context = context;
            _table = context.Set<Usuario>();
        }

        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _table.ToListAsync();
        }
        
        public async Task<Usuario> GetById(int id)
        {
            var obj = await _table.FindAsync(id);
            if (obj == null) { throw new Exception("Not found entity"); }
            return obj;
        }

        public async Task<int> Insert(Usuario usuario)
        {
            await _table.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario.Id;
        }
        public async Task Update(Usuario usuario)
        {
            _table.Attach(usuario);
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var existing = await _table.FindAsync(id);
            if (existing == null) { throw new Exception("Not found entity"); }
            _table.Remove(existing);
            await _context.SaveChangesAsync();
        }
    }
}
