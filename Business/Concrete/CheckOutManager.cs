using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CheckOutManager : ICheckOutService
    {
        ICheckOutDal _checkOutDal;
        public CheckOutManager(ICheckOutDal checkOutDal)
        {
            _checkOutDal = checkOutDal;
        }

        [SecuredOperation("CheckOut.admin,admin")]
        [CacheRemoveAspect("ICheckOutService.Get")]
        [ValidationAspect(typeof(CheckOutValidator))]
        public IResult Add(CheckOut entity)
        {
            _checkOutDal.Add(entity);
            return new SuccessResult(Messages.CheckOutAdded);
        }
        [SecuredOperation("CheckOut.admin,admin")]
        [CacheRemoveAspect("ICheckOutService.Get")]
        public IResult Delete(CheckOut entity)
        {
            _checkOutDal.Delete(entity);
            return new SuccessResult(Messages.CheckOutDeleted);
        }

        public IDataResult<List<CheckOut>> GetAll()
        {
            return new SuccessDataResult<List<CheckOut>>(_checkOutDal.GetAll(),Messages.CheckOutListed);
        }

        public IDataResult<CheckOut> GetById(int entityId)
        {
            return new SuccessDataResult<CheckOut>(_checkOutDal.Get(c=>c.Id==entityId));
        }
        [SecuredOperation("CheckOut.admin,admin")]
        [CacheRemoveAspect("ICheckOutService.Get")]
        [ValidationAspect(typeof(CheckOutValidator))]
        public IResult Update(CheckOut entity)
        {
            _checkOutDal.Update(entity);
            return new SuccessResult(Messages.CheckOutUpdated);
        }
    }
}
