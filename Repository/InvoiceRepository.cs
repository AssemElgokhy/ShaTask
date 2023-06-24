using Microsoft.EntityFrameworkCore;
using ShaTask.Data;
using ShaTask.Interfaces;
using ShaTask.Models;

namespace ShaTask.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ShaTaskContext _context;

        public InvoiceRepository(ShaTaskContext context)
        {
            _context = context;

        }

        public bool Add(Item item)
        {
            _context.Add(item);
            return Save();
        }

        public bool Delete(Item item)
        {
            _context.Remove(item);
            return Save();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _context.Items.ToListAsync();  
        }

        public async Task<Item> GetByIdAsync(long id)
        {
            return await _context.Items.AsNoTracking()/*Include(n => n.ItemName).*/.FirstOrDefaultAsync(i=> i.Id == id);

            
        }

        public bool Save()
        {
            var saved= _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Item item)
        {
            _context.Update(item);
            return Save();
        }
    }
}
