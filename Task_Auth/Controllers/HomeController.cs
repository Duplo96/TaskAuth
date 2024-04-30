using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Task_Auth.Auth;
using Task_Auth.Models;
using Task_Auth.Services;

namespace Task_Auth.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly UtenteService _service;
        public HomeController(UtenteService service)
        {
            _service = service;
        }



        [HttpPost("login")]
        public IActionResult Login([FromBody] UtenteLogin model)
        {
            Utente? temp = _service.GetByUsername(model.Username);
            if (temp != null)
            {
                // Qui dovresti avere una logica per validare l'utente con il database
                if (model.Username == temp.Username && model.Password == temp.Pass)
                {
                    var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserType", temp.Tipo)  // Aggiungi il tipo di utente come claim
                };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "YourIssuer",
                        audience: "YourAudience",
                        claims: claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: creds);

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
            }
            return Unauthorized();
        }

        [HttpGet("admin")]
        [AuthorizeUserType("ADMIN")]
        public IActionResult GetOwnerData()
        {
            // Solo gli utenti con tipo "OWNR" possono accedere a questo metodo
            return Ok("Dati sensibili per il proprietario");
        }

        //[HttpGet("user-data")]
        //[AuthorizeUserType("USER")]
        //public IActionResult GetUserData()
        //{
        //    // Solo gli utenti con tipo "OWNR" possono accedere a questo metodo
    
        
    }
}
