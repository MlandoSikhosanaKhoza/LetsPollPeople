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
    public class StatusLogic : IStatusLogic
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatusLogic(IMapper mapper, IStatusRepository statusRepository, IUnitOfWork unitOfWork)
        {
            _mapper           = mapper;
            _statusRepository = statusRepository;
            _unitOfWork       = unitOfWork;
        }


        public StatusModel Create(StatusModel model)
        {
            Status Status = _mapper.Map<Status>(model);
            _statusRepository.Insert(Status);
            _unitOfWork.SaveChanges();
            return _mapper.Map<StatusModel>(Status);
        }

        public StatusModel Update(StatusModel model)
        {
            Status? Status = _statusRepository.GetById(model.StatusId);
            if (Status == null)
            {
                throw new ArgumentNullException("Status Id doesn't exist");
            }
            _mapper.Map(model, Status);

            _statusRepository.Update(Status);
            _unitOfWork.SaveChanges();

            return _mapper.Map<StatusModel>(Status);
        }

        public StatusModel Delete(int StatusId)
        {
            Status? Status = _statusRepository.GetById(StatusId);
            if (Status == null)
            {
                throw new ArgumentNullException("Status Id doesn't exist");
            }
            Status.IsDeleted = true;

            _statusRepository.Update(Status);
            _unitOfWork.SaveChanges();

            return _mapper.Map<StatusModel>(Status);
        }

        public IEnumerable<StatusModel> GetAll()
        {
            return _statusRepository.GetAll().Select(_mapper.Map<StatusModel>);
        }
    }
}
