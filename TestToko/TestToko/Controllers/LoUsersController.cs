using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestToko.Models;

namespace TestToko.Controllers
{
    public class LoUsersController : Controller
    {
        private readonly LoUserContext _context;
        public string OperatorName;
        public LoUsersController(LoUserContext context)
        {
            _context = context;
        }

        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("IdUser,Nama,Password")] LoUser products)
        {
            if (ModelState.IsValid)
            {
                var testing = products.Nama;
                var testingpass = products.Password;
                var Cek = await _context.LoUser
                .FirstOrDefaultAsync(m => m.Nama == testing && m.Password == testingpass);
                if (Cek == null)
                {
                    return NotFound();
                }
                else
                {
                    TempData["OperatorName"] = products.Nama;
                    return RedirectToAction("Index", "Barangs");
                }
                
            }
            return View(products);
        }

        //public async Task<IActionResult> Login(string? id, string? pass)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var products = await _context.User
        //        .FirstOrDefaultAsync(m => m.Nama == id && m.Password == pass);
        //    if (products == null)
        //    {
        //        return NotFound();
        //    }

        //    return View("../Barangs/Index");
        //}

        private bool UserExists(String id)
        {
            return _context.LoUser.Any(e => e.Nama == id);
        }
    }
}