using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VISApp.Models;
using City = DataAccess.Model.City;
using Voter = VISApp.Models.Voter;

namespace VISApp.Controllers
{
    public class VotersController : Controller
    {
        private IVISRepo repo;
        public VotersController(IVISRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            List<DataAccess.Model.Voter> daVoter = repo.GetVoterList().ToList();
            List<Voter> voters = new List<Voter>();
            foreach(var voter in daVoter)
            {
                Voter temp = new Voter();
                temp.VoterId = voter.VoterId;
                temp.VoterName = voter.VoterName;
                temp.MobileNumber = voter.MobileNumber;
                temp.age = voter.age;
                temp.Gender = voter.Gender;
                temp.City = voter.City;
                temp.Dob = voter.Dob;
                temp.EmailId = voter.EmailId;
                voters.Add(temp);
            }
            return View(voters);
        }


        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            List<City> cityList = repo.GetCities().ToList();
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (City city in cityList)
            {
                SelectListItem selectedItem = new SelectListItem();
                selectedItem.Text = city.Name;
                selectList.Add(selectedItem);
            }
            ViewBag.Cities = selectList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Voter voters)
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (ModelState.IsValid)
            {
                DataAccess.Model.Voter temp= new DataAccess.Model.Voter();
               // temp.VoterId = voters.VoterId;
                temp.VoterName = voters.VoterName;
                temp.Gender = voters.Gender;
                temp.age = voters.age;
                temp.City = voters.City;
                temp.MobileNumber = voters.MobileNumber;
                temp.Dob = voters.Dob;
                temp.EmailId = voters.EmailId;
                bool result = repo.AddVoter(temp);
                if (!result)
                {
                    Console.WriteLine("not added");
                    View("Error");
                }
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            List<City> cityList = repo.GetCities().ToList();
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (City city in cityList)
            {
                SelectListItem selectedItem = new SelectListItem();
                selectedItem.Text = city.Name; 
                selectList.Add(selectedItem);
            }
            ViewBag.CityList = selectList;

            DataAccess.Model.Voter v = repo.FindByPK(id);
            
            Models.Voter temp = new Voter();
            if(v != null)
            {
                
                temp.VoterId = v.VoterId;
                temp.VoterName = v.VoterName;
                temp.Gender = v.Gender;
                temp.age = v.age;
                temp.City = v.City;
                temp.MobileNumber = v.MobileNumber;
                temp.Dob = v.Dob;
                temp.EmailId = v.EmailId;
            }
            else
            {
                return View("Error");
            }

                return View(temp);
        }
        [HttpPost]
        public IActionResult Edit(Voter v)
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            DataAccess.Model.Voter temp = new DataAccess.Model.Voter();

            temp.VoterId = v.VoterId;
            temp.VoterName = v.VoterName;
            temp.Gender = v.Gender;
            temp.age = v.age;
            temp.City = v.City;
            temp.MobileNumber = v.MobileNumber;
            temp.Dob = v.Dob;
            temp.EmailId = v.EmailId;
            bool result = repo.UpdateVoter(temp);
            if(!result)
            {
                View("Error");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            DataAccess.Model.Voter v = repo.FindByPK(id);
            Models.Voter temp = new Voter();
            if (v != null)
            {
                temp.VoterId = v.VoterId;
                temp.VoterName = v.VoterName;
                temp.Gender = v.Gender;
                temp.age = v.age;
                temp.City = v.City;
                temp.MobileNumber = v.MobileNumber;
                temp.Dob = v.Dob;
                temp.EmailId = v.EmailId;
            }
            else
            {
                return View("Error");
            }

            return View(temp);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            DataAccess.Model.Voter v = repo.FindByPK(id);
            Models.Voter temp = new Voter();
            if (v != null)
            {
                temp.VoterId = v.VoterId;
                temp.VoterName = v.VoterName;
                temp.Gender = v.Gender;
                temp.age = v.age;
                temp.City = v.City;
                temp.MobileNumber = v.MobileNumber;
                temp.Dob = v.Dob;
                temp.EmailId = v.EmailId;
            }
            else
            {
                return View("Error");
            }

            return View(temp);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            bool result = repo.DeleteVoter(id);
            if (!result)
            {
                View("Error");
            }
            return RedirectToAction("Index");

        }
    }
}
