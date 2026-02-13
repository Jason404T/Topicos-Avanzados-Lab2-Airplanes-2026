using Lab2.Airplanes.Api.Application.Interfaces;
using Lab2.Airplanes.Api.Domain.Entities;

namespace Lab2.Airplanes.Api.Infrastructure.Repositories
{
    public class InMemoryAirplaneRepository : IAirplaneRepository
    {
        private static readonly List<Airplane> _db = new()
        {
            new Airplane { Id = 1, Name = "Airplane 1", Model = "Boeing 737", Status = 1 },
            new Airplane { Id = 2, Name = "Airplane 2", Model = "Airbus A320", Status = 2 }
        };

        private static int _nextId = 3;

        public IEnumerable<Airplane> GetAll()
            => _db.OrderBy(a => a.Id);

        public IEnumerable<Airplane> GetByStatus(int status)
            => _db.Where(a => a.Status == status).OrderBy(a => a.Id);

        public Airplane? GetById(int id)
            => _db.FirstOrDefault(a => a.Id == id);

        public Airplane Create(Airplane airplane)
        {
            airplane.Id = _nextId++;
            _db.Add(airplane);
            return airplane;
        }

        public bool Update(int id, Airplane airplane)
        {
            var existing = GetById(id);
            if (existing is null) return false;

            existing.Name = airplane.Name;
            existing.Model = airplane.Model;
            existing.Status = airplane.Status;
            return true;
        }

        public bool SetStatus(int id, int status)
        {
            var existing = GetById(id);
            if (existing is null) return false;

            existing.Status = status;
            return true;
        }
    }
}
