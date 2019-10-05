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
    public class UserBusiness : BusinessBase, IUserBusiness
    {
        #region User
        public int AddUser(RequestModel<UserModel> input)
        {
            if (!RepositoryWrapper.UserRepository.DoesUserExist(input))
            {
                int userId= RepositoryWrapper.UserRepository.AddUser(input);
                input.RequestParameter.Id = userId;
                RepositoryWrapper.UserDetailsRepository.AddUserDetails(input);
                return userId;
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateUser(RequestModel<UserModel> input)
        {
            if (RepositoryWrapper.UserRepository.DoesUserIdExist(input))
            {
                if (!RepositoryWrapper.UserRepository.DoesUserExistUpdate(input))
                {
                    int returnValue=RepositoryWrapper.UserRepository.UpdateUser(input);
                    RepositoryWrapper.UserDetailsRepository.UpdateUserDetails(input);
                    return returnValue;

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

        public List<UserModel> GetUserList(SearchRequestModel<UserModel> input)
        {
            return RepositoryWrapper.UserRepository.GetUserList(input);
        }

        public int MakeInActiveUser(RequestModel<UserModel> input)
        {
            if (RepositoryWrapper.UserRepository.DoesUserIdExist(input))
            {
                return RepositoryWrapper.UserRepository.MakeInActiveUser(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion

        #region Student
        public int AddStudent(RequestModel<StudentModel> input)
        {
            if (!RepositoryWrapper.StudentRepository.DoesStudentExist(input))
            {
                return RepositoryWrapper.StudentRepository.AddStudent(input); ;
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateStudent(RequestModel<StudentModel> input)
        {
            if (RepositoryWrapper.StudentRepository.DoesStudentIdExist(input))
            {
                return RepositoryWrapper.StudentRepository.UpdateStudent(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }

        public List<StudentModel> GetStudentList(SearchRequestModel<StudentModel> input)
        {
            return RepositoryWrapper.StudentRepository.GetStudentList(input);
        }

        public int MakeInActiveStudent(RequestModel<StudentModel> input)
        {
            if (RepositoryWrapper.StudentRepository.DoesStudentIdExist(input))
            {
                return RepositoryWrapper.StudentRepository.MakeInActiveStudent(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion

        #region Student Admission
        public int AddStudentAdmission(RequestModel<StudentAdmissionModel> input)
        {
            if (!RepositoryWrapper.StudentAdmisionDetailsRepository.DoesStudentAdmissionExist(input))
            {
                return RepositoryWrapper.StudentAdmisionDetailsRepository.AddStudentAdmission(input); ;
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateStudentAdmission(RequestModel<StudentAdmissionModel> input)
        {
            if (RepositoryWrapper.StudentAdmisionDetailsRepository.DoesStudentAdmissionIdExist(input))
            {
                return RepositoryWrapper.StudentAdmisionDetailsRepository.UpdateStudentAdmission(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }

        public List<StudentAdmissionModel> GetStudentAdmissionList(SearchRequestModel<StudentAdmissionModel> input)
        {
            return RepositoryWrapper.StudentAdmisionDetailsRepository.GetStudentAdmissionList(input);
        }

        public int MakeInActiveStudentAdmission(RequestModel<StudentAdmissionModel> input)
        {
            if (RepositoryWrapper.StudentAdmisionDetailsRepository.DoesStudentAdmissionIdExist(input))
            {
                return RepositoryWrapper.StudentAdmisionDetailsRepository.MakeInActiveStudentAdmission(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion

        #region Student Admission
        public int AddStudentCourse(RequestModel<StudentCourseModel> input)
        {
            if (!RepositoryWrapper.StudentCourseRepository.DoesStudentCourseExist(input))
            {
                return RepositoryWrapper.StudentCourseRepository.AddStudentCourse(input); ;
            }
            else
            {
                return CommonConstants.DuplicateRecord;
            }
        }
        public int UpdateStudentCourse(RequestModel<StudentCourseModel> input)
        {
            if (RepositoryWrapper.StudentCourseRepository.DoesStudentCourseIdExist(input))
            {
                return RepositoryWrapper.StudentCourseRepository.UpdateStudentCourse(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }

        public List<StudentCourseModel> GetStudentCourseList(SearchRequestModel<StudentCourseModel> input)
        {
            return RepositoryWrapper.StudentCourseRepository.GetStudentCourseList(input);
        }

        public int MakeInActiveStudentCourse(RequestModel<StudentCourseModel> input)
        {
            if (RepositoryWrapper.StudentCourseRepository.DoesStudentCourseIdExist(input))
            {
                return RepositoryWrapper.StudentCourseRepository.MakeInActiveStudentCourse(input);
            }
            else
            {
                return CommonConstants.InvalidRecord;
            }
        }
        #endregion
    }
}

