﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Transaction.Models
{
    public class trandetail
    {
        public string tnumber { get; set; }
        public string acnumber { get; set; }
        public DateTime? dot { get; set; }
        public string transaction_type { get; set; }
        public decimal? transaction_amount { get; set; }

        public virtual account acnumberNavigation { get; set; }
    }
}