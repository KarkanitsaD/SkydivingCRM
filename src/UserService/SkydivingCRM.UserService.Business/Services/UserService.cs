using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.AuthCommon;
using SkydivingCRM.UserService.Business.Exceptions;
using SkydivingCRM.UserService.Business.Models.Media;
using SkydivingCRM.UserService.Business.Models.User;
using SkydivingCRM.UserService.Business.Services.IServices;
using SkydivingCRM.UserService.Data.Entities;
using SkydivingCRM.UserService.Data.Repositories.IRepositories;

namespace SkydivingCRM.UserService.Business.Services
{
    public class UserService : IUserService
    {
        private readonly ISkydivingGroupSportsmanRepository _skydivingGroupSportsmanRepository;
        private readonly ISkydivingGroupInstructorRepository _skydivingGroupInstructorRepository;
        private readonly IUserImageRepository _userImageRepository;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;


        public UserService(
            UserManager<UserEntity> userManager,
            IMapper mapper,
            ISkydivingGroupInstructorRepository skydivingGroupInstructorRepository,
            ISkydivingGroupSportsmanRepository skydivingGroupSportsmanRepository, IUserImageRepository userImageRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _skydivingGroupInstructorRepository = skydivingGroupInstructorRepository;
            _skydivingGroupSportsmanRepository = skydivingGroupSportsmanRepository;
            _userImageRepository = userImageRepository;
        }

        public async Task<UserModel> RegisterInstructor(UserModel instructor, string password)
        {
            await VerifyOnLoginRepeatAsync(instructor);

            var userEntity = _mapper.Map<UserModel, UserEntity>(instructor);
            await _userManager.CreateAsync(userEntity, password);
            await _userManager.AddToRoleAsync(userEntity, RolesConstants.SportsmanRole);
            await _userManager.AddToRoleAsync(userEntity, RolesConstants.InstructorRole);

            return _mapper.Map<UserEntity, UserModel>(userEntity);
        }

        public async Task<UserModel> RegisterSportsman(UserModel sportsman, string password)
        {
            await VerifyOnLoginRepeatAsync(sportsman);

            var userEntity = _mapper.Map<UserModel, UserEntity>(sportsman);
            await _userManager.CreateAsync(userEntity, password);
            await _userManager.AddToRoleAsync(userEntity, RolesConstants.SportsmanRole);

            return _mapper.Map<UserEntity, UserModel>(userEntity);
        }

        public async Task AddSportsmanToGroup(SkydivingGroupSportsmanModel model)
        {
            await VerifyOnUserFoundAsync(model.UserId);

            var entityToCreate = _mapper.Map<SkydivingGroupSportsmanModel, SkydivingGroupSportsmanEntity>(model);
            await _skydivingGroupSportsmanRepository.CreateAsync(entityToCreate);
        }

        public async Task AddInstructorToGroup(SkydivingGroupInstructorModel model)
        {
            await VerifyOnUserFoundAsync(model.UserId);

            var entityToCreate = _mapper.Map<SkydivingGroupInstructorModel, SkydivingGroupInstructorEntity>(model);
            await _skydivingGroupInstructorRepository.CreateAsync(entityToCreate);
        }

        public async Task RemoveSportsmanFromGroup(SkydivingGroupSportsmanModel model)
        {
            var sportsmanGroupEntity = await _skydivingGroupSportsmanRepository.GetAsync(model.UserId, model.GroupId);
            if (sportsmanGroupEntity is null)
            {
                throw new BadRequestException(
                    $"Sportsman with id = [{model.UserId}] is not in group with id = [{model.GroupId}]!");
            }

            await _skydivingGroupSportsmanRepository.RemoveAsync(sportsmanGroupEntity);
        }

        public async Task RemoveInstructorFromGroup(SkydivingGroupInstructorModel model)
        {
            var instructorGroupEntity = await _skydivingGroupInstructorRepository.GetAsync(model.UserId, model.GroupId);
            if (instructorGroupEntity is null)
            {
                throw new BadRequestException(
                    $"Instructor with id = [{model.UserId}] is not in group with id = [{model.GroupId}]!");
            }

            await _skydivingGroupInstructorRepository.RemoveAsync(instructorGroupEntity);
        }

        public async Task SetUserImage(MediaByteArrayModel image, Guid userId)
        {
            var imageId = await _userImageRepository.GetIdByUserIdAsync(userId);
            if (imageId != Guid.Empty)
            {
                await _userImageRepository.RemoveAsync(new UserImageEntity {Id = imageId});
            }

            var userImageEntity = new UserImageEntity(image.Content, image.Extension, userId);

            await _userImageRepository.CreateAsync(userImageEntity);
        }

        public async Task RemoveUserImage(Guid userId)
        {
            var imageId = await _userImageRepository.GetIdByUserIdAsync(userId);
            if (imageId != Guid.Empty)
            {
                await _userImageRepository.RemoveAsync(new UserImageEntity { Id = imageId });
            }
        }

        private async Task VerifyOnLoginRepeatAsync(UserModel userModel)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Login == userModel.Login);
            if (user is not null)
            {
                throw new BadRequestException($"User with [{userModel.Login}] login already exists!");
            }
        }

        private async Task VerifyOnUserFoundAsync(Guid userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user is null)
            {
                throw new NotFoundException($"User with id = [{userId}] not found!");
            } 
        }
    }
}