using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Kiosk_web.Controllers
{
    public class launchController : Controller
    {
        // GET: launch

        string urlstring = "";
        private IConfiguration _configuration;
        private IHostingEnvironment _hostingEnvironment;
        public launchController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult launchView()
        {
          
                urlstring = _configuration.GetSection("AppSettings")["Instance"].ToString();

            ViewBag.Instance = urlstring.ToString();
            return View();
        }
        public ActionResult launchViewTa()
        {
            return View();
        }

        
    }
}