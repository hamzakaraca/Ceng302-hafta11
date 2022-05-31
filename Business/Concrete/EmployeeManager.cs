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
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        [SecuredOperation("Employee.admin,admin")]
        [CacheRemoveAspect("IEmployeeService.Get")]
        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Add(Employee entity)
        {
            _employeeDal.Add(entity);
            return new SuccessResult(Messages.EmployeeAdded);
        }

        [SecuredOperation("Employee.admin,admin")]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult Delete(Employee entity)
        {
            _employeeDal.Delete(entity);
            return new SuccessResult(Messages.EmployeeDeleted);
        }

        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll());
        }

        public IDataResult<Employee> GetById(int entityId)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(e=>e.Id==entityId));
        }

        [SecuredOperation("Employee.admin,admin")]
        [CacheRemoveAspect("IEmployeeService.Get")]
        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Update(Employee entity)
        {
            _employeeDal.Update(entity);
            return new SuccessResult(Messages.EmployeeUpdated);
        }
    }
}
