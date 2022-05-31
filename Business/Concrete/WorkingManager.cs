using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class WorkingManager : IWorkingService
    {
        IWorkingDal _workingDal;
        public WorkingManager(IWorkingDal workingDal)
        {
            _workingDal = workingDal;
        }
        [SecuredOperation("Working.admin,admin")]
        [CacheRemoveAspect("IWorkingService.Get")]
        [ValidationAspect(typeof(WorkingValidator))]
        public IResult Add(Working entity)
        {
            _workingDal.Add(entity);
            return new SuccessResult(Messages.WorkingAdded);
        }
        [SecuredOperation("Working.admin,admin")]
        [CacheRemoveAspect("IWorkingService.Get")]
        public IResult Delete(Working entity)
        {
            _workingDal.Delete(entity);
            return new SuccessResult(Messages.WorkingDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Working>> GetAll()
        {
            return new SuccessDataResult<List<Working>>(_workingDal.GetAll(),Messages.WorkingListed);
        }

        public IDataResult<Working> GetById(int entityId)
        {
            return new SuccessDataResult<Working>(_workingDal.Get(w=>w.Id==entityId));
        }

        public IDataResult<WorkingDetailDto> GetWorkingDetail(int entityId)
        {
            return new SuccessDataResult<WorkingDetailDto>(_workingDal.GetWorkingDetail(entityId));
        }

        public IDataResult<List<WorkingDetailDto>> GetWorkingsDetail()
        {
            return new SuccessDataResult<List<WorkingDetailDto>>(_workingDal.GetWorkingDetails());
        }

        [SecuredOperation("Working.admin,admin")]
        [CacheRemoveAspect("IWorkingService.Get")]
        [ValidationAspect(typeof(WorkingValidator))]
        public IResult Update(Working entity)
        {
            _workingDal.Update(entity);
            return new SuccessResult(Messages.WorkingUpdated);
        }
    }
}
