using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public DBContext db;
        public string Configuration;

        public HomeController(ILogger<HomeController> logger, DBContext context, IConfiguration configuration)
        {
            _logger = logger;
            db = context;
            Configuration = configuration.GetConnectionString("DefaultConnection");
        }


      

    

        public IActionResult Index()
        {
            return View("CreateHr");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





        public IActionResult CreateHr()
        {
            return View();
        }

        [HttpPost]
        public IActionResult createHR(RoomDetails rd)
        {
            if (ModelState.IsValid)
            {

                if (db.roomDetails.Where(x => x.Name == rd.Name).Any())
                {
                    ModelState.AddModelError("Name", "Name already exists!");
                    return View();
                }

                rd.RegistrationId = "";
                rd.RegistrationId = "RG" + rd.RegistrationId.Count() + 1;
                int price = 0;
                if (rd.RoomType == "D" && rd.BedType == "S" && rd.RoomCategory == "A")
                {
                    price = 4500;
                }
                else if (rd.RoomType == "D" && rd.BedType == "D" && rd.RoomCategory == "A")
                {
                    price = 5500;
                }
                else if (rd.RoomType == "D" && rd.BedType == "T" && rd.RoomCategory == "A")
                {
                    price = 6500;
                }
                else
                {
                    price = 5000;
                }

                TimeSpan diff = rd.EndDate.Date - rd.StartDate.Date;
                int totalDays = diff.Days;

                rd.totdays = totalDays;
                rd.price = price * totalDays;

                HttpContext.Session.SetString("RoomDetails", JsonConvert.SerializeObject(rd));

                return RedirectToAction("ConFirmHr");
            }
            return View(rd);
        }

        [HttpGet]
        public IActionResult ConFirmHr()
        {
            var json = HttpContext.Session.GetString("RoomDetails");
            var roomDetails = JsonConvert.DeserializeObject<RoomDetails>(json);
            return View(roomDetails);

        }

        [HttpPost]
        public string ConFirmHr(RoomDetails rd)
        {

            db.roomDetails.Add(rd);
            db.SaveChanges();
            return "Room Booking Successfull";

        }

        [HttpPost]
        public string NotMatch(RoomDetails rd)
        {
            return "Name Already exist!";
        }


        public enum RoomType
        {
            Deluxe = 'D',
            Premium = 'P'
        }

        public enum BedType
        {
            Single = 'S',
            Double = 'D',
            Trible = 'T'
        }

        public enum RoomCategory
        {
            AC = 'A',
            NAC = 'N'
        }
    }
}
