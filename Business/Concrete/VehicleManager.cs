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
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }
        [SecuredOperation("Vehicle.admin,admin")]
        [CacheRemoveAspect("IVehicleService.Get")]
        [ValidationAspect(typeof(VehicleValidator))]
        public IResult Add(Vehicle entity)
        {
            _vehicleDal.Add(entity);
            return new SuccessResult(Messages.VehicleAdded);
        }

        [SecuredOperation("Vehicle.admin,admin")]
        [CacheRemoveAspect("IVehicleService.Get")]
        public IResult Delete(Vehicle entity)
        {
            _vehicleDal.Delete(entity);
            return new SuccessResult(Messages.VehicleDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Vehicle>> GetAll()
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(),Messages.VehicleListed);
        }

        public IDataResult<Vehicle> GetById(int entityId)
        {
            return new SuccessDataResult<Vehicle>(_vehicleDal.Get(v => v.Id == entityId));
        }

        [SecuredOperation("Vehicle.admin,admin")]
        [CacheRemoveAspect("IVehicleService.Get")]
        [ValidationAspect(typeof(VehicleValidator))]
        public IResult Update(Vehicle entity)
        {
            _vehicleDal.Update(entity);
            return new SuccessResult(Messages.VehicleUpdated);
        }
    }
}
