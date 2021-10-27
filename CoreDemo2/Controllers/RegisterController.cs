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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index()
        {

        }
    }
}
