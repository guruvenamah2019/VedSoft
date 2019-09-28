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
        #region CustomerCourse
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
    }
}

