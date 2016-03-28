using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodePaLousa.ViewModels
{
    public class PaymentDetails
    {
        public string PublicKey { get; set; }
        public decimal Amount { get; set; }
        public string PaymentToken { get; set; }
        public string BillingZip { get; set; }
    }
}