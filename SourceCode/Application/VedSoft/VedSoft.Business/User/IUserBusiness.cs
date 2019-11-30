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
        int AddStudent(RequestModel<StudentAdmissionModel> input);
        int UpdateStudent(RequestModel<StudentModel_Old> input);
        List<StudentViewModel> GetStudentList(SearchRequestModel<StudentViewModel> input);
        int MakeInActiveStudent(RequestModel<StudentModel_Old> input);
        #endregion

        #region Student Admission
        int AddStudentAdmission(RequestModel<StudentAdmissionModel_Old> input);
        int UpdateStudentAdmission(RequestModel<StudentAdmissionModel_Old> input);
        List<StudentAdmissionModel_Old> GetStudentAdmissionList(SearchRequestModel<StudentAdmissionModel_Old> input);
        int MakeInActiveStudentAdmission(RequestModel<StudentAdmissionModel_Old> input);
        #endregion

        #region Student Course
        int AddStudentCourse(RequestModel<StudentCourseModel> input);
        int UpdateStudentCourse(RequestModel<StudentCourseModel> input);
        List<StudentCourseModel> GetStudentCourseList(SearchRequestModel<StudentCourseModel> input);
        int MakeInActiveStudentCourse(RequestModel<StudentCourseModel> input);
        #endregion
    }
}
