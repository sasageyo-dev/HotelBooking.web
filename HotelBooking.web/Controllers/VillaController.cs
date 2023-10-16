using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace HotelBooking.Web.Controllers
{

    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VillaController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var villa = _db.Villas.ToList();
            return View(villa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description && obj.Name != null)
            {
                ModelState.AddModelError("", "Name and description value can not be same.");
            }
            if (ModelState.IsValid)
            {
                _db.Villas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int villaId)
        {
            Villa? obj = _db.Villas.FirstOrDefault(x => x.Id == villaId);
            if (obj is not null)
            {
                return View(obj);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Update(Villa request)
        {
            if (ModelState.IsValid && request.Id > 0)
            {
                _db.Villas.Update(request);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int villaId)
        {
            Villa? obj = _db.Villas.FirstOrDefault(x => x.Id == villaId);
            if (obj is not null)
            {
                return View(obj);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(Villa request)
        {
            Villa? response = _db.Villas.FirstOrDefault(x =>x.Id == request.Id);
            if (response is not null)
            {
                _db.Villas.Remove(response);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
