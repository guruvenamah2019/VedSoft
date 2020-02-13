using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Utility.APIHandler;
using VedSoft.Utility.Constants;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model.User;

namespace VedSoft.Business.Master
{
    public class MasterBusiness : BusinessBase, IMasterBusiness
    {
        #region Customer
        //To add a new customer
        public ResultModel AddCustomer(CustomerModel input)
        {
            //Make db object
            CustomerModelDB objCustomerModelDB = new CustomerModelDB
            {
                Active = input.Active,
                Address = input.Address,
                Code = input.Code,
                ContactNumber = input.ContactNumber,
                CreatedBy = input.CreatedBy,
                CreatedDate = input.CreatedDate,
                Description = input.Description,
                Name = input.Name,
                OtherInfo = input.OtherInfo,
                SubDomain = input.SubDomain
            };

            //Save in database
            RepositoryWrapper.CustomerRepository.Create(objCustomerModelDB);
            RepositoryWrapper.CustomerRepository.Save();

            return new ResultModel { PrimaryKey = input.CustomerId };
        }

        //To get the customer details by Id
        public CustomerModel GetCustomerDetailsById(CustomerModel input)
        {
            var customerDetails = RepositoryWrapper
                                    .CustomerRepository
                                    .FindByCondition(x => x.CustomerId == input.CustomerId)
                                    .FirstOrDefault();

            return new CustomerModel
            {
                Code = customerDetails.Code,
                Address = customerDetails.Address,
                Active = customerDetails.Active,
                ContactNumber = customerDetails.ContactNumber,
                CreatedBy = customerDetails.CreatedBy,
                CreatedDate = customerDetails.CreatedDate,
                CustomerId = customerDetails.CustomerId,
                Description = customerDetails.Description,
                Name = customerDetails.Name,
                OtherInfo = customerDetails.OtherInfo,
                SubDomain = customerDetails.SubDomain
            };

        }

        public CustomerModel GetCustomerDetailsBySubDomain(CustomerModel input)
        {
            var customerDetails = RepositoryWrapper
                                    .CustomerRepository
                                    .FindByCondition(x => x.SubDomain.ToLower() == input.SubDomain.ToLower())
                                    .FirstOrDefault();

            return new CustomerModel
            {
                Code = customerDetails.Code,
                Address = customerDetails.Address,
                Active = customerDetails.Active,
                ContactNumber = customerDetails.ContactNumber,
                CreatedBy = customerDetails.CreatedBy,
                CreatedDate = customerDetails.CreatedDate,
                CustomerId = customerDetails.CustomerId,
                Description = customerDetails.Description,
                Name = customerDetails.Name,
                OtherInfo = customerDetails.OtherInfo,
                SubDomain = customerDetails.SubDomain
            };

        }
        #endregion

