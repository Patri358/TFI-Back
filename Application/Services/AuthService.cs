//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using Application.Models.Auth;
//using Application.Interfaces;
//using Domain.Entities;
//using System.Security.Claims;
//using System.Text;

//namespace Application.Services
//{
//    public class AuthService : IAuthService
//    {
//        private readonly IUserRepository _userRepository;
//        private readonly IConfiguration _configuration;

//        public AuthService(IUserRepository userRepository, IConfiguration configuration)
//        {
//            _userRepository = userRepository;
//            _configuration = configuration;
//        }

//        public async Task<AuthResponseDTO> Register(RegisterAuthDTO request)
//        {
//            // 1) Verificar si ya existe un usuario con ese email
//            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
//            if (existingUser != null)
//                throw new Exception("El email ya se encuentra registrado.");

//            // 2) Crear nuevo usuario con contraseña hasheada
//            var user = new User
//            {
//                Name = request.Name,
//                Email = request.Email,
//                Telephone = request.Telephone,
//                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
//            };

//            // 3) Guardar usuario
//            await _userRepository.AddAsync(user);
//            await _userRepository.SaveChangesAsync();

//            // 4) Asignar rol por defecto si existe (ajustar según tu lógica)
//            var defaultRole = await _userRepository.GetByNameAsync("Cliente");

//            // 5) Generar token y devolver respuesta
//            return await GenerateToken(user);
//        }

//        public async Task<AuthResponseDTO> Login(LoginRequestDTO request)
//        {
//            // 1) Buscar usuario por email
//            var user = await _userRepository.GetByEmailAsync(request.Email);
//            if (user == null)
//                throw new UnauthorizedAccessException("Credenciales inválidas.");

//            // 2) Verificar contraseña con BCrypt
//            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
//            if (!isValidPassword)
//                throw new UnauthorizedAccessException("Credenciales inválidas.");

//            // 3) Generar token
//            return await GenerateToken(user);
//        }

//        private async Task<AuthResponseDTO> GenerateToken(User user)
//        {
//            // 1) Obtener roles del usuario
//            var roles = await _roleRepository.GetRolesByUserIdAsync(user.Id);

//            // 2) Crear claims
//            var claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
//                new Claim(ClaimTypes.GivenName, user.Name ?? string.Empty),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//            };

//            // Agregar roles como claims
//            foreach (var role in roles)
//            {
//                claims.Add(new Claim(ClaimTypes.Role, role.Name));
//            }

//            // 3) Obtener configuración JWT
//            var jwtKey = _configuration["Jwt:Key"] ?? throw new Exception("Jwt:Key no está configurado");
//            var jwtIssuer = _configuration["Jwt:Issuer"];
//            var jwtAudience = _configuration["Jwt:Audience"];
//            var jwtExpires = int.Parse(_configuration["Jwt:ExpiresInMinutes"] ?? "60");

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var expiresAt = DateTime.UtcNow.AddMinutes(jwtExpires);

//            // 4) Crear token
//            var token = new JwtSecurityToken(
//                issuer: jwtIssuer,
//                audience: jwtAudience,
//                claims: claims,
//                expires: expiresAt,
//                signingCredentials: creds
//            );

//            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

//            // 5) Armar respuesta
//            return new AuthResponseDTO
//            {
//                Token = tokenString,
//                ExpiresAt = expiresAt,
//                Email = user.Email ?? string.Empty,
//                FullName = $"{user.Name}".Trim(),
//                Roles = roles.Select(r => r.Name).ToList()
//            };
//        }
//    }
//}