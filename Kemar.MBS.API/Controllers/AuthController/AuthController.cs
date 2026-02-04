using Kemar.MBS.Business.Helpers;
using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Auth.Request;
using Kemar.MBS.Model.Auth.Response;
using Kemar.MBS.Model.Common;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Kemar.MBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly JwtToken _jwtToken;

        public AuthController(IAuthService authService, JwtToken jwtToken)
        {
            _authService = authService;
            _jwtToken = jwtToken;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpRequestDto dto)
        {
            var otp = await _authService.GenerateOtpAsync(dto.Email);
            return Ok(ResultModel.Success(new { Otp = otp }, "OTP generated"));
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequestDto dto)
        {
            var valid = await _authService.ValidateOtpAsync(dto.Email, dto.Otp);
            return Ok(ResultModel.Success(valid));
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto dto)
        {
            var ok = await _authService.ResetPasswordAsync(dto.Email, dto.Otp, dto.NewPassword);
            if (!ok) return Unauthorized(ResultModel.Unauthorized("Invalid OTP"));
            return Ok(ResultModel.Success(null, "Password reset"));
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestDto dto)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenObj = handler.ReadJwtToken(dto.AccessToken);
            var jti = tokenObj.Id;

            var result = await _authService.ValidateRefreshTokenAsync(dto.RefreshToken, jti);
            if (!result.Success)
                return Unauthorized(ResultModel.Unauthorized(result.Message));

            await _authService.RevokeTokenAsync(dto.RefreshToken);

            int? userId = result.Token.UserId;
            int? adminId = result.Token.AdminId;
            string role = userId != null ? "User" : "Admin";
            string email = tokenObj.Claims.First(c => c.Type == "email").Value;
            int id = userId ?? adminId ?? 0;

            var newJwt = _jwtToken.GenerateToken(id, email, role);
            var newJwtObj = handler.ReadJwtToken(newJwt);
            var newJti = newJwtObj.Id;

            var newRefresh = await _authService.GenerateRefreshTokenAsync(userId, adminId, newJti);

            var response = new AuthResponseDto
            {
                Id = id,
                Name = "",
                Email = email,
                Role = role,
                AccessToken = newJwt,
                RefreshToken = newRefresh.Token
            };

            return Ok(ResultModel.Success(response));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequestDto dto)
        {
            await _authService.RevokeTokenAsync(dto.RefreshToken);
            return Ok(ResultModel.Success(null, "Logged out"));
        }
    }
}