        #region CourseHierarchy
        public int AddCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            if (!RepositoryWrapper.MasterRepository.DoesCourseHieararchyExist(input))
            {
                return RepositoryWrapper.MasterRepository.AddCourseHierarchy(input);
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            if (RepositoryWrapper.MasterRepository.DoesCourseHieararchyIdExist(input))
            {
                if (!RepositoryWrapper.MasterRepository.DoesCourseHieararchyExistUpdate(input))
                {
                    return RepositoryWrapper.MasterRepository.UpdateCourseHierarchy(input);
                }
                else
                {
                    return CommonConstants.DuplicateRecord;
                }
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }

        public List<CourseHiearchyModel> GetCourseHierarchy(SearchRequestModel<CourseHiearchyModel> input)
        {
            return RepositoryWrapper.MasterRepository.GetCourseHierarchy(input);
        }

        public int MakeInActiveCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            if (RepositoryWrapper.MasterRepository.DoesCourseHieararchyIdExist(input))
            {
                return RepositoryWrapper.MasterRepository.MakeInActiveCourseHierarchy(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion

        #region CustomerBranch
        public int AddCustomerBranch(RequestModel<CustomerBranchModel> input)
        {
            if (!RepositoryWrapper.CustomerBranchRepository.DoesCustomerBranchExist(input))
            {
                return RepositoryWrapper.CustomerBranchRepository.AddCustomerBranch(input);
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateCustomerBranch(RequestModel<CustomerBranchModel> input)
        {
            if (RepositoryWrapper.CustomerBranchRepository.DoesCustomerBranchIdExist(input))
            {
                if (!RepositoryWrapper.CustomerBranchRepository.DoesCustomerBranchExistUpdate(input))
                {
                    return RepositoryWrapper.CustomerBranchRepository.UpdateCustomerBranch(input);
                }
                else
                {
                    return CommonConstants.DuplicateRecord;
                }
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }

        public List<CustomerBranchModel> GetCustomerBranches(SearchRequestModel<CustomerBranchModel> input)
        {
            return RepositoryWrapper.CustomerBranchRepository.GetCustomerBranches(input);
        }

        public int MakeInActiveCustomerBranch(RequestModel<CustomerBranchModel> input)
        {
            if (RepositoryWrapper.CustomerBranchRepository.DoesCustomerBranchIdExist(input))
            {
                return RepositoryWrapper.CustomerBranchRepository.MakeInActiveCustomerBranch(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion

        #region User Role
        public int AddUserRole(RequestModel<UserRoleModel> input)
        {
            if (!RepositoryWrapper.UserRoleRepository.DoesUserRoleExist(input))
            {
                return RepositoryWrapper.UserRoleRepository.AddUserRole(input);
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateUserRole(RequestModel<UserRoleModel> input)
        {
            if (RepositoryWrapper.UserRoleRepository.DoesUserRoleIdExist(input))
            {
                if (!RepositoryWrapper.UserRoleRepository.DoesUserRoleExistUpdate(input))
                {
                    return RepositoryWrapper.UserRoleRepository.UpdateUserRole(input);
                }
                else
                {
                    return CommonConstants.DuplicateRecord;
                }
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }

        public List<UserRoleModel> GetUserRoles(SearchRequestModel<UserRoleModel> input)
        {
            return RepositoryWrapper.UserRoleRepository.GetUserRoles(input);
        }

        public int MakeInActiveUserRole(RequestModel<UserRoleModel> input)
        {
            if (RepositoryWrapper.UserRoleRepository.DoesUserRoleIdExist(input))
            {
                return RepositoryWrapper.UserRoleRepository.MakeInActiveUserRole(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion

        #region Academic year
        public int AddAcademicYear(RequestModel<AcademicYearModel> input)
        {
            if (!RepositoryWrapper.AcademicYearRepository.DoesAcademicYearExist(input))
            {
                return RepositoryWrapper.AcademicYearRepository.AddAcademicYear(input);
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateAcademicYear(RequestModel<AcademicYearModel> input)
        {
            if (RepositoryWrapper.AcademicYearRepository.DoesAcademicYearIdExist(input))
            {
                if (!RepositoryWrapper.AcademicYearRepository.DoesAcademicYearExistUpdate(input))
                {
                    return RepositoryWrapper.AcademicYearRepository.UpdateAcademicYear(input);
                }
                else
                {
                    return CommonConstants.DuplicateRecord;
                }
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }

        public List<AcademicYearModel> GetAcademicYears(SearchRequestModel<AcademicYearModel> input)
        {
            return RepositoryWrapper.AcademicYearRepository.GetAcademicYears(input);
        }

        public int MakeInActiveAcademicYear(RequestModel<AcademicYearModel> input)
        {
            if (RepositoryWrapper.AcademicYearRepository.DoesAcademicYearIdExist(input))
            {
                return RepositoryWrapper.AcademicYearRepository.MakeInActiveAcademicYear(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion

        #region Bank
        public int AddBank(RequestModel<BankModel> input)
        {
            if (!RepositoryWrapper.BankRepository.DoesBankExist(input))
            {
                return RepositoryWrapper.BankRepository.AddBank(input);
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateBank(RequestModel<BankModel> input)
        {
            if (RepositoryWrapper.BankRepository.DoesBankIdExist(input))
            {
                if (!RepositoryWrapper.BankRepository.DoesBankExistUpdate(input))
                {
                    return RepositoryWrapper.BankRepository.UpdateBank(input);
                }
                else
                {
                    return CommonConstants.DuplicateRecord;
                }
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }

        public List<BankModel> GetBankList(SearchRequestModel<BankModel> input)
        {
            return RepositoryWrapper.BankRepository.GetBankList(input);
        }

        public int MakeInActiveBank(RequestModel<BankModel> input)
        {
            if (RepositoryWrapper.BankRepository.DoesBankIdExist(input))
            {
                return RepositoryWrapper.BankRepository.MakeInActiveBank(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion

        #region Education Institute
        public int AddEducationInstitute(RequestModel<EducationInstituteModel> input)
        {
            if (!RepositoryWrapper.EducationInstituteRepository.DoesEducationInstituteExist(input))
            {
                return RepositoryWrapper.EducationInstituteRepository.AddEducationInstitute(input);
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateEducationInstitute(RequestModel<EducationInstituteModel> input)
        {
            if (RepositoryWrapper.EducationInstituteRepository.DoesEducationInstituteIdExist(input))
            {
                if (!RepositoryWrapper.EducationInstituteRepository.DoesEducationInstituteExistUpdate(input))
                {
                    return RepositoryWrapper.EducationInstituteRepository.UpdateEducationInstitute(input);
                }
                else
                {
                    return CommonConstants.DuplicateRecord;
                }
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }

        public List<EducationInstituteModel> GetEducationInstituteList(SearchRequestModel<EducationInstituteModel> input)
        {
            return RepositoryWrapper.EducationInstituteRepository.GetEducationInstituteList(input);
        }

        public int MakeInActiveEducationInstitute(RequestModel<EducationInstituteModel> input)
        {
            if (RepositoryWrapper.EducationInstituteRepository.DoesEducationInstituteIdExist(input))
            {
                return RepositoryWrapper.EducationInstituteRepository.MakeInActiveEducationInstitute(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion

        #region CustomerCourse
        public int AddCustomerCourse(RequestModel<CustomerCourseModel> input)
        {
            if (!RepositoryWrapper.CustomerCourseRepository.DoesCustomerCourseExist(input))
            {
                return RepositoryWrapper.CustomerCourseRepository.AddCustomerCourse(input);
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateCustomerCourse(RequestModel<CustomerCourseModel> input)
        {
            if (RepositoryWrapper.CustomerCourseRepository.DoesCustomerCourseIdExist(input))
            {
                if (!RepositoryWrapper.CustomerCourseRepository.DoesCustomerCourseExistUpdate(input))
                {
                    return RepositoryWrapper.CustomerCourseRepository.UpdateCustomerCourse(input);
                }
                else
                {
                    return CommonConstants.DuplicateRecord;
                }
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }

        public List<CustomerCourseModel> GetCustomerCourseList(SearchRequestModel<CustomerCourseModel> input)
        {
            return RepositoryWrapper.CustomerCourseRepository.GetCustomerCourseList(input);
        }

        public CustomerCourseModel GetCustomerCourseInfo(RequestModel<ResultInputIdModel> input)
        {
            return RepositoryWrapper.CustomerCourseRepository.GetCustomerCourseInfo(input);
        }


        public int MakeInActiveCustomerCourse(RequestModel<CustomerCourseModel> input)
        {
            if (RepositoryWrapper.CustomerCourseRepository.DoesCustomerCourseIdExist(input))
            {
                return RepositoryWrapper.CustomerCourseRepository.MakeInActiveCustomerCourse(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion

        #region CustomerCourse Subject
        public int AddCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input)
        {
            if (!RepositoryWrapper.CustomerCourseSubjectRepository.DoesCustomerCourseSubjectExist(input))
            {
                return RepositoryWrapper.CustomerCourseSubjectRepository.AddCustomerCourseSubject(input);
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input)
        {
            if (RepositoryWrapper.CustomerCourseSubjectRepository.DoesCustomerCourseSubjectIdExist(input))
            {
                if (!RepositoryWrapper.CustomerCourseSubjectRepository.DoesCustomerCourseSubjectExistUpdate(input))
                {
                    return RepositoryWrapper.CustomerCourseSubjectRepository.UpdateCustomerCourseSubject(input);
                }
                else
                {
                    return CommonConstants.DuplicateRecord;
                }
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }

        public List<CustomerCourseSubjectModel> GetCustomerCourseSubjectList(SearchRequestModel<CustomerCourseSubjectModel> input)
        {
            return RepositoryWrapper.CustomerCourseSubjectRepository.GetCustomerCourseSubjectList(input);
        }

        public int MakeInActiveCustomerCourseSubject(RequestModel<CustomerCourseSubjectModel> input)
        {
            if (RepositoryWrapper.CustomerCourseSubjectRepository.DoesCustomerCourseSubjectIdExist(input))
            {
                return RepositoryWrapper.CustomerCourseSubjectRepository.MakeInActiveCustomerCourseSubject(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion
    }

    public class BatchBusiness : BusinessBase, IBatchBusiness
    {
        public int AddBatch(RequestModel<BatchMasterModel> input)
        {
            if (!RepositoryWrapper.BatchRepository.DoesBatchExist(input))
            {
                return RepositoryWrapper.BatchRepository.AddBatch(input);
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }

        public List<BatchMasterModel> GetBarchBatchList(SearchRequestModel<BatchMasterModel> input)
        {
            return RepositoryWrapper.BatchRepository.GetBranchBatchList(input);
        }

        public int MakeInActiveBatch(RequestModel<BatchMasterModel> input)
        {
            throw new NotImplementedException();
        }

        public int UpdateBatch(RequestModel<BatchMasterModel> input)
        {
            throw new NotImplementedException();
        }
    }
}

