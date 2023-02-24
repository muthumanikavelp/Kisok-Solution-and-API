using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nafmodel;

namespace kisok_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfflineController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString; 

        public OfflineController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpGet("vadivutest")]

        public string test()
        {

            return "test";
        }
    }
}