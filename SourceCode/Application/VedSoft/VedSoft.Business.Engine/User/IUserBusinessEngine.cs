using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Business.Master;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Model.User;

namespace VedSoft.Business.Engine.Master
{
    public interface IUserBusinessEngine:IBusinessEngineBase
    {
        IUserBusiness UserBusiness { get; set; }

        #region User
        ResponseModel<ResultModel> AddUser(RequestModel<UserModel> input);
        ResponseModel<ResultModel> UpdateUser(RequestModel<UserModel> input);
        ResponseModel<List<UserModel>> GetUserList(SearchRequestModel<UserModel> input);
        ResponseModel<ResultModel> MakeInActiveUser(RequestModel<UserModel> input);
        #endregion

        #region Student
        ResponseModel<ResultModel> AddStudent(RequestModel<StudentModel> input);
        ResponseModel<ResultModel> UpdateStudent(RequestModel<StudentModel> input);
        ResponseModel<List<StudentModel>> GetStudentList(SearchRequestModel<StudentModel> input);
        ResponseModel<ResultModel> MakeInActiveStudent(RequestModel<StudentModel> input);
        #endregion
    }
}
