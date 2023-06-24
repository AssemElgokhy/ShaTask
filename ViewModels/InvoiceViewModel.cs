namespace ShaTask.ViewModels
{
    public class InvoiceViewModel
    {
        //invoiceHeader Data
        public string CustomerName { get; set; }
        public double? InvoiceTotal { get; set; }//secured
        //invoiceDetails Data
        public long InvoiceHeaderId { get; set; }
        public /*int*/ long ItemId { get; set; } //secured
        public double ItemCount { get; set; }  //secured
        public double ItemPrice { get; set; }  //secured
    }
}
