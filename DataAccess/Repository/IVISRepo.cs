using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IVISRepo
    {
        public AdminUser ValidateUser(string emailId, string password);
        public bool AddCity(City city);
        public bool AddVoter(Voter voter);
        public bool UpdateVoter(Voter voterInfo);
        public bool DeleteVoter(int id);
        public List<Voter> GetVoterList();
        public Voter FindByPK(int  id);
        public List<City> GetCities();
        public List<Voter> FindVoterByName(string name);
    }
}
