using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shoppingstore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace shoppingstore.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var producer = _context.Producer.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (producer == null)
            {
                return RedirectToAction("Create");
            }
            return View(producer);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producer = _context.Producer
            .Include(c => c.IdentityUser)
            .FirstOrDefault(m => m.ProducerId == id);
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }
    }
}
