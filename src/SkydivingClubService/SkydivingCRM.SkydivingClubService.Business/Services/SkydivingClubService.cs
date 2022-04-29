using System;
using System.Threading.Tasks;
using AutoMapper;
using SkydivingCRM.SkydivingClubService.Business.Models.SkydivingClub;
using SkydivingCRM.SkydivingClubService.Business.Models.User;
using SkydivingCRM.SkydivingClubService.Business.RabbitMq.Events.Send;
using SkydivingCRM.SkydivingClubService.Business.RabbitMq.Senders;
using SkydivingCRM.SkydivingClubService.Business.Services.IServices;
using SkydivingCRM.SkydivingClubService.Data.Entities;
using SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories;

namespace SkydivingCRM.SkydivingClubService.Business.Services
{
    public class SkydivingClubService : ISkydivingClubService
    {
        private readonly ISkydivingClubRepository _skydivingClubRepository;
        private readonly IMapper _mapper;
        private readonly SkydivingClubCreatedSender _skydivingClubCreatedSender;

        public SkydivingClubService(ISkydivingClubRepository skydivingClubRepository, IMapper mapper, SkydivingClubCreatedSender skydivingClubCreatedSender)
        {
            _skydivingClubRepository = skydivingClubRepository;
            _mapper = mapper;
            _skydivingClubCreatedSender = skydivingClubCreatedSender;
        }

        public async Task<SkydivingClubModel> GetSkydivingClub(Guid clubId)
        {
            var club = await _skydivingClubRepository.GetAsync(clubId);
            return _mapper.Map<SkydivingClubEntity, SkydivingClubModel>(club);
        }

        public async Task<SkydivingClubModel> RegisterSkydivingClub(SkydivingClubModel skydivingClubModel, UserModel director, string directorPassword)
        {
            var clubEntity = _mapper.Map<SkydivingClubModel, SkydivingClubEntity>(skydivingClubModel);
            clubEntity = await _skydivingClubRepository.CreateAsync(clubEntity);

            director.SkydivingClubId = clubEntity.Id;
            _skydivingClubCreatedSender.Send(new SkydivingClubCreatedEvent(director, directorPassword));

            return _mapper.Map<SkydivingClubEntity, SkydivingClubModel>(clubEntity);
        }

        public async Task<SkydivingClubModel> UpdateSkydivingClub(SkydivingClubModel skydivingClubModel)
        {
            var skydivingClubEntity = await _skydivingClubRepository.GetAsync(skydivingClubModel.Id);

            skydivingClubEntity.Address = skydivingClubModel.Address;
            skydivingClubEntity.Description = skydivingClubModel.Description;
            skydivingClubEntity.FoundationDate = skydivingClubModel.FoundationDate;
            skydivingClubEntity.Title = skydivingClubModel.Title;

            skydivingClubEntity = await _skydivingClubRepository.UpdateAsync(skydivingClubEntity);
            return _mapper.Map<SkydivingClubEntity, SkydivingClubModel>(skydivingClubEntity);
        }
    }
}