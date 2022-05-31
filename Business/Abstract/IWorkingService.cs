using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWorkingService:IEntityServiceBase<Working>
    {
        IDataResult<List<WorkingDetailDto>> GetWorkingsDetail();
        IDataResult<WorkingDetailDto> GetWorkingDetail(int entityId);
    }
}
