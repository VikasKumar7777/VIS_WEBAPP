using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Voter
    {
        public int VoterId { get; set; }
        public string VoterName { get; set; }
        public int age { get; set; }
        public DateTime Dob {  get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
    }
}
