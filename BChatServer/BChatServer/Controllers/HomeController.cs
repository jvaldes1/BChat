using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BChat.Data.Model;
using BChat.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using BChatServer.Models;
using Microsoft.AspNetCore.Authorization;

namespace BChatServer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Message> messages = Repository.GetMessages();
            return View(messages);
        }

        [HttpPost]
        public IActionResult AddMessage(Message message)
        {
            message.Timestamp = DateTime.Now;

            var result = Repository.AddMessage(message);

            if (result.Status)
            {
                return Json("Ok");
            }
            else
            {
                return Json("Failed");
            }
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            List<Message> messages = Repository.GetMessages();

            return Json(messages);
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
