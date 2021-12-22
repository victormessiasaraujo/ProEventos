using System.Threading.Tasks;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Contracts;

namespace ProEventos.Persistence.Models
{
    public class GeralModel : IGeralPersist
    {
        public ProEventosContext _context { get; }
        public GeralModel(ProEventosContext context)
        {
            this._context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Upadte<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}