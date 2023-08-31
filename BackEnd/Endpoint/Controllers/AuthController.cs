//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Mvc;

//namespace Endpoint
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        [HttpGet("sign-in/{provider}")]
//        public IActionResult SignIn(string provider, string? returnUrl = null)
//        {
//            var x = Challenge(new AuthenticationProperties { RedirectUri = returnUrl ?? "/" }, provider); ;
//            return x;
//        }
//    }
//}
