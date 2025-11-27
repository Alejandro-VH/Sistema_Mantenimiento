using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class RetiroCamionetasModel : PageModel
    {
        private readonly MantencionDbContext _context;
        public List<Camioneta> camionetas { get; set; }

        public RetiroCamionetasModel(MantencionDbContext context)
        {
            _context = context;
            camionetas = new List<Camioneta>();
        }
        
        public void OnGet()
        {
            camionetas = _context.Camionetas.ToList().FindAll(c => c.Estado == "En mantenimiento");
        }

        public void OnPost(int id, string patente, int kilometraje, string modelo, string marca, int año)
        {
            Camioneta? c = _context.Camionetas.FirstOrDefault(x => x.Id == id);

            if (c != null)
            {
                c.Estado = "Disponible";
                HistorialMantencion historial = new HistorialMantencion
                {
                    Patente = c.Patente,
                    Accion = "Retiro",
                    Fecha = DateTime.Now,
                    NuevoKilometraje = kilometraje
                };
                _context.SaveChanges();
            }
        }
    }
}
