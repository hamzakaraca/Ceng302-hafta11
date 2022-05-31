using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CheckInManager : ICheckInService
    {
        ICheckInDal _checkInDal;
        public CheckInManager(ICheckInDal checkInDal)
        {
            _checkInDal = checkInDal;
        }
        [SecuredOperation("CheckIn.admin,admin")]
        [CacheRemoveAspect("ICheckInService.Get")]
        [ValidationAspect(typeof(CheckInValidator))]
        public IResult Add(CheckIn entity)
        {
            _checkInDal.Add(entity);
            return new SuccessResult(Messages.CheckInAdded);

        }
        [SecuredOperation("CheckIn.admin,admin")]
        [CacheRemoveAspect("ICheckInService.Get")]
        public IResult Delete(CheckIn entity)
        {
            _checkInDal.Delete(entity);
            return new SuccessResult(Messages.CheckInDeleted);
        }

        public IDataResult<List<CheckIn>> GetAll()
        {
            return new SuccessDataResult<List<CheckIn>>(_checkInDal.GetAll(),Messages.CheckInListed);
        }

        public IDataResult<CheckIn> GetById(int entityId)
        {
            return new SuccessDataResult<CheckIn>(_checkInDal.Get(c=>c.Id==entityId));
        }
        [SecuredOperation("CheckIn.admin,admin")]
        [CacheRemoveAspect("ICheckInService.Get")]
        [ValidationAspect(typeof(CheckInValidator))]
        public IResult Update(CheckIn entity)
        {
            _checkInDal.Update(entity);
            return new SuccessResult(Messages.CheckInUpdated);
        }
    }
}
