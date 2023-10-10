using HotelBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}
