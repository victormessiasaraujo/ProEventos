using System.Threading.Tasks;

namespace ProEventos.Persistence.Contracts
{
    public interface IGeral
    {
        void Add<T>(T entity) where T: class;
        void Upadte<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();
    }
}