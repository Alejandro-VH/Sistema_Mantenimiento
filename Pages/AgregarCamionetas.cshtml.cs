using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class AgregarCamionetasModel : PageModel
    {
        private readonly MantencionDbContext _context;
        public List<Camioneta> camionetas { get; set; }

        public AgregarCamionetasModel(MantencionDbContext context)
        {
            _context = context;
            camionetas = new List<Camioneta>();
        }
        
        public void OnGet()
        {
            camionetas = _context.Camionetas.ToList();
        }

        public void OnPost(string patente, int kilometraje, string modelo, string marca, int año)
        {
            Camioneta p = new Camioneta() { Patente = patente, Kilometraje = kilometraje, Modelo = modelo, Marca = marca, Año = año };
            _context.Camionetas.Add(p);

            _context.SaveChanges();
        }
    }
}
