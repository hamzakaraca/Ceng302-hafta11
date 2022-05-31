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
    public class MissionManager : IMissionService
    {
        IMissionDal _missionDal;
        public MissionManager(IMissionDal missionDal)
        {
            _missionDal = missionDal;
        }
        [SecuredOperation("Mission.admin,admin")]
        [CacheRemoveAspect("IMissionService.Get")]
        [ValidationAspect(typeof(MissionValidator))]
        public IResult Add(Mission entity)
        {
            _missionDal.Add(entity);
            return new SuccessResult(Messages.MissionAdded);
        }
        [SecuredOperation("Mission.admin,admin")]
        [CacheRemoveAspect("IMissionService.Get")]
        public IResult Delete(Mission entity)
        {
            _missionDal.Delete(entity);
            return new SuccessResult(Messages.MissionDeleted);
        }

        public IDataResult<List<Mission>> GetAll()
        {
            return new SuccessDataResult<List<Mission>>(_missionDal.GetAll(),Messages.MissionListed);
        }

        public IDataResult<Mission> GetById(int entityId)
        {
            return new SuccessDataResult<Mission>(_missionDal.Get(m=>m.Id==entityId));
        }
        [SecuredOperation("Mission.admin,admin")]
        [CacheRemoveAspect("IMissionService.Get")]
        [ValidationAspect(typeof(MissionValidator))]
        public IResult Update(Mission entity)
        {
            return new SuccessResult(Messages.MissionUpdated);
        }
    }
}
