using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationManager
{
    public class DonationList
    {
        private List<Donation> _donationList { get; set; }

        public DonationList()
        {
            _donationList = new List<Donation>();
        }

        public void Add(int id, decimal amount, DateTime date)
        {
            _donationList.Add(new Donation() { DonorId = id, Date = date, Amount = amount});
        }
    }
}
