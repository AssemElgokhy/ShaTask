﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ShaTask.Models
{
    public partial class Cashier
    {
        public Cashier()
        {
            InvoiceHeaders = new HashSet<InvoiceHeader>();
        }

        public int Id { get; set; }
        public string CashierName { get; set; }
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; }
    }
}