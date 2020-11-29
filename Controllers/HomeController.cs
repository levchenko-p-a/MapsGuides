using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MapsGuides.Models;
using MapsGuides.Data;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MapsGuides.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly UserManager<User> _userManager;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, 
            IWebHostEnvironment appEnvironment, UserManager<User> userManager)
        {
            _logger = logger;
            _context = context;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Dot> dots = _context.Dots.ToList();
            return View(dots);
        }
        public async Task<IActionResult> DeleteDot(int id)
        {
            Dot dot = _context.Dots.FirstOrDefault(d => d.id == id);
            _context.Entry(dot).State = EntityState.Detached;
            _context.Dots.Remove(dot);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult EditDot(string id)
        {
            int dotId = JsonConvert.DeserializeObject<int>(HttpUtility.UrlDecode(id));
            Dot dot = _context.Dots.FirstOrDefault(d => d.id == dotId);
            return View(dot);
        }
        public async Task<IActionResult> SetDot(string data)
        {
            LatLng coords = JsonConvert.DeserializeObject<LatLng>(HttpUtility.UrlDecode(data).ToString());
            var user = await _userManager.GetUserAsync(User);
            DotModel dm = new DotModel();
            if (user != null)
            {
                dm.user = user.UserName;
                dm.phone = user.PhoneNumber;
                dm.email = user.Email;
            }
            dm.latitude = coords.latitude;
            dm.longitude = coords.longitude;
            ViewBag.Categoryes = new SelectList(_context.Categories, "id", "name");
            return View(dm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetDot(DotModel dm, IFormFile thumbFile)
        {
            if (ModelState.IsValid)
            {
                Dot dot = null;
                try
                {
                    if (thumbFile != null && thumbFile.ContentType.Contains("image"))
                    {
                        var uploadedFileExtension = Path.GetExtension(thumbFile.FileName);
                        var fileName = Path.GetRandomFileName()+uploadedFileExtension;
                        var mappedPath = Path.Combine(_appEnvironment.WebRootPath, "Files", DateTime.Now.ToShortDateString());
                        Directory.CreateDirectory(mappedPath);
                        var filePath = Path.Combine(mappedPath, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await thumbFile.CopyToAsync(fileStream);
                        }
                        Dot oldDot = _context.Dots.FirstOrDefault(d => d.id == dm.dot_id);
                        if (oldDot != null)
                        {
                            var oldThumb = Path.Combine(_appEnvironment.WebRootPath, oldDot.thumb_file);
                            System.IO.File.Delete(oldThumb);
                            _context.Entry(oldDot).State = EntityState.Detached;
                        }
                        dot=dm.createDot(oldDot);
                        dot.thumb_name = Path.GetFileName(thumbFile.FileName);
                        //var baseUri = this.Request.Host.Host.ToString();
                        string webPath = Path.GetRelativePath(_appEnvironment.WebRootPath, filePath).Replace(@"\", "/");
                        dot.thumb_file = Url.Content(webPath); ;
                        ViewBag.FileStatus = "File uploaded successfully.";
                    }
                    else
                    {
                        ViewBag.FileStatus = "File is not image";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.FileStatus = ex.StackTrace;
                    return View(dot);
                }
                if (dot != null)
                {
                    _context.Dots.Add(dot);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(dm);
            }
        }
        //возвращаем все точки на карте
        public JsonResult GetData(string text)
        {
            List<Dot> dots = new List<Dot>();
            
            if(text != null)
            {
                dots = _context.Dots.Where(d => d.title == text).ToList();
            }
            dots = _context.Dots.ToList();
            return Json(dots);
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
    }
}
