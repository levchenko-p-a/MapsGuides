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

namespace MapsGuides.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, 
            IWebHostEnvironment appEnvironment, UserManager<IdentityUser> userManager)
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
            Dot dot = _context.Dots.FirstOrDefault(d => d.Id == id);
            _context.Entry(dot).State = EntityState.Detached;
            _context.Dots.Remove(dot);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult EditDot(string id)
        {
            int dotId = JsonConvert.DeserializeObject<int>(HttpUtility.UrlDecode(id));
            Dot dot = _context.Dots.FirstOrDefault(d => d.Id == dotId);
            return View(dot);
        }
        [HttpPost]
        public async Task<IActionResult> EditDot(Dot dot, IFormFile thumbFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (thumbFile != null && thumbFile.ContentType.Contains("image"))
                    {
                        var uploadedFileExtension = Path.GetExtension(thumbFile.FileName);
                        var fileName = Path.GetRandomFileName() + uploadedFileExtension;
                        var mappedPath = Path.Combine(_appEnvironment.WebRootPath, "Files", DateTime.Now.ToShortDateString());
                        Directory.CreateDirectory(mappedPath);
                        var filePath = Path.Combine(mappedPath, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await thumbFile.CopyToAsync(fileStream);
                        }
                        Dot oldDot = _context.Dots.FirstOrDefault(d => d.Id == dot.Id);
                        var oldThumb = Path.Combine(_appEnvironment.WebRootPath, oldDot.ThumbFile);
                        System.IO.File.Delete(oldThumb);
                        dot.ThumbName = Path.GetFileName(thumbFile.FileName);
                        string webPath = Path.GetRelativePath(_appEnvironment.WebRootPath, filePath).Replace(@"\", "/");
                        dot.ThumbFile = Url.Content(webPath);
                        _context.Entry(oldDot).State = EntityState.Detached;
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
                _context.Dots.Update(dot);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(dot);
            }
        }
        public async Task<IActionResult> SetDot(string data)
        {
            LatLng coords = JsonConvert.DeserializeObject<LatLng>(HttpUtility.UrlDecode(data).ToString());
            var user = await _userManager.GetUserAsync(User);
            Dot dot = new Dot();
            if (user != null)
            {
                dot.User = user.UserName;
                dot.Phone = user.PhoneNumber;
                dot.Email = user.Email;
            }
            dot.Latitude = coords.latitude;
            dot.Longitude = coords.longitude;
            return View(dot);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetDot(Dot dot, IFormFile thumbFile)
        {
            if (ModelState.IsValid)
            {
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
                        dot.ThumbName = Path.GetFileName(thumbFile.FileName);
                        //var baseUri = this.Request.Host.Host.ToString();
                        string webPath = Path.GetRelativePath(_appEnvironment.WebRootPath, filePath).Replace(@"\", "/");
                        dot.ThumbFile = Url.Content(webPath); ;
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
                _context.Dots.Add(dot);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(dot);
            }
        }
        //возвращаем все точки на карте
        public JsonResult GetData()
        {
            List<Dot> dots = _context.Dots.ToList();
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
