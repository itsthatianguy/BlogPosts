using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Linq;
using System.IO;

namespace RazorViewEngineEmailTemplates.Templating
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        private IEnumerable<string> _directoryLocations;

        public ViewLocationExpander(string contentRootPath)
        {
            var root = Directory.GetCurrentDirectory();
            // Find all 'Emails' folders in the directory
            _directoryLocations = Directory.GetDirectories(root, "Emails", SearchOption.AllDirectories);
            // Only include the ones in the running directory, remove the root path (the view engine uses relative paths)
            // and append the file name
            _directoryLocations = _directoryLocations.Where(s => s.Contains(contentRootPath))
                                                    .Select(s => s.Replace(root, ""))
                                                    .Select(s => s.Insert(s.Length, "/{0}.cshtml"));

        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return _directoryLocations.Union(viewLocations); 
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(ViewLocationExpander);
        }
    }
}