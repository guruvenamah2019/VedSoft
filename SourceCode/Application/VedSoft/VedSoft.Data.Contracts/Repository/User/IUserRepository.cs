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
        int AddStudent(RequestModel<StudentModel> input);
        int UpdateStudent(RequestModel<StudentModel> input);
        List<StudentModel> GetStudentList(SearchRequestModel<StudentModel> input);
        int MakeInActiveStudent(RequestModel<StudentModel> input);
        bool DoesStudentExist(RequestModel<StudentModel> input);
        //bool DoesStudentExistUpdate(RequestModel<StudentModel> input);
        bool DoesStudentIdExist(RequestModel<StudentModel> input);
    }

    public interface IStudentAdmisionDetailsRepository : IRepositoryBase<StudentAdmissionDetailsDB>
    {
        int AddStudentAdmission(RequestModel<StudentAdmissionModel> input);
        int UpdateStudentAdmission(RequestModel<StudentAdmissionModel> input);
        List<StudentAdmissionModel> GetStudentAdmissionList(SearchRequestModel<StudentAdmissionModel> input);
        int MakeInActiveStudentAdmission(RequestModel<StudentAdmissionModel> input);
        bool DoesStudentAdmissionExist(RequestModel<StudentAdmissionModel> input);
        //bool DoesStudentExistUpdate(RequestModel<StudentModel> input);
        bool DoesStudentAdmissionIdExist(RequestModel<StudentAdmissionModel> input);
    }
}
