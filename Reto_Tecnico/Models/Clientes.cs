namespace Reto_Tecnico.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public required string Nombre { get; set; } = string.Empty;
        public required string Apellidos { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
    }
}
