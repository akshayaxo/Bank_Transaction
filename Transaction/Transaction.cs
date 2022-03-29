using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    public class Transaction
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        public string Direction { get; set; }
        public string Account { get; set; }
    }
}
