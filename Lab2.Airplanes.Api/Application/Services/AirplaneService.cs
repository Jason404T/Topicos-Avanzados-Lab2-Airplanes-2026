using Lab2.Airplanes.Api.Application.DTOs;
using Lab2.Airplanes.Api.Application.Interfaces;
using Lab2.Airplanes.Api.Domain.Entities;

namespace Lab2.Airplanes.Api.Application.Services
{
    public class AirplaneService
    {
        private readonly IAirplaneRepository _repo;

        public AirplaneService(IAirplaneRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Airplane> GetAll()
            => _repo.GetAll();

        public IEnumerable<Airplane> GetActive()
            => _repo.GetByStatus(1);

        public IEnumerable<Airplane> GetInactive()
            => _repo.GetByStatus(2);

        public Airplane? GetById(int id)
            => _repo.GetById(id);

        public Airplane Create(AirplaneCreateDto dto)
        {
            if (dto.Status != 1 && dto.Status != 2)
                throw new ArgumentException("Status must be 1 or 2");

            var airplane = new Airplane
            {
                Name = dto.Name.Trim(),
                Model = dto.Model.Trim(),
                Status = dto.Status
            };

            return _repo.Create(airplane);
        }

        public bool Update(int id, AirplaneUpdateDto dto)
        {
            if (dto.Status != 1 && dto.Status != 2)
                throw new ArgumentException("Status must be 1 or 2");

            var airplane = new Airplane
            {
                Id = id,
                Name = dto.Name.Trim(),
                Model = dto.Model.Trim(),
                Status = dto.Status
            };

            return _repo.Update(id, airplane);
        }

        public bool Inactivate(int id)
            => _repo.SetStatus(id, 2);

        public bool Activate(int id)
            => _repo.SetStatus(id, 1);
    }
}
