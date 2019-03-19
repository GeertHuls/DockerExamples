using io =System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ApiConsumer.Models;

namespace ApiConsumer.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _stateFilePath;
        private static string _HostName = Environment.MachineName;

        public HomeController(IConfiguration config)
        {
           _stateFilePath = config.GetValue<string>("State:FilePath");
        }

        public IActionResult Index()
        {
            var model = new HomeModel
            {
                ServerName = _HostName
            };

            model.ApiResponse = GetCachedApiResponse();
            if (string.IsNullOrEmpty(model.ApiResponse))
            {
                model.ApiResponse = Guid.NewGuid().ToString().Substring(0,6);
                CacheApiResponse(model.ApiResponse);
            }
            else
            {
                model.ApiResponseCached = true;
            }

            return View(model);
        }

        private string GetCachedApiResponse()
        {
            var response = string.Empty;
            if (io.File.Exists(_stateFilePath))
            {
                response = io.File.ReadAllText(_stateFilePath);
            }
            return response;
        }

        private void CacheApiResponse(string response)
        {
            io.File.WriteAllText(_stateFilePath, response);
        }
    }
}
