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
    public class PortManager : IPortService
    {
        IPortDal _portDal;
        public PortManager(IPortDal portDal)
        {
            _portDal = portDal;
        }

        [SecuredOperation("Port.admin,admin")]
        [CacheRemoveAspect("IPortService.Get")]
        [ValidationAspect(typeof(PortValidator))]
        public IResult Add(Port entity)
        {
            _portDal.Add(entity);
            return new SuccessResult(Messages.PortAdded);
        }

        [SecuredOperation("Port.admin,admin")]
        [CacheRemoveAspect("IPortService.Get")]
        public IResult Delete(Port entity)
        {
            _portDal.Delete(entity);
            return new SuccessResult(Messages.PortDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Port>> GetAll()
        {
            return new SuccessDataResult<List<Port>>(_portDal.GetAll(),Messages.PortListed);
        }

        public IDataResult<Port> GetById(int entityId)
        {
            return new SuccessDataResult<Port>(_portDal.Get(p => p.Id == entityId));
        }

        [SecuredOperation("Port.admin,admin")]
        [CacheRemoveAspect("IPortService.Get")]
        [ValidationAspect(typeof(PortValidator))]
        public IResult Update(Port entity)
        {
            _portDal.Update(entity);
            return new SuccessResult(Messages.PortUpdated);
        }
    }
}
