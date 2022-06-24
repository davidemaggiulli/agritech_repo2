using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Domain
{
    public class Transaction
    {
        public Guid Id { get; }
        public DateTime Date { get; }

        public decimal Amount { get; }

        public string Description { get; }
    }
}
