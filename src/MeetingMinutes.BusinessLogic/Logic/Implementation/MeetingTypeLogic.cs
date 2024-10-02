using AutoMapper;
using MeetingMinutes.DAL;
using MeetingMinutes.DAL.Entities;
using MeetingMinutes.DAL.Repository;
using MeetingMinutes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.BusinessLogic
{
    public class MeetingTypeLogic : IMeetingTypeLogic
    {
        private readonly IMeetingTypeRepository _meetingTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MeetingTypeLogic(IMeetingTypeRepository meetingTypeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _meetingTypeRepository = meetingTypeRepository;
            _unitOfWork            = unitOfWork;
            _mapper                = mapper;
        }

        public MeetingTypeModel Create(MeetingTypeModel model)
        {
            MeetingType meetingType = _mapper.Map<MeetingType>(model);
            _meetingTypeRepository.Insert(meetingType);
            _unitOfWork.SaveChanges();
            return _mapper.Map<MeetingTypeModel>(meetingType);
        }

        public MeetingTypeModel Update(MeetingTypeModel model)
        {
            MeetingType? meetingType = _meetingTypeRepository.GetById(model.MeetingTypeId);
            if (meetingType == null)
            {
                throw new ArgumentNullException("Meeting Type Id doesn't exist");
            }
            _mapper.Map(model, meetingType);

            _meetingTypeRepository.Update(meetingType);
            _unitOfWork.SaveChanges();
            
            return _mapper.Map<MeetingTypeModel>(meetingType);
        }

        public MeetingTypeModel Delete(int meetingTypeId)
        {
            MeetingType? meetingType = _meetingTypeRepository.GetById(meetingTypeId);
            if (meetingType == null)
            {
                throw new ArgumentNullException("Meeting Type Id doesn't exist");
            }
            meetingType.IsDeleted = true;

            _meetingTypeRepository.Update(meetingType);
            _unitOfWork.SaveChanges();

            return _mapper.Map<MeetingTypeModel>(meetingType);
        }

        public IEnumerable<MeetingTypeModel> GetAll()
        {
            return _meetingTypeRepository.GetAll().Select(_mapper.Map<MeetingTypeModel>);
        }

    }
}
