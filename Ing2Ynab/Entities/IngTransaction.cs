using System;

namespace Ing2Ynab.Entities
{
    internal class IngTransaction
    {
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Import { get; set; }
        public string Category { get; set; }
    }
}
