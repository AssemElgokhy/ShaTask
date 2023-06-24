using ShaTask.Models;

namespace ShaTask.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Item>> GetAll();
        Task<Item> GetByIdAsync(long id);
        bool Add (Item item);
        bool Update (Item item);
        bool Delete (Item item);
        bool Save();
    }
}
