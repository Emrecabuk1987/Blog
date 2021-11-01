using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo2.Controllers
{
    public class RegisterController : Controller
    {
        //ekleme işlemi yapılırken httpget ve httppost attribute'lerinin tanımlandığı
        //metodların isimileri aynı olmak zorundadır.
        //httpget sayfa yüklenince çalışmaya başlıyor.
        //httppost sayfada buton tetiklenince.
        //httpget attribute komutu sayfada kategorize veya benzeri işlemler kullanılırken
        //sayfa yüklendiği anda listelenmesi istenilen niteliklerde kullanılabilir.
        //iller - ilçeler httpget yazılabilir ,
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);
            if (results.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }
    }
}
