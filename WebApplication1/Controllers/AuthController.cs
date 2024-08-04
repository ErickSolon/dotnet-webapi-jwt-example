using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthHelpers _authHelpers;

        public AuthController(AuthHelpers authHelpers)
        {
            _authHelpers = authHelpers;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginModel loginModel)
        {
            // Aqui você deve validar o loginModel, por exemplo, verificando o usuário e senha
            // Estou pulando a validação para simplificação.

            // Exemplo de usuário autenticado (substitua com a lógica de autenticação real)
            var user = new User
            {
                Id = 1,
                Name = loginModel.Username
            };

            // Gere o token JWT
            var token = _authHelpers.GenerateJWTToken(user);

            return Ok(new { Token = token });
        }
    }

    // Modelo para receber os dados de login
    public class UserLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
