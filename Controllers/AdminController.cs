using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VISApp.Models;
using Voter = DataAccess.Model.Voter;

namespace VISApp.Controllers
{
    public class AdminController : Controller
    {
        IVISRepo _repo;
        
        public AdminController(IVISRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(String emailid, string password)
        {
            DataAccess.Model.AdminUser admin = _repo.ValidateUser(emailid, password);
            if (admin != null)
            {
                HttpContext.Session.SetString("emailid", emailid);
                HttpContext.Session.SetString("password", password);
                return RedirectToAction("Index", "Voters");
            }
            else
            {
                ViewBag.error = "Invalid user name or password";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]
        public IActionResult AddNewCity()
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCity(Models.City city)
        {
            DataAccess.Model.City temp = new DataAccess.Model.City();
            temp.Name = city.Name;
            bool result = _repo.AddCity(temp);
            if (!result)
            {
                return View("Error");
            }
            else
            {
                ViewBag.Message = "City Added";
                
            }
            ModelState.Clear();

            return View();

        }
        [HttpGet]
        public IActionResult SearchByName()
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        [HttpPost]
        public IActionResult SearchByName(string name)
        {
            if (HttpContext.Session.GetString("emailid") == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            List<Voter> voters = _repo.FindVoterByName(name); 
            List<Models.Voter> temp2 = new List<Models.Voter>();
            foreach (Voter v in voters)
            {
                Models.Voter temp = new Models.Voter();
                temp.VoterId = v.VoterId;
                temp.VoterName = v.VoterName;
                temp.Gender = v.Gender;
                temp.age = v.age;
                temp.City = v.City;
                temp.MobileNumber = v.MobileNumber;
                temp.Dob = v.Dob;
                temp.EmailId = v.EmailId;
                temp2.Add(temp);
            }
            return View(temp2);
        }

    }
}
