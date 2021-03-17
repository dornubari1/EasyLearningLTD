using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLearningLTD.Controllers
{
    public class StudentServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
