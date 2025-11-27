using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class ListaCamionetasModel : PageModel
    {
       private readonly MantencionDbContext _context;
        public List<Camioneta> camionetas { get; set; }

        public ListaCamionetasModel(MantencionDbContext context)
        {
            _context = context;
            camionetas = new List<Camioneta>();
        }
        
        public void OnGet()
        {
            camionetas = _context.Camionetas.ToList();
        }
    }
}
