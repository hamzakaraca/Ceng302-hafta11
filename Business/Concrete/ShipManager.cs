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
    public class ShipManager : IShipService
    {
        IShipDal _shipDal;
        public ShipManager(IShipDal shipDal)
        {
            _shipDal = shipDal;
        }

        [SecuredOperation("Ship.admin,admin")]
        [CacheRemoveAspect("IShipService.Get")]
        [ValidationAspect(typeof(ShipValidator))]
        public IResult Add(Ship entity)
        {
            _shipDal.Add(entity);
            return new SuccessResult(Messages.ShipAdded);
        }

        [SecuredOperation("Ship.admin,admin")]
        [CacheRemoveAspect("IShipService.Get")]
        public IResult Delete(Ship entity)
        {
            _shipDal.Delete(entity);
            return new SuccessResult(Messages.ShipDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Ship>> GetAll()
        {
            return new SuccessDataResult<List<Ship>>(_shipDal.GetAll(),Messages.ShipListed);
        }

        public IDataResult<Ship> GetById(int entityId)
        {
            return new SuccessDataResult<Ship>(_shipDal.Get(s => s.Id == entityId));
        }

        [SecuredOperation("Ship.admin,admin")]
        [CacheRemoveAspect("IShipService.Get")]
        [ValidationAspect(typeof(ShipValidator))]
        public IResult Update(Ship entity)
        {
            _shipDal.Update(entity);
            return new SuccessResult(Messages.ShipUpdated);
        }
    }
}
