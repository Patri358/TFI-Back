using Application.Interfaces;
using Application.Models;
using Application.Models.Dog;
using System.Net;
using System.Net.Http.Json;

namespace Infrastructure.Services
{

    public class DogService : IDogServices
    {
        private readonly HttpClient _httpClient;

        public DogService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("dogs");
        }

        public async Task<List<BreedDTO>> GetBreedListAsync()
            => await _httpClient.GetFromJsonAsync<List<BreedDTO>>("breeds/list/all") ?? [];

        public async Task<List<SubBreedDTO>> GetSubBreedListAsync(string breed)
            => await _httpClient.GetFromJsonAsync<List<SubBreedDTO>>($"breed/{breed}/list") ?? [];

        public async Task<DogImageDTO?> GetRandomDogAsync()
            => await _httpClient.GetFromJsonAsync<DogImageDTO?>("breeds/image/random");

        public async Task<List<DogImageDTO>> GetMultipleRandomDogAsync (int cantidad)
            => await _httpClient.GetFromJsonAsync<List<DogImageDTO>>($"breeds/image/random/{cantidad}") ?? [];

        public async Task<List<DogImageDTO?>> GetDogsByBreedAsync(string breed)
            => await _httpClient.GetFromJsonAsync<List<DogImageDTO?>>($"breed/{breed}/images") ?? [];

        public async Task<DogImageDTO?> GetRandomDogByBreedAsync(string breed)
            => await _httpClient.GetFromJsonAsync<DogImageDTO?>($"breed/{breed}/images/random");

        public async Task<List<DogImageDTO?>> GetMultipleRandomDogByBreedAsync(string breed, int cantidad)
            => await _httpClient.GetFromJsonAsync<List<DogImageDTO?>>($"breed/{breed}/images/random/{cantidad}") ?? [];

        public async Task<List<DogImageDTO?>> GetDogsBySubBreedAsync(string breed, string subBreed)
             => await _httpClient.GetFromJsonAsync<List<DogImageDTO?>>($"breed/{breed}/{subBreed}/images") ?? [];

        public async Task<DogImageDTO?> GetRandomDogBySubBreedAsync(string breed, string subBreed)
            => await _httpClient.GetFromJsonAsync<DogImageDTO?>($"breed/{breed}/{subBreed}/images/random");

        public async Task<List<DogImageDTO?>> GetMultipleRandomDogBySubBreedAsync(string breed, string subBreed, int cantidad)
            => await _httpClient.GetFromJsonAsync<List<DogImageDTO?>>($"breed/{breed}/{subBreed}/images/random/{cantidad}") ?? [];
        
    }
}
