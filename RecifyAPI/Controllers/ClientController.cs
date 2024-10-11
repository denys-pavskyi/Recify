using BLL.Interfaces;
using BLL.RequestModels;
using BLL.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace RecifyAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpPost]
        [Route("signIn")]
        public async Task<ActionResult> SignIn(LoginModel loginRequest)
        {
            var response = await _clientService.LoginAsync(loginRequest);
            return response.Match<ActionResult>(
                Ok,
                error => error.ToActionResult());
        }


    }
}
