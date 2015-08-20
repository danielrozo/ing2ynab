using System;

namespace Ing2Ynab.Entities
{
    internal class YnabTransaction
    {
        public string Account { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Payee { get; set; }
        public decimal Outflow { get; set; }
        public decimal Inflow { get; set; }
        public string Category { get; set; }
        public string Memo { get; set; }
        public bool Cleared { get; set; }
    }
}
