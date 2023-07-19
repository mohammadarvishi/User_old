using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Model.UnitOfWork;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewAllUsersController : ControllerBase
    {
        private readonly IUnitOfWork _uW;

        public ViewAllUsersController(IUnitOfWork unitOfWork)
        {
            this._uW = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ViewAllUsers()
        {
            var users = await _uW.UsersRepository.FindAllAsync();
            return Ok(users);
        }
    }
}
