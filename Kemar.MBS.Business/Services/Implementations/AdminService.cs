using Kemar.MBS.Business.Helpers;
using Kemar.MBS.Business.Services.Implementations;
using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Admin.Request;
using Kemar.MBS.Model.Auth.Response;
using Kemar.MBS.Model.Common;
using Kemar.MBS.Repository.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly JwtToken _jwtToken;
    private readonly IAuthService _authService;

    public AdminService(IAdminRepository adminRepository, JwtToken jwtToken, IAuthService authService)
    {
        _adminRepository = adminRepository;
        _jwtToken = jwtToken;
        _authService = authService;
    }

    public async Task<ResultModel> CreateAdminAsync(AdminCreateRequestDto request)
    {
        var admin = await _adminRepository.CreateAdminAsync(request);
        return ResultModel.Created(admin, "Admin created successfully");
    }

    public async Task<ResultModel> LoginAdminAsync(AdminLoginRequestDto request)
    {
        var admin = await _adminRepository.GetAdminForAuthAsync(request.AdminEmail);
        if (admin == null)
            return ResultModel.Unauthorized("Invalid admin credentials");

        bool valid = BCrypt.Net.BCrypt.Verify(request.Password, admin.Password);
        if (!valid)
            return ResultModel.Unauthorized("Invalid admin credentials");

        // 1️⃣ Generate Access Token (JWT)
        string accessToken = _jwtToken.GenerateToken(
            admin.AdminId,
            admin.AdminEmail,
            "Admin"
        );

        // 2️⃣ Extract JTI from JWT
        var jwtHandler = new JwtSecurityTokenHandler();
        var tokenObj = jwtHandler.ReadJwtToken(accessToken);
        var jti = tokenObj.Id;

        // 3️⃣ Generate Refresh Token & Save it
        var refreshToken = await _authService.GenerateRefreshTokenAsync(
            null,            // userId
            admin.AdminId,   // adminId
            jti
        );

        // 4️⃣ Build response
        var response = new AuthResponseDto
        {
            Id = admin.AdminId,
            Name = admin.AdminName,
            Email = admin.AdminEmail,
            Role = "Admin",
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };

        return ResultModel.Success(response, "Login successful");
    }


    public async Task<ResultModel> GetAdminByIdAsync(int adminId)
    {
        var admin = await _adminRepository.GetAdminByIdAsync(adminId);
        if (admin == null)
            return ResultModel.NotFound("Admin not found");

        return ResultModel.Success(admin);
    }

    public async Task<ResultModel> GetAllAdminsAsync()
    {
        var admins = await _adminRepository.GetAllAdminsAsync();
        return ResultModel.Success(admins);
    }

    public async Task<ResultModel> GetDailySummaryAsync(DateTime date)
    {
        var summary = await _adminRepository.GetDailySummaryAsync(date);
        return ResultModel.Success(summary);
    }

    public async Task<ResultModel> GetShowReportAsync(int showId)
    {
        var report = await _adminRepository.GetShowReportAsync(showId);
        return ResultModel.Success(report);
    }

    public async Task<ResultModel> GetMovieReportAsync(int movieId)
    {
        var report = await _adminRepository.GetMovieReportAsync(movieId);
        return ResultModel.Success(report);
    }
}
