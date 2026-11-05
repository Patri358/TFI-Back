using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Application.Models.Auth;
using Application.Interfaces;
using Domain.Entities;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<AuthResponseDTO> Register(RegisterAuthDTO request)
        {
            // 1) Verificar si ya existe un usuario con ese email
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new InvalidOperationException("El email ya se encuentra registrado.");

            // 2) Crear nuevo usuario mapeando todos los campos y hasheando la contraseña
            var user = new User
            {
                Dni = request.Dni,
                Name = request.Name,
                Email = request.Email,
                Telephone = request.Telephone,
                State = true,
                BirthDate = request.BirthDate,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Rol = request.Rol
            };

            // 3) Guardar usuario en la base de datos
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            // 4) Generar token y devolver respuesta
            return GenerateToken(user);
        }

        public async Task<AuthResponseDTO> Login(LoginRequestDTO request)
        {
            // 1) Buscar usuario por email
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Credenciales inválidas.");

            // 2) Verificar contraseña con BCrypt
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isValidPassword)
                throw new UnauthorizedAccessException("Credenciales inválidas.");

            // 3) Generar token
            return GenerateToken(user);
        }

        private AuthResponseDTO GenerateToken(User user)
        {
            // 1) Crear claims usando el rol específico del usuario
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.GivenName, user.Name ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.Rol.ToString())
            };

            // 2) Obtener configuración JWT
            var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key no está configurado");
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];
            var jwtExpires = int.Parse(_configuration["Jwt:ExpiresInMinutes"] ?? "60");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiresAt = DateTime.UtcNow.AddMinutes(jwtExpires);

            // 3) Crear token
            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: expiresAt,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            // 4) Armar respuesta
            return new AuthResponseDTO
            {
                Token = tokenString,
                ExpiresAt = expiresAt,
                Email = user.Email ?? string.Empty,
                FullName = user.Name?.Trim() ?? string.Empty,
                Rol = user.Rol
            };
        }
    }
}