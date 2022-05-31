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
    public class CargoManager : ICargoService
    {
        ICargoDal _cargoDal;
        public CargoManager(ICargoDal cargoDal)
        {
            _cargoDal = cargoDal;
        }

        [ValidationAspect(typeof(CargoValidator))]
        [CacheRemoveAspect("ICargoService.Get")]
        [SecuredOperation("Cargo.admin,admin")]
        public IResult Add(Cargo entity)
        {
            _cargoDal.Add(entity);
            return new SuccessResult(Messages.CargoAdded);
        }

        [CacheRemoveAspect("ICargoService.Get")]
        [SecuredOperation("Cargo.admin,admin")]
        public IResult Delete(Cargo entity)
        {
            _cargoDal.Delete(entity);
            return new SuccessResult(Messages.CargoDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Cargo>> GetAll()
        {
            return new SuccessDataResult<List<Cargo>>(_cargoDal.GetAll(), Messages.CargoListed);
        }

        public IDataResult<Cargo> GetById(int entityId)
        {
            return new SuccessDataResult<Cargo>(_cargoDal.Get(c => c.Id == entityId));
        }

        [CacheRemoveAspect("ICargoService.Get")]
        [ValidationAspect(typeof(CargoValidator))]
        [SecuredOperation("Cargo.admin,admin")]
        public IResult Update(Cargo entity)
        {
            _cargoDal.Update(entity);
            return new SuccessResult(Messages.CargoUpdated);
        }
    }
}
