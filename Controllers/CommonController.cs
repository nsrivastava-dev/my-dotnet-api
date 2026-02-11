using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureApi.Data.Interface;
using SecureApi.Data.Repository;

namespace SecureApi.Controllers
{
    [Authorize]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IAuthInterface _authRepository;
        public CommonController(IAuthInterface authRepository)
        {
            _authRepository = authRepository;
        }
        [Route("Api/StudentList"),HttpPost]
        public async Task<IActionResult> StudentList()
        {
            var res =await _authRepository.StudentList();
            return Ok(res);
        }
    }
}
