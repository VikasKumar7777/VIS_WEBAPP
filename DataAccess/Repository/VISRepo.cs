using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class VISRepo : IVISRepo
    {
        private VISDbContext _dbContext;
        public VISRepo()
        {
            _dbContext = new VISDbContext();
        }

        public bool AddCity(City city)
        {
            if (city == null) return false;
            try
            {
                _dbContext.Cities.Add(city);
                _dbContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<City> GetCities()
        {
            return _dbContext.Cities.ToList();
        }

        public bool AddVoter(Voter voter)
        {
            if(voter == null) return false; 
            try
            {
                _dbContext.Voters.Add(voter);
                _dbContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteVoter(int id)
        {
            Voter voter = null;
            try
            {
                voter = _dbContext.Voters.Find(id);
                _dbContext.Voters.Remove(voter);
                _dbContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Voter FindByPK(int id)
        {

            Voter voters = null;
            try
            {
                voters = _dbContext.Voters.Find(id);
                
            }
            catch
            {
                return null;
            }
            return voters;

        }

        public List<Voter> FindVoterByName(string name)
        {
            List<Voter> voters = _dbContext.Voters.Where(v => v.VoterName == name).ToList();
            return voters;
        }

        public List<Voter> GetVoterList()
        {
            return _dbContext.Voters.ToList();

        }

        public bool UpdateVoter(Voter voterInfo)
        {
            if(voterInfo == null) { return false; }
            Voter voters = null;
            try
            {
                voters = _dbContext.Voters.Find(voterInfo.VoterId);
                voters.VoterName = voterInfo.VoterName;
                voters.age = voterInfo.age;
                voters.Dob = voterInfo.Dob;
                voters.Gender = voterInfo.Gender;
                voters.City = voterInfo.City;
                voters.EmailId = voterInfo.EmailId;
                voters.MobileNumber = voterInfo.MobileNumber;
                _dbContext.SaveChanges();
            }
            catch { return false; }
            return true;
        }

        public AdminUser ValidateUser(string emailId, string password)
        {
            AdminUser adminuser = null;
            try
            {
                adminuser = _dbContext.AdminUsers.Where(u => u.EmailId == emailId && u.Password == password).FirstOrDefault();
            }
            catch
            {
                adminuser = null;
            }
            return adminuser;
        }
    }
}
