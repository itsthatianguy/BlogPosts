using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorViewEngineEmailTemplates.Templating;
using RazorViewEngineEmailTemplates.Templating.Models;

namespace RazorViewEngineEmailTemplates.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IViewToStringRenderer _viewToStringRenderer;

        public EmailController(IViewToStringRenderer viewToStringRenderer) 
        {
            _viewToStringRenderer = viewToStringRenderer;
        }

        // GET api/email
        [HttpGet]
        public string Get()
        {
            var emailModel = new HelloEmailModel {
                Name = "Ian Rufus"
            };
            try
            {
                var result = _viewToStringRenderer.RenderViewToString("HelloEmail", emailModel).Result;
                return result;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
