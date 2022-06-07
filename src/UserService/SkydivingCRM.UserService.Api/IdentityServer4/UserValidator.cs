using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using SkydivingCRM.UserService.Business.Models.User;
using SkydivingCRM.UserService.Business.Services.IServices;
using SkydivingCRM.UserService.Data.Entities;
using SkydivingCRM.UserService.Data.Repositories.IRepositories;

namespace SkydivingCRM.UserService.Api.IdentityServer4
{
    public class UserValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;

        public UserValidator(UserManager<UserEntity> userManager, IUserRepository userRepository, IMapper mapper, ITokenService tokenService, IPasswordHasher<UserEntity> passwordHasher)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var username = context.UserName;
            var password = context.Password;

            var userEntity = await _userRepository.GetByLoginAsync(username);

            if (userEntity == null)
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.UnauthorizedClient, "User not found");
                return;
            }

            var passwordVerificationResult =
                _passwordHasher.VerifyHashedPassword(userEntity, userEntity.PasswordHash, password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.UnauthorizedClient, "Not correct password");
                return;
            }

            var userRoles = await _userManager.GetRolesAsync(userEntity);
            var userModel = _mapper.Map<UserEntity, UserModel>(userEntity);
            userModel.Roles = userRoles.ToList();

            var claims = _tokenService.GetClaims(userModel);

            context.Result = new GrantValidationResult(username, "custom", claims);
        }
    }
}