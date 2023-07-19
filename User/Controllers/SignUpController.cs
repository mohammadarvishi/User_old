using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Model.UnitOfWork;
using Users.Model.ViewModels;
using Users.Services;
using static Users.Protos.Token;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IUnitOfWork _uW;
        private readonly ICreateToken _createToken;

        public SignUpController(IUnitOfWork UW,ICreateToken createToken)
        {
            _uW = UW;
            _createToken = createToken;
        }

        [HttpPost]
        public async Task<IActionResult> CreatAsync(UserViewModel userViewModel)
        {
            var User = await _uW.UsersRepository.FindUserNameAsync(userViewModel.UserName);
            if (User == null)
            {
                var CreateUser = await _uW.UsersRepository.CreateAsync(userViewModel);
                if (CreateUser!=null)
                {
                    var token =await _createToken.Token(CreateUser);
                    return Ok(token);
                }
                else
                {
                    var error = new ErrorViewModel
                    {
                        Message = "An issue has occurred with storing information."
                    };
                    return BadRequest(error);
                }
            }
            else
            {
                var error = new ErrorViewModel
                {
                    Message = "The username is already taken."

                };
                return BadRequest(error);
            }
        }
    }
}
