using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroDto;

namespace MicroApi.Controllers
{
    [Route("apitest/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public SampleDto Get()
        {
            var result = new SampleDto {
                Test = "Hello!"
            };
            return result;
        }
    }
}
