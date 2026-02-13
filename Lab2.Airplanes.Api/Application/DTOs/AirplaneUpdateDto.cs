namespace Lab2.Airplanes.Api.Application.DTOs
{
    public class AirplaneUpdateDto
    {
        public string Name { get; set; } = "";
        public string Model { get; set; } = "";
        public int Status { get; set; } // 1 o 2
    }
}
