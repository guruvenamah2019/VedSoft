using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Base;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Login;
using VedSoft.Model.User;

namespace VedSoft.Data.Contracts.User
{
    public interface IUserRepository : IRepositoryBase<UserMasterDB>
    {
        UserModel Authenticate(RequestModel<LoginRequestModel> loginRequestModel);
        UserModel GetUserIdByLoginId(int UserId);
        bool UpdatePassword(SetPasswordRequestModel input);

        int AddUser(RequestModel<UserModel> input);
        int UpdateUser(RequestModel<UserModel> input);
        List<UserModel> GetUserList(SearchRequestModel<UserModel> input);
        int MakeInActiveUser(RequestModel<UserModel> input);
        bool DoesUserExist(RequestModel<UserModel> input);
        bool DoesUserExistUpdate(RequestModel<UserModel> input);
        bool DoesUserIdExist(RequestModel<UserModel> input);
    }

    public interface IStudentRepository : IRepositoryBase<StudentDB>
    {
        int AddStudent(RequestModel<StudentAdmissionModel> input);
        int UpdateStudent(RequestModel<StudentModel_Old> input);
        List<StudentViewModel> GetStudentList(SearchRequestModel<StudentViewModel> input);
        int MakeInActiveStudent(RequestModel<StudentModel_Old> input);
        bool DoesStudentExist(RequestModel<StudentModel_Old> input);
        //bool DoesStudentExistUpdate(RequestModel<StudentModel> input);
        bool DoesStudentIdExist(RequestModel<StudentModel_Old> input);
    }

    public interface IStudentAdmisionDetailsRepository : IRepositoryBase<StudentAdmissionDetailsDB>
    {
        int AddStudentAdmission(RequestModel<StudentAdmissionModel_Old> input);
        int UpdateStudentAdmission(RequestModel<StudentAdmissionModel_Old> input);
        List<StudentAdmissionModel_Old> GetStudentAdmissionList(SearchRequestModel<StudentAdmissionModel_Old> input);
        int MakeInActiveStudentAdmission(RequestModel<StudentAdmissionModel_Old> input);
        bool DoesStudentAdmissionExist(RequestModel<StudentAdmissionModel_Old> input);
        //bool DoesStudentExistUpdate(RequestModel<StudentModel> input);
        bool DoesStudentAdmissionIdExist(RequestModel<StudentAdmissionModel_Old> input);
    }

    public interface IStudentCourseRepository : IRepositoryBase<StudentCoursesDB>
    {
        int AddStudentCourse(RequestModel<StudentCourseModel> input);
        int UpdateStudentCourse(RequestModel<StudentCourseModel> input);
        List<StudentCourseModel> GetStudentCourseList(SearchRequestModel<StudentCourseModel> input);
        int MakeInActiveStudentCourse(RequestModel<StudentCourseModel> input);
        bool DoesStudentCourseExist(RequestModel<StudentCourseModel> input);
        //bool DoesStudentExistUpdate(RequestModel<StudentModel> input);
        bool DoesStudentCourseIdExist(RequestModel<StudentCourseModel> input);
    }
}
