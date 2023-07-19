using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Model.UnitOfWork;
using Users.Model.ViewModels;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUnitOfWork _uW;

        public UserInfoController(IUnitOfWork unitOfWork)
        {
            this._uW = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UserInfo()
        {
            string UserId = HttpContext.User.FindFirst("userid").Value;
            var User = await _uW.UsersRepository.FindIdAsync(new Guid(UserId));
            return Ok(User);
        }
    }
}
