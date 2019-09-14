using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Base;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;

namespace VedSoft.Data.Contracts.Repository.Master
{
    public interface IMasterRepository:IRepositoryBase<CustomerCourseHierarchyDB>
    {
        int AddCourseHierarchy(RequestModel<CourseHiearchyModel> input);
        int UpdateCourseHierarchy(RequestModel<CourseHiearchyModel> input);
        List<CourseHiearchyModel> GetCourseHierarchy(SearchRequestModel<CourseHiearchyModel> input);

        int MakeInActiveCourseHierarchy(RequestModel<CourseHiearchyModel> input);

        bool DoesCourseHieararchyExist(RequestModel<CourseHiearchyModel> input);

        bool DoesCourseHieararchyExistUpdate(RequestModel<CourseHiearchyModel> input);

        bool DoesCourseHieararchyIdExist(RequestModel<CourseHiearchyModel> input);
       
    }
}
