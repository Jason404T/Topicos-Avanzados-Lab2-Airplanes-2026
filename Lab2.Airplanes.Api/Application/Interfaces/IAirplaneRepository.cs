using Lab2.Airplanes.Api.Domain.Entities;

namespace Lab2.Airplanes.Api.Application.Interfaces
{
    public interface IAirplaneRepository
    {
        IEnumerable<Airplane> GetAll();
        IEnumerable<Airplane> GetByStatus(int status);
        Airplane? GetById(int id);
        Airplane Create(Airplane airplane);
        bool Update(int id, Airplane airplane);
        bool SetStatus(int id, int status);
    }
}
