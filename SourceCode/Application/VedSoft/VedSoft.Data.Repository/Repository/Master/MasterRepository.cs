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
                                  && x.AcademicYear == input.RequestParameter.AcademicYear
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

    public class BankRepository : RepositoryBase<BankDB>, IBankRepository
    {
        public BankRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public int AddBank(RequestModel<BankModel> input)
        {
            //Make db object
            BankDB bankDB = new BankDB
            {
                CreatedBy = input.RequestParameter.UserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                BankName = input.RequestParameter.BankName,
                CustomerId = input.CustomerId.GetValueOrDefault()
            };

            //Save in database
            this.RepositoryContext.Add(bankDB);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = bankDB.Id;

            return bankDB.Id;
        }

        public int UpdateBank(RequestModel<BankModel> input)
        {
            var bankYear = this.RepositoryContext.Bank
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (bankYear != null)
            {
                bankYear.BankName = input.RequestParameter.BankName;
                bankYear.ModifiedBy = input.RequestParameter.UserId;
                bankYear.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(bankYear);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<BankModel> GetBankList(SearchRequestModel<BankModel> input)
        {
            List<BankModel> bankModelList = new List<BankModel>();
            var bankList = this.RepositoryContext.Bank
                                      .Where(x => x.CustomerId == input.CustomerId
                                      && x.Active == CommonConstants.ActiveStatus)
                                      .Page(input.PageSize, input.PageNumber);


            foreach (var bank in bankList.ToList())
            {
                bankModelList.Add(new BankModel
                {
                    Id = bank.Id,
                    BankName = bank.BankName
                });
            }

            return bankModelList;
        }

        public int MakeInActiveBank(RequestModel<BankModel> input)
        {
            var bank = this.RepositoryContext.Bank
                                    .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (bank != null)
            {
                bank.Active = CommonConstants.InActiveStatus;
                bank.ModifiedBy = input.RequestParameter.UserId;
                bank.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(bank);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public bool DoesBankExist(RequestModel<BankModel> input)
        {
            return this.RepositoryContext.Bank
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.BankName == input.RequestParameter.BankName
                                  && x.Active == CommonConstants.ActiveStatus)
                                  .Count() > 0;
        }

        public bool DoesBankExistUpdate(RequestModel<BankModel> input)
        {
            return this.RepositoryContext.Bank
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Active == CommonConstants.ActiveStatus
                                  && x.BankName == input.RequestParameter.BankName
                                  && x.Id != input.RequestParameter.Id)
                                  .Count() > 0;
        }

        public bool DoesBankIdExist(RequestModel<BankModel> input)
        {
            return this.RepositoryContext.Bank
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Id == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }

    public class EducationalInstituteRepository : RepositoryBase<EducationInstituteDB>, IEducationInstituteRepository
    {
        public EducationalInstituteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public int AddEducationInstitute(RequestModel<EducationInstituteModel> input)
        {
            //Make db object
            EducationInstituteDB educationInstitute = new EducationInstituteDB
            {
                CreatedBy = input.RequestParameter.UserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                InstitutionTypeId = input.RequestParameter.InstituteTypeId,
                CustomerId = input.CustomerId.GetValueOrDefault(),
                Name = input.RequestParameter.Name,
            };

            //Save in database
            this.RepositoryContext.Add(educationInstitute);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = educationInstitute.Id;

            return educationInstitute.Id;
        }

        public int UpdateEducationInstitute(RequestModel<EducationInstituteModel> input)
        {
            var educationalInstitute = this.RepositoryContext.EducationInstitute
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (educationalInstitute != null)
            {
                educationalInstitute.Name = input.RequestParameter.Name;
                educationalInstitute.InstitutionTypeId = input.RequestParameter.InstituteTypeId;
                educationalInstitute.ModifiedBy = input.RequestParameter.UserId;
                educationalInstitute.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(educationalInstitute);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<EducationInstituteModel> GetEducationInstituteList(SearchRequestModel<EducationInstituteModel> input)
        {
            List<EducationInstituteModel> educationalInstituteList = new List<EducationInstituteModel>();
            var educationInstituteList = this.RepositoryContext.EducationInstitute
                                      .Where(x => x.CustomerId == input.CustomerId
                                      && x.Active == CommonConstants.ActiveStatus)
                                      .Page(input.PageSize, input.PageNumber);


            foreach (var institute in educationInstituteList.ToList())
            {
                educationalInstituteList.Add(new EducationInstituteModel
                {
                    Id = institute.Id,
                    InstituteTypeId = institute.InstitutionTypeId,
                    Name = institute.Name
                });
            }

            return educationalInstituteList;
        }

        public int MakeInActiveEducationInstitute(RequestModel<EducationInstituteModel> input)
        {
            var educationalInstitute = this.RepositoryContext.EducationInstitute
                                    .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (educationalInstitute != null)
            {
                educationalInstitute.Active = CommonConstants.InActiveStatus;
                educationalInstitute.ModifiedBy = input.RequestParameter.UserId;
                educationalInstitute.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(educationalInstitute);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public bool DoesEducationInstituteExist(RequestModel<EducationInstituteModel> input)
        {
            return this.RepositoryContext.EducationInstitute
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Name == input.RequestParameter.Name
                                  && x.Active == CommonConstants.ActiveStatus)
                                  .Count() > 0;
        }

        public bool DoesEducationInstituteExistUpdate(RequestModel<EducationInstituteModel> input)
        {
            return this.RepositoryContext.EducationInstitute
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Active == CommonConstants.ActiveStatus
                                  && x.Name == input.RequestParameter.Name
                                  && x.Id != input.RequestParameter.Id)
                                  .Count() > 0;
        }

        public bool DoesEducationInstituteIdExist(RequestModel<EducationInstituteModel> input)
        {
            return this.RepositoryContext.EducationInstitute
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Id == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }

    public class CustomerCourseRepository : RepositoryBase<CustomerCourseDB>, ICustomerCourseRepository
    {
        public CustomerCourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public int AddCustomerCourse(RequestModel<CustomerCourseModel> input)
        {
            //Make db object
            CustomerCourseDB educationInstitute = new CustomerCourseDB
            {
                CreatedBy = input.RequestParameter.UserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                CourseCost = input.RequestParameter.CourseCost,
                CourseDescription = input.RequestParameter.CourseDescription,
                CourseTypeId = input.RequestParameter.CourseTypeId,
                Duration = input.RequestParameter.Duration,
                DurationUOM = input.RequestParameter.DurationUOM,
                VedicCourseId = input.RequestParameter.VedicCourseId,
                CustomerId = input.CustomerId.GetValueOrDefault(),
                Name = input.RequestParameter.Name,
            };

            //Save in database
            this.RepositoryContext.Add(educationInstitute);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = educationInstitute.Id;

            return educationInstitute.Id;
        }

        public int UpdateCustomerCourse(RequestModel<CustomerCourseModel> input)
        {
            var customerCourse = this.RepositoryContext.CustomerCourse
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (customerCourse != null)
            {
                customerCourse.Name = input.RequestParameter.Name;
                customerCourse.VedicCourseId = input.RequestParameter.VedicCourseId;
                customerCourse.CourseTypeId = input.RequestParameter.CourseTypeId;
                customerCourse.CourseDescription = input.RequestParameter.CourseDescription;
                customerCourse.Duration = input.RequestParameter.Duration;
                customerCourse.DurationUOM = input.RequestParameter.DurationUOM;
                customerCourse.CourseCost = input.RequestParameter.CourseCost;
                customerCourse.ModifiedBy = input.RequestParameter.UserId;
                customerCourse.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(customerCourse);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<CustomerCourseModel> GetCustomerCourseList(SearchRequestModel<CustomerCourseModel> input)
        {
            List<CustomerCourseModel> customerCourseList = new List<CustomerCourseModel>();
            var customerCourseListDB = this.RepositoryContext.CustomerCourse
                                      .Where(x => x.CustomerId == input.CustomerId
                                      && x.Active == CommonConstants.ActiveStatus)
                                      .Page(input.PageSize, input.PageNumber);


            foreach (var customerCourse in customerCourseListDB.ToList())
            {
                customerCourseList.Add(new CustomerCourseModel
                {
                    Id = customerCourse.Id,
                    CourseCost = customerCourse.CourseCost,
                    DurationUOM = customerCourse.DurationUOM,
                    Duration = customerCourse.Duration,
                    CourseDescription = customerCourse.CourseDescription,
                    CourseTypeId = customerCourse.CourseTypeId,
                    //CustomerId = customerCourse.CustomerId,
                    VedicCourseId = customerCourse.VedicCourseId,
                    Name = customerCourse.Name
                });
            }

            return customerCourseList;
        }

        public int MakeInActiveCustomerCourse(RequestModel<CustomerCourseModel> input)
        {
            var customerCourse = this.RepositoryContext.CustomerCourse
                                    .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (customerCourse != null)
            {
                customerCourse.Active = CommonConstants.InActiveStatus;
                customerCourse.ModifiedBy = input.RequestParameter.UserId;
                customerCourse.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(customerCourse);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public bool DoesCustomerCourseExist(RequestModel<CustomerCourseModel> input)
        {
            return this.RepositoryContext.CustomerCourse
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Name == input.RequestParameter.Name
                                  && x.Active == CommonConstants.ActiveStatus)
                                  .Count() > 0;
        }

        public bool DoesCustomerCourseExistUpdate(RequestModel<CustomerCourseModel> input)
        {
            return this.RepositoryContext.CustomerCourse
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Active == CommonConstants.ActiveStatus
                                  && x.Name == input.RequestParameter.Name
                                  && x.Id != input.RequestParameter.Id)
                                  .Count() > 0;
        }

        public bool DoesCustomerCourseIdExist(RequestModel<CustomerCourseModel> input)
        {
            return this.RepositoryContext.CustomerCourse
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Id == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }

    public class CustomerCourseSubjectRepository : RepositoryBase<CustomerCourseSubjectMappingDB>, ICustomerCourseSubjectRepository
    {
        public CustomerCourseSubjectRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public int AddCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input)
        {
            //Make db object
            CustomerCourseSubjectMappingDB customerCourseSubject = new CustomerCourseSubjectMappingDB
            {
                CreatedBy = input.RequestParameter.UserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                CustomerId = input.CustomerId.GetValueOrDefault(),
                CustomerCourseId = input.RequestParameter.CustomerCourseId,
                CustomerSubjectHierarchyId = input.RequestParameter.CustomerSubjectHiearchyId
            };

            //Save in database
            this.RepositoryContext.Add(customerCourseSubject);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = customerCourseSubject.Id;

            return customerCourseSubject.Id;
        }

        public int UpdateCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input)
        {
            var customerCourseSubject = this.RepositoryContext.CustomerCourseSubject
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (customerCourseSubject != null)
            {
                customerCourseSubject.CustomerSubjectHierarchyId = input.RequestParameter.CustomerSubjectHiearchyId;
                customerCourseSubject.ModifiedBy = input.RequestParameter.UserId;
                customerCourseSubject.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(customerCourseSubject);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<CustomerCourseSubjectModel> GetCustomerCourseSubjectList(SearchRequestModel<CustomerCourseSubjectModel> input)
        {
            List<CustomerCourseSubjectModel> customerCourseSubjectList = new List<CustomerCourseSubjectModel>();
            var customerCourseSubjectListDB = this.RepositoryContext.CustomerCourseSubject
                                      .Where(x => x.CustomerId == input.CustomerId
                                      && x.Active == CommonConstants.ActiveStatus)
                                      .Page(input.PageSize, input.PageNumber);


            foreach (var customerCourse in customerCourseSubjectListDB.ToList())
            {
                customerCourseSubjectList.Add(new CustomerCourseSubjectModel
                {
                    Id = customerCourse.Id,
                    CustomerCourseId = customerCourse.CustomerCourseId,
                    CustomerSubjectHiearchyId = customerCourse.CustomerSubjectHierarchyId,
                });
            }

            return customerCourseSubjectList;
        }

        public int MakeInActiveCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input)
        {
            var customerCourse = this.RepositoryContext.CustomerCourseSubject
                                    .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (customerCourse != null)
            {
                customerCourse.Active = CommonConstants.InActiveStatus;
                customerCourse.ModifiedBy = input.RequestParameter.UserId;
                customerCourse.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(customerCourse);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public bool DoesCustomerCourseSubjectExist(RequestModel<CustomerCourseSubjectModel> input)
        {
            return this.RepositoryContext.CustomerCourseSubject
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.CustomerCourseId==input.RequestParameter.CustomerCourseId
                                  && x.CustomerSubjectHierarchyId== input.RequestParameter.CustomerSubjectHiearchyId
                                  && x.Active == CommonConstants.ActiveStatus)
                                  .Count() > 0;
        }

        public bool DoesCustomerCourseSubjectExistUpdate(RequestModel<CustomerCourseSubjectModel> input)
        {
            return this.RepositoryContext.CustomerCourseSubject
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Active == CommonConstants.ActiveStatus
                                  && x.CustomerCourseId == input.RequestParameter.CustomerCourseId
                                  && x.CustomerSubjectHierarchyId == input.RequestParameter.CustomerSubjectHiearchyId
                                  && x.Id != input.RequestParameter.Id)
                                  .Count() > 0;
        }

        public bool DoesCustomerCourseSubjectIdExist(RequestModel<CustomerCourseSubjectModel> input)
        {
            return this.RepositoryContext.CustomerCourseSubject
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Id == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }
}
