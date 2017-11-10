using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MicroWeb.Client;
using MicroDto;
using MicroWeb.ViewModels;

namespace MicroWeb.Controllers
{
    [Route("webtest/home")]
    public class HomeController : Controller
    {
        private readonly IApiClient _apiClient;

        public HomeController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var test = "apitest/values";

            var result = await _apiClient.Get<SampleDto>(test);
            var viewModel = new SampleViewModel {
                Result = result.Test
            };
            return View(viewModel);
        }
    }
}