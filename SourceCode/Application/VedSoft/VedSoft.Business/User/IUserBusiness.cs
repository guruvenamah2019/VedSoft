using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Model.User;

namespace VedSoft.Business.Master
{
   public interface IUserBusiness:IBusinessBase
   {
        #region User
        int AddUser(RequestModel<UserModel> input);
        int UpdateUser(RequestModel<UserModel> input);
        List<UserModel> GetUserList(SearchRequestModel<UserModel> input);
        int MakeInActiveUser(RequestModel<UserModel> input);
        #endregion

        #region Student
        int AddStudent(RequestModel<StudentModel> input);
        int UpdateStudent(RequestModel<StudentModel> input);
        List<StudentModel> GetStudentList(SearchRequestModel<StudentModel> input);
        int MakeInActiveStudent(RequestModel<StudentModel> input);
        #endregion

        #region Student Admission
        int AddStudentAdmission(RequestModel<StudentAdmissionModel> input);
        int UpdateStudentAdmission(RequestModel<StudentAdmissionModel> input);
        List<StudentAdmissionModel> GetStudentAdmissionList(SearchRequestModel<StudentAdmissionModel> input);
        int MakeInActiveStudentAdmission(RequestModel<StudentAdmissionModel> input);
        #endregion

        #region Student Course
        int AddStudentCourse(RequestModel<StudentCourseModel> input);
        int UpdateStudentCourse(RequestModel<StudentCourseModel> input);
        List<StudentCourseModel> GetStudentCourseList(SearchRequestModel<StudentCourseModel> input);
        int MakeInActiveStudentCourse(RequestModel<StudentCourseModel> input);
        #endregion
    }
}
