using Microsoft.EntityFrameworkCore;
using ShaTask.Data;
using ShaTask.Interfaces;
using ShaTask.Models;

namespace ShaTask.Repository
{
    public class InvoiceHeaderRepository : IInvoiceHeaderRepository
    {
        private readonly ShaTaskContext _context;

        public InvoiceHeaderRepository(ShaTaskContext context)
        {
            _context = context;
        }
        public bool Add(InvoiceHeader invoiceHeader)
        {
            _context.Add(invoiceHeader);
            return Save();
        }

        public async Task<InvoiceHeader> GetLastIdAsync()
        {
            //return await _context.InvoiceHeaders.MaxAsync(e=> e.Id);

             
            //var invoiceHeader = await _context.InvoiceHeaders.FindAsync(maxId);
           /* return await _context.InvoiceHeaders.MaxAsync(e => (long)e.Id);*/  /*invoiceHeader*/



            var maxId = await _context.InvoiceHeaders.MaxAsync(e => (long)e.Id);
            return await _context.InvoiceHeaders.FindAsync(maxId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
