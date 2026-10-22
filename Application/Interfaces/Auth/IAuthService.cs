using Application.Models.Auth;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> Register(RegisterAuthDTO request);
        Task<AuthResponseDTO> Login(LoginRequestDTO request);
    }
}
