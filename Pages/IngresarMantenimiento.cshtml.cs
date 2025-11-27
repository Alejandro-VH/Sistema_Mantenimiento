using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class IngresarMantenimientoModel : PageModel
    {
        private readonly MantencionDbContext _context;
        public List<Camioneta> camionetas { get; set; }

        public IngresarMantenimientoModel(MantencionDbContext context)
        {
            _context = context;
            camionetas = new List<Camioneta>();
        }
        
        public void OnGet()
        {
            camionetas = _context.Camionetas.ToList().FindAll(c => c.Estado == "Disponible");
        }

        public void OnPost(int id, string accion)
        {
            Camioneta? c = _context.Camionetas.FirstOrDefault(x => x.Id == id);

            if (c != null)
            {
                c.Estado = "En mantenimiento";
                HistorialMantencion historial = new HistorialMantencion
                {
                    Patente = c.Patente,
                    Accion = accion,
                    Fecha = DateTime.Now
                };
                _context.Historial.Add(historial);
                _context.SaveChanges();
            }
        }
    }
}
