﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ShaTask.Models
{
    public partial class Item
    {
        //public Item()
        //{
        //    InvoiceDetails = new HashSet<InvoiceDetail>();
        //}

        public /*int*/ long Id { get; set; }
        public double ItemPrice { get; set; }
        public string ItemName { get; set; }
        //public decimal Total
        //{
        //    get
        //    {
        //        return ItemPrice * Count ;
        //    }
        //}

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}