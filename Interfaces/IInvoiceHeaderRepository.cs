using ShaTask.Models;

namespace ShaTask.Interfaces
{
    public interface IInvoiceHeaderRepository
    {
        Task<InvoiceHeader> GetLastIdAsync();
        bool Add(InvoiceHeader invoiceHeader);
        bool Save();
    }
}
