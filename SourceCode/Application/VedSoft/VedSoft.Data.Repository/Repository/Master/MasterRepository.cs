using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VedSoft.Data.Contracts.Model;
using VedSoft.Data.Contracts.Repository.Master;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Utility.Constants;
using VedSoft.Utility;

namespace VedSoft.Data.Repository.Repository.Master
{
    public class CustomerCourseHierarchyRepository : RepositoryBase<CustomerCourseHierarchyDB>, ICustomerCourseHierarchyRepository
    {
        public CustomerCourseHierarchyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public int AddCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            //Make db object
            CustomerCourseHierarchyDB customerCourseHierarchyDB = new CustomerCourseHierarchyDB
            {
                CreatedBy = input.RequestParameter.UserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                CustomerId = input.CustomerId.GetValueOrDefault(),
                Name = input.RequestParameter.Name,
                HierarchyLevel=input.RequestParameter.HierarchyLevel,
                ParentId = input.RequestParameter.ParentId == 0 ? null : input.RequestParameter.ParentId
            };

            //Save in database
            this.RepositoryContext.Add(customerCourseHierarchyDB);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = customerCourseHierarchyDB.Id;

            return customerCourseHierarchyDB.Id;
        }

        public int UpdateCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            var courseHierarchy = this.RepositoryContext.CustomerCourseHierarchy
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active==CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (courseHierarchy != null)
            {
                courseHierarchy.Name = input.RequestParameter.Name;
                courseHierarchy.ParentId = input.RequestParameter.ParentId == 0 ? null : input.RequestParameter.ParentId;
                courseHierarchy.ModifiedBy = input.RequestParameter.UserId;
                courseHierarchy.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(courseHierarchy);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<CourseHiearchyModel> GetCourseHierarchy(SearchRequestModel<CourseHiearchyModel> input)
        {
            List<CourseHiearchyModel> courseHiearchyModelList = new List<CourseHiearchyModel>();
            var courseHierarchyList = this.RepositoryContext.CustomerCourseHierarchy
                                      .Where(x => x.CustomerId == input.CustomerId 
                                      && 
                                        (input.RequestParameter.HierarchyLevel==0 
                                        || input.RequestParameter.HierarchyLevel == null
                                        || x.HierarchyLevel==input.RequestParameter.HierarchyLevel)
                                      && x.Active == CommonConstants.ActiveStatus)
                                      .Page(input.PageSize,input.PageNumber);


            foreach (var courseHierarchy in courseHierarchyList.ToList())
            {
                courseHiearchyModelList.Add(new CourseHiearchyModel
                {
                    Id = courseHierarchy.Id,
                    Name = courseHierarchy.Name,
                    ParentId = courseHierarchy.ParentId,
                    HierarchyLevel=courseHierarchy.HierarchyLevel
                });
            }

            return courseHiearchyModelList;
        }

        public int MakeInActiveCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            var courseHierarchy = this.RepositoryContext.CustomerCourseHierarchy
                                    .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (courseHierarchy != null)
            {
                courseHierarchy.Active = CommonConstants.InActiveStatus;
                courseHierarchy.ModifiedBy = input.RequestParameter.UserId;
                courseHierarchy.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(courseHierarchy);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success; 
        }

        public bool DoesCourseHieararchyExist(RequestModel<CourseHiearchyModel> input)
        {
            input.RequestParameter.ParentId = input.RequestParameter.ParentId == 0 ? null : input.RequestParameter.ParentId;
            return this.RepositoryContext.CustomerCourseHierarchy
                                  .Where(x => x.CustomerId==input.CustomerId 
                                  && x.Active== CommonConstants.ActiveStatus
                                  && (x.ParentId == input.RequestParameter.ParentId || (x.ParentId==null && input.RequestParameter.ParentId==null))
                                  && x.Name.ToLower() == input.RequestParameter.Name.ToLower())
                                  .Count() >0;
        }

        public bool DoesCourseHieararchyExistUpdate(RequestModel<CourseHiearchyModel> input)
        {
            return this.RepositoryContext.CustomerCourseHierarchy
                                  .Where(x => x.CustomerId == input.CustomerId 
                                  && x.Name.ToLower() == input.RequestParameter.Name.ToLower()
                                  && x.Active == CommonConstants.ActiveStatus
                                  && (x.ParentId == input.RequestParameter.ParentId || (x.ParentId == null && input.RequestParameter.ParentId == null))
                                  && x.Active == CommonConstants.ActiveStatus
                                  && x.Id != input.RequestParameter.Id)
                                  .Count() > 0;
        }

        public bool DoesCourseHieararchyIdExist(RequestModel<CourseHiearchyModel> input)
        {
            return this.RepositoryContext.CustomerCourseHierarchy
                                  .Where(x => x.CustomerId == input.CustomerId 
                                  && x.Id == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }

    public class AcademicYearRepository : RepositoryBase<AcademicYearsDB>, IAcademicYearRepository
    {
        public AcademicYearRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public int AddAcademicYear(RequestModel<AcademicYearModel> input)
        {
            //Make db object
            AcademicYearsDB academicYearDB = new AcademicYearsDB
            {
                CreatedBy = input.RequestParameter.UserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                AcademicYear = input.RequestParameter.AcademicYear,
                CustomerId = input.CustomerId.GetValueOrDefault()
            };

            //Save in database
            this.RepositoryContext.Add(academicYearDB);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = academicYearDB.Id;

            return academicYearDB.Id;
        }

        public int UpdateAcademicYear(RequestModel<AcademicYearModel> input)
        {
            var academicYear = this.RepositoryContext.AcademicYears
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (academicYear != null)
            {
                academicYear.AcademicYear = input.RequestParameter.AcademicYear;
                academicYear.ModifiedBy = input.RequestParameter.UserId;
                academicYear.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(academicYear);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<AcademicYearModel> GetAcademicYears(SearchRequestModel<AcademicYearModel> input)
        {
            List<AcademicYearModel> academicYearModelList = new List<AcademicYearModel>();
            var academicYearList = this.RepositoryContext.AcademicYears
                                      .Where(x => x.CustomerId == input.CustomerId
                                      && x.Active == CommonConstants.ActiveStatus)
                                      .Page(input.PageSize, input.PageNumber);


            foreach (var academicYear in academicYearList.ToList())
            {
                academicYearModelList.Add(new AcademicYearModel
                {
                    Id = academicYear.Id,
                    AcademicYear= academicYear.AcademicYear
                });
            }

            return academicYearModelList;
        }

        public int MakeInActiveAcademicYear(RequestModel<AcademicYearModel> input)
        {
            var academicYear = this.RepositoryContext.AcademicYears
                                    .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (academicYear != null)
            {
                academicYear.Active = CommonConstants.InActiveStatus;
                academicYear.ModifiedBy = input.RequestParameter.UserId;
                academicYear.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(academicYear);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public bool DoesAcademicYearExist(RequestModel<AcademicYearModel> input)
        {
            return this.RepositoryContext.AcademicYears
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Active == CommonConstants.ActiveStatus)
                                  .Count() > 0;
        }

        public bool DoesAcademicYearExistUpdate(RequestModel<AcademicYearModel> input)
        {
            return this.RepositoryContext.AcademicYears
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Active == CommonConstants.ActiveStatus
                                  && x.AcademicYear == input.RequestParameter.AcademicYear
                                  && x.Id != input.RequestParameter.Id)
                                  .Count() > 0;
        }

        public bool DoesAcademicYearIdExist(RequestModel<AcademicYearModel> input)
        {
            return this.RepositoryContext.AcademicYears
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Id == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }
}
