using System.Net.Http.Json;
using Lab2.Airplanes.Mvc.Models;

namespace Lab2.Airplanes.Mvc.Services
{
    public class AirplanesApiClient
    {
        private readonly HttpClient _http;

        public AirplanesApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AirplaneViewModel>> GetAllAsync()
            => await _http.GetFromJsonAsync<List<AirplaneViewModel>>("api/airplanes") ?? new();

        public async Task<List<AirplaneViewModel>> GetActiveAsync()
            => await _http.GetFromJsonAsync<List<AirplaneViewModel>>("api/airplanes/active") ?? new();

        public async Task<List<AirplaneViewModel>> GetInactiveAsync()
            => await _http.GetFromJsonAsync<List<AirplaneViewModel>>("api/airplanes/inactive") ?? new();

        public async Task<AirplaneViewModel?> GetByIdAsync(int id)
            => await _http.GetFromJsonAsync<AirplaneViewModel>($"api/airplanes/{id}");

        public async Task<bool> CreateAsync(AirplaneViewModel vm)
        {
            var res = await _http.PostAsJsonAsync("api/airplanes", new
            {
                name = vm.Name,
                model = vm.Model,
                status = vm.Status
            });

            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(AirplaneViewModel vm)
        {
            var res = await _http.PutAsJsonAsync($"api/airplanes/{vm.Id}", new
            {
                name = vm.Name,
                model = vm.Model,
                status = vm.Status
            });

            return res.IsSuccessStatusCode;
        }

        public async Task<bool> InactivateAsync(int id)
        {
            var res = await _http.PatchAsync($"api/airplanes/{id}/inactivate", null);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> ActivateAsync(int id)
        {
            var res = await _http.PatchAsync($"api/airplanes/{id}/activate", null);
            return res.IsSuccessStatusCode;
        }
    }
}
