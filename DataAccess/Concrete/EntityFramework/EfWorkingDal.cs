using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWorkingDal : EfEntityRepositoryBase<Working, PortManagementContext>, IWorkingDal
    {
        public WorkingDetailDto GetWorkingDetail(int workingId)
        {
            using (PortManagementContext context=new PortManagementContext())
            {
                var result = from w in context.Working
                             join p in context.Port on w.PortId equals p.Id
                             join e in context.Employee on w.EmployeeId equals e.Id
                             select new WorkingDetailDto { WorkingId = w.Id,PortName=p.PortName,EmployeeName=e.Name,Salary=w.Salary};
                return result.SingleOrDefault(w => w.WorkingId == workingId);
            }
        }

        public List<WorkingDetailDto> GetWorkingDetails()
        {
            using (PortManagementContext context=new PortManagementContext())
            {
                var result = from w in context.Working
                             join p in context.Port on w.PortId equals p.Id
                             join e in context.Employee on w.EmployeeId equals e.Id
                             select new WorkingDetailDto { WorkingId = w.Id, PortName = p.PortName, EmployeeName = e.Name, Salary = w.Salary };
                return result.ToList();
            }
        }
    }
}
