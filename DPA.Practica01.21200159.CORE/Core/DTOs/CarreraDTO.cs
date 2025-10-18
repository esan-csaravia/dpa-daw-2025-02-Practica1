namespace DPA.Practica01._21200159.CORE.Core.DTOs
{
    public class CarreraDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }

    public class CarreraListDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }

    public class CarreraCreateDTO
    {
        public string? Nombre { get; set; }
    }
}
