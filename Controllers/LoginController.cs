using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HayvanBarınagi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace HayvanBarınagi.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IMemoryCache memoryCache;
        public LoginController(ApplicationDbContext context,IMemoryCache memoryCache)
        {
            _context = context;
            this.memoryCache = memoryCache;
        }
         
         [HttpGet]
         public IActionResult GirisYap()
         {
             return View();
         }
         
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("GirisYap", "Login");
        }
        public async Task<IActionResult> GirisYap(Admin p)
        { 

            var bilgi = _context.Admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);
            if (bilgi != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Kullanici)

                };
                var userIdentity = new ClaimsIdentity(claims, "Login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                

                await HttpContext.SignInAsync(principal);
                if(bilgi.userType == "a")
                {
                    memoryCache.Set("isAdmin", true);
                    return RedirectToAction("Index", "Admins");
                }
                else
                { 
                    if (bilgi.isActive)
                    {
                        memoryCache.Set("isAdmin", false);
                        return RedirectToAction("Index", "Animals");
                    }
                    else
                    {
                        memoryCache.Set("isAdmin", false);
                        return RedirectToAction("GirisYap", "Login");
                    }
                    
                }
                
            }
            return View();
        }
    }
}
