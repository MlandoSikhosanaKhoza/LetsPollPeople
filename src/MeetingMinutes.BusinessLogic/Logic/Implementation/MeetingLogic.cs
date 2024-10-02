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
    public class MeetingLogic : IMeetingLogic
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MeetingLogic(IMeetingRepository meetingRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _unitOfWork        = unitOfWork;
            _mapper            = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MeetingModel Create(MeetingModel model)
        {
            Meeting meeting = _mapper.Map<Meeting>(model);
            _meetingRepository.Insert(meeting);
            _unitOfWork.SaveChanges();
            return _mapper.Map<MeetingModel>(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MeetingModel Update(MeetingModel model)
        {
            Meeting? meeting = _meetingRepository.GetById(model.MeetingId);
            if (meeting == null)
            {
                throw new ArgumentNullException("Meeting Id doesn't exist");
            }
            _mapper.Map(model, meeting);

            _meetingRepository.Update(meeting);
            _unitOfWork.SaveChanges();

            return _mapper.Map<MeetingModel>(meeting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MeetingModel Delete(int meetingId)
        {
            Meeting? meeting = _meetingRepository.GetById(meetingId);
            if (meeting == null)
            {
                throw new ArgumentNullException("Meeting Id doesn't exist");
            }
            meeting.IsDeleted = true;

            _meetingRepository.Update(meeting);
            _unitOfWork.SaveChanges();

            return _mapper.Map<MeetingModel>(meeting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MeetingModel> GetAll()
        {
            return _meetingRepository.GetAll().Select(_mapper.Map<MeetingModel>);
        }

        /// <summary>
        /// Gets a meeting model
        /// </summary>
        /// <param name="meetingId">Used to identify which meeting to fetch</param>
        /// <returns>Gets type MeetingModel for the provided meetingId</returns>
        /// <exception cref="ArgumentNullException">Usually occurs when meeting Id doesn't exist in the database</exception>
        public MeetingModel GetById(int meetingId)
        {
            Meeting? meeting = _meetingRepository.GetById(meetingId);
            if (meeting == null)
            {
                throw new ArgumentNullException("Meeting Id doesn't exist");
            }
            return _mapper.Map<MeetingModel>(meeting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="meetingTypeId"></param>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MeetingModel GetPreviousByMeetingType(int meetingTypeId, DateTime currentDate)
        {
            Meeting? meeting = _meetingRepository.GetPreviousByMeetingType(meetingTypeId,currentDate);
            if (meeting == null)
            {
                throw new ArgumentNullException("Meeting Id doesn't exist");
            }
            return _mapper.Map<MeetingModel>(meeting);
        }
    }
}
