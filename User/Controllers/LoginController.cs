using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Model.UnitOfWork;
using Users.Model.ViewModels;
using Users.Services;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _uW;
        private readonly ICreateToken _createToken;

        public LoginController(IUnitOfWork UW, ICreateToken createToken)
        {
            _uW = UW;
            this._createToken = createToken;
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            var User = await _uW.UsersRepository.FindUserNameAsync(loginViewModel.UserName);
            if (User != null)
            {
                if (User.Password == loginViewModel.Password)
                {
                    var token = await _createToken.Token(User.Id.ToString());
                    return Ok(token);
                }
                else
                {
                    var error = new ErrorViewModel
                    {
                        Message = "The password is incorrect.",
                    };
                    return BadRequest(error);
                }
            }
            else
            {
                var error = new ErrorViewModel
                {
                    Message = "The username is incorrect.",
                };
                return BadRequest(error);
            }
        }
    }
}
