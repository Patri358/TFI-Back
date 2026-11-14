using Application.Models;
using Application.Models.Dog;

namespace Application.Interfaces
{
    public interface IDogServices
    {
        Task<List<BreedDTO>> GetBreedListAsync();
        Task<List<SubBreedDTO>> GetSubBreedListAsync(string breed);
        Task<DogImageDTO?> GetRandomDogAsync();
        Task<List<DogImageDTO>> GetMultipleRandomDogAsync(int cantidad);
        Task<List<DogImageDTO?>> GetDogsByBreedAsync(string breed);
        Task<DogImageDTO?> GetRandomDogByBreedAsync(string breed);
        Task<List<DogImageDTO?>> GetMultipleRandomDogByBreedAsync(string breed, int cantidad);
        Task<List<DogImageDTO?>> GetDogsBySubBreedAsync(string breed, string subBreed);
        Task<DogImageDTO?> GetRandomDogBySubBreedAsync(string breed, string subBreed);
        Task<List<DogImageDTO?>> GetMultipleRandomDogBySubBreedAsync(string breed, string subBreed, int cantidad);
    }
}
