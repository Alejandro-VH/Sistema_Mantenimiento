using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class VerHistorialModel : PageModel
    {
       private readonly MantencionDbContext _context;
        public List<HistorialMantencion> historial { get; set; }

        public VerHistorialModel(MantencionDbContext context)
        {
            _context = context;
            historial = new List<HistorialMantencion>();
        }
        
        public void OnGet()
        {
            historial = _context.Historial.ToList();
        }
    }
}
