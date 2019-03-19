using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationManager
{
    public class Donation
    {
        public int DonorId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
