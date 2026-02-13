namespace Lab2.Airplanes.Api.Domain.Entities
{
    public class Airplane
    {
        public int Id { get; set; }              // numero de Id
        public string Name { get; set; } = "";   // nombre del avion
        public string Model { get; set; } = "";  // modelo
        public int Status { get; set; }          // 1 = Activo, 2 = Inactivo
    }
}
