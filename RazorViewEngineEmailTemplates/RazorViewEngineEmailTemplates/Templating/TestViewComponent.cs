using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RazorViewEngineEmailTemplates.Templating
{
    public class TestViewComponent : ViewComponent
    {
        public TestViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(int sample)
        {
            return View(sample);
        }
    }
}