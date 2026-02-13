namespace Lab2.Airplanes.Api.Application.DTOs
{
    public class AirplaneCreateDto
    {
        public string Name { get; set; } = "";
        public string Model { get; set; } = "";
        public int Status { get; set; } = 1; // default Activo
    }
}
