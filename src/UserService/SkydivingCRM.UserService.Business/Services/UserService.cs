using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.UserService.Business.Constants;
using SkydivingCRM.UserService.Business.Models.User;
using SkydivingCRM.UserService.Business.Services.IServices;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<RoleEntity> _roleManager;
        private readonly IMapper _mapper;


        public UserService(UserManager<UserEntity> userManager, RoleManager<RoleEntity> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<UserModel> RegisterInstructor(UserModel instructor, string password)
        {
            await VerifyOnLoginRepeat(instructor);

            var userEntity = _mapper.Map<UserModel, UserEntity>(instructor);
            await _userManager.CreateAsync(userEntity, password);
            await _userManager.AddToRoleAsync(userEntity, RolesConstants.SportsmanRole);

            return _mapper.Map<UserEntity, UserModel>(userEntity);
        }

        public async Task<UserModel> RegisterSportsman(UserModel sportsman, string password)
        {
            await VerifyOnLoginRepeat(sportsman);

            var userEntity = _mapper.Map<UserModel, UserEntity>(sportsman);
            await _userManager.CreateAsync(userEntity, password);
            await _userManager.AddToRoleAsync(userEntity, RolesConstants.SportsmanRole);
            await _userManager.AddToRoleAsync(userEntity, RolesConstants.InstructorRole);

            return _mapper.Map<UserEntity, UserModel>(userEntity);
        }

        public Task AddSportsmanToGroup(SkydivingGroupSportsmanModel model)
        {
            throw new NotImplementedException();
        }

        public Task AddInstructorToGroup(SkydivingGroupInstructorModel model)
        {
            throw new NotImplementedException();
        }

        private async Task VerifyOnLoginRepeat(UserModel userModel)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Login == userModel.Login);
            if (user is not null)
            {
                throw new Exception($"User with {userModel.Login} already exists!");
            }
        }
    }
}