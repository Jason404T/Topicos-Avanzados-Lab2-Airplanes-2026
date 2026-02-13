namespace Lab2.Airplanes.Mvc.Models
{
    public class AirplaneViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Model { get; set; } = "";
        public int Status { get; set; } // 1 activo, 2 inactivo
    }
}
