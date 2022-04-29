using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.UserService.Business.Constants;
using SkydivingCRM.UserService.Business.Models.Auth;
using SkydivingCRM.UserService.Business.Models.User;
using SkydivingCRM.UserService.Business.Services.IServices;
using SkydivingCRM.UserService.Data.Entities;
using SkydivingCRM.UserService.Data.Repositories.IRepositories;

namespace SkydivingCRM.UserService.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthService(
            UserManager<UserEntity> userManager, 
            IMapper mapper, 
            IUserRepository userRepository, 
            IPasswordHasher<UserEntity> passwordHasher, ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task RegisterClubAdministrator(UserModel admin, string password)
        {
            await VerifyOnLoginRepeatAsync(admin);

            var userEntity = _mapper.Map<UserModel, UserEntity>(admin);
            userEntity.PasswordHash = _passwordHasher.HashPassword(userEntity, password);
            await _userManager.CreateAsync(userEntity);
            await _userManager.AddToRoleAsync(userEntity, RolesConstants.ClubAdministratorRole);
            await _userManager.AddToRoleAsync(userEntity, RolesConstants.InstructorRole);
            await _userManager.AddToRoleAsync(userEntity, RolesConstants.SportsmanRole);
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            var userEntity = await _userRepository.GetByLoginAsync(loginModel.Login) ??
                             throw new Exception($"User with login = [{loginModel.Login}] not found!");

            var passwordVerificationResult =
                _passwordHasher.VerifyHashedPassword(userEntity, userEntity.PasswordHash, loginModel.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid password!");
            }

            var userRoles = await _userManager.GetRolesAsync(userEntity);
            var userModel = _mapper.Map<UserEntity, UserModel>(userEntity);
            userModel.Roles = userRoles.ToList();

            return _tokenService.GenerateJwtAsync(userModel);
        }

        public async Task ConfirmEmail(Guid userId, string code)
        {
            var user = await _userRepository.GetAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                var exception = new StringBuilder();
                foreach (var ex in result.Errors)
                {
                    exception.Append(ex.Description + ";");
                }
                throw new Exception(exception.ToString());
            }
        }

        private async Task VerifyOnLoginRepeatAsync(UserModel userModel)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Login == userModel.Login);
            if (user is not null)
            {
                throw new Exception($"User with [{userModel.Login}] login already exists!");
            }
        }
    }
}