public class HistorialMantencion
{
    public int Id { get; set; }

    public string Patente { get; set; } = string.Empty;

    public string Accion { get; set; } = string.Empty;  
    // Ej.: "Retiro", "Reintegro", "CambioEstado"

    public DateTime Fecha { get; set; } = DateTime.Now;

    public int? NuevoKilometraje { get; set; }
}
