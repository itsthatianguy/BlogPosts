using System;
using System.Threading.Tasks;

namespace RazorViewEngineEmailTemplates.Templating
{
    public interface IViewToStringRenderer
    {
        Task<string> RenderViewToString<TModel>(string name, TModel model);
    }
}