using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    public class DeepSeaWorldController : Controller
    {
        public IActionResult Index()
        {
            DeepSeaWorldContext context = HttpContext.RequestServices.GetService(typeof(ToDoAPI.Models.DeepSeaWorldContext)) as DeepSeaWorldContext;

            return View(context.GetFAQs());
        }
    }
}