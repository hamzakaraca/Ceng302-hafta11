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
    public class WareHouseManager : IWareHouseService
    {
        IWareHouseDal _wareHouseDal;
        public WareHouseManager(IWareHouseDal wareHouseDal)
        {
            _wareHouseDal = wareHouseDal;
        }
        [SecuredOperation("WareHouse.admin,admin")]
        [CacheRemoveAspect("IWareHouseService.Get")]
        [ValidationAspect(typeof(WareHouseValidator))]
        public IResult Add(WareHouse entity)
        {
            _wareHouseDal.Add(entity);
            return new SuccessResult(Messages.WareHouseAdded);
        }
        [SecuredOperation("WareHouse.admin,admin")]
        [CacheRemoveAspect("IWareHouseService.Get")]
        
        public IResult Delete(WareHouse entity)
        {
            _wareHouseDal.Delete(entity);
            return new SuccessResult(Messages.WareHouseDeleted);
        }
        [CacheAspect]
        public IDataResult<List<WareHouse>> GetAll()
        {
            return new SuccessDataResult<List<WareHouse>>(_wareHouseDal.GetAll(),Messages.WareHouseListed);
        }

        public IDataResult<WareHouse> GetById(int entityId)
        {
            return new SuccessDataResult<WareHouse>(_wareHouseDal.Get(w => w.Id == entityId));
        }

        [SecuredOperation("WareHouse.admin,admin")]
        [CacheRemoveAspect("IWareHouseService.Get")]
        [ValidationAspect(typeof(WareHouseValidator))]
        public IResult Update(WareHouse entity)
        {
            _wareHouseDal.Update(entity);
            return new SuccessResult(Messages.WareHouseUpdated);
        }
    }
}
