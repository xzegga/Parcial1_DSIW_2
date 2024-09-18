using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityLayer
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // Credit Card, Cash, etc.

        // Relación con el alquiler
        public int RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}
