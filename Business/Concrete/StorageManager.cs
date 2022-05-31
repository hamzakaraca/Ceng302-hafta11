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
    public class StorageManager : IStorageService
    {
        IStorageDal _storageDal;
        public StorageManager(IStorageDal storageDal)
        {
            _storageDal = storageDal;
        }
        [SecuredOperation("Storage.admin,admin")]
        [CacheRemoveAspect("IStorageService.Get")]
        [ValidationAspect(typeof(StorageValidator))]
        public IResult Add(Storage entity)
        {
            _storageDal.Add(entity);
            return new SuccessResult(Messages.StorageAdded);
        }

        [SecuredOperation("Storage.admin,admin")]
        [CacheRemoveAspect("IStorageService.Get")]
        public IResult Delete(Storage entity)
        {
            _storageDal.Delete(entity);
            return new SuccessResult(Messages.StorageDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Storage>> GetAll()
        {
            return new SuccessDataResult<List<Storage>>(_storageDal.GetAll(),Messages.StorageListed);
        }

        public IDataResult<Storage> GetById(int entityId)
        {
            return new SuccessDataResult<Storage>(_storageDal.Get(s => s.Id == entityId));
        }

        [SecuredOperation("Storage.admin,admin")]
        [CacheRemoveAspect("IStorageService.Get")]
        [ValidationAspect(typeof(StorageValidator))]
        public IResult Update(Storage entity)
        {
            _storageDal.Update(entity);
            return new SuccessResult(Messages.StorageUpdated);
        }
    }
}
