using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RazorEngine;
using RazorEngine.Templating;
using RazorEngine.Configuration;
using System.IO;
using RazorEngine.Text; 

namespace Templating
{
    class TemplateProgram
    {
        static void Main(string[] args)
        {
            string template; // = "Hello @Model.Name, welcome to RazorEngine!";
            string templateFile = "templates/simple.cshtml";
            template = File.ReadAllText(templateFile);
            var config = new TemplateServiceConfiguration();
            config.Debug = true;
            config.EncodedStringFactory = new HtmlEncodedStringFactory();
            config.CachingProvider = new DefaultCachingProvider(t => { });  //disables the temp file cleanup warning
            var service = RazorEngineService.Create(config);

            
            var result = service.RunCompile(new LoadedTemplateSource(template, templateFile), "templateKey", null, new { Name = "World" });
            Console.ReadLine();
        }
    }
}
