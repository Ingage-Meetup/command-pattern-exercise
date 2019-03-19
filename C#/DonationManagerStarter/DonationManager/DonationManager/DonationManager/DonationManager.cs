using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationManager
{
    public class DonationManager
    {
        private DonorList _donorList { get; set; }
        private DonationList _donationList { get; set; }

        public DonationManager()
        {
            _donorList = new DonorList();
            _donationList = new DonationList();
        }

        public void AddDonor(string donorName)
        {
            _donorList.Add(donorName);
        }

        public bool AddDonation(string donorName, decimal amount)
        {
            var donor = _donorList.GetDonor(donorName);
            if (donor == null)
                return false;
            _donationList.Add(donor.Id, amount, DateTime.Now);
            return true;
        }
    }
}
