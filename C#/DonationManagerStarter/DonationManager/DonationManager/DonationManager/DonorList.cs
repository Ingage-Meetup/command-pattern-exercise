using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DonationManager
{
    public class DonorList
    {
        private List<Donor> _donorList { get; set; }

        public DonorList()
        {
            _donorList = new List<Donor>();
        }

        public void Add(string name)
        {
            var id = _donorList.OrderByDescending(x => x.Id)?.FirstOrDefault()?.Id  ?? 0;
            _donorList.Add(new Donor(){ Id = ++id,  Name = name});
        }

        public Donor GetDonor(string name)
        {
            var donor = _donorList.Find(x => x.Name == name);
            return donor;
        }
    }
}
