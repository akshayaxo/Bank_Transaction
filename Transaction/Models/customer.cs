﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Transaction.Models
{
    public partial class customer
    {
        public customer()
        {
            accounts = new HashSet<account>();
        }

        public string custid { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string ltname { get; set; }
        public string city { get; set; }
        public string mobileno { get; set; }
        public string occupation { get; set; }
        public DateTime? dob { get; set; }

        public virtual ICollection<account> accounts { get; set; }
    }
}