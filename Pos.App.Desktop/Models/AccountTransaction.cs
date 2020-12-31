using System;

namespace Pos.App.Desktop.Models
{
    public class AccountTransaction
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string  AccountId { get; set; }
        public string  InvoiceId { get; set; }
        public string  Amount { get; set; }
    }
}
