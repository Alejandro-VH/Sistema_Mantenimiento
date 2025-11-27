public class Camioneta
{
    public int Id { get; set; }

    public string Patente { get; set; } = string.Empty;

    public int Kilometraje { get; set; }
    public string Modelo { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public int Año { get; set; }
    // Estados posibles:
    // "Disponible", "EnArriendo", "EnMantencion"
    public string Estado { get; set; } = "Disponible";

}