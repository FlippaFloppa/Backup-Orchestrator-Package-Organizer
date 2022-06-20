using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Bopo.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string? RequestId { get; set; }
        public string? Param { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(Param);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string type)
        {   Console.WriteLine("Ricevuto parametro di errore: " + type);
            Param=type;
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            
        }
    }
}