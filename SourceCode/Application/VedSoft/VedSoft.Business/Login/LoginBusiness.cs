using System;
using System.Collections.Generic;
using System.Text;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Login;
using VedSoft.Model.User;
using VedSoft.Utility.Constants;
using System.Linq;
namespace VedSoft.Business.Login
{
    public class LoginBusiness : BusinessBase, ILoginBusiness
    {
        public AuthenticationModel Authenticate(RequestModel<LoginRequestModel> input)
        {
            AuthenticationModel authenticateModel = new AuthenticationModel();
            int loginStatus = (int)LoginStatusConstants.InvalidCredentials;
            UserModel user= RepositoryWrapper.UserRepository.Authenticate(input.RequestParameter);
            UserLoginDetails userLoginDetails = new UserLoginDetails();
            
            if(user!=null)
            {
                if(user.Password==input.RequestParameter.Password)
                {
                    #region set LoginStatus
                    if (DateTime.Today >= user.PasswordExpiryDate.GetValueOrDefault())
                    {
                        loginStatus = (int)LoginStatusConstants.PasswordExpired;
                    }
                    else if (user.Active.GetValueOrDefault() != (int)CommonConstants.ActiveStatus)
                    {
                        loginStatus = (int)LoginStatusConstants.InActive;
                    }
                    else if (user.TemproryPassword.GetValueOrDefault() == (int)CommonConstants.ActiveStatus)
                    {
                        loginStatus = (int)LoginStatusConstants.TemproryPassword;
                    }
                    else
                    {
                        loginStatus = (int)LoginStatusConstants.Success;
                    }
                    #endregion

                    userLoginDetails = new UserLoginDetails
                    {
                        CreatedBy = user.Id,
                        CreatedDate = DateTime.Now,
                        CustomerId = input.CustomerId.Value,
                        LoginDate = DateTime.Now,
                        LoginSourceDetails = input.RequestParameter.LoginSourceInfo,
                        Status = loginStatus,
                        UserId = user.Id
                    };
                    //Save in database
                    RepositoryWrapper.UserLoginDetailsRepository.SaveUserLoginDetails(userLoginDetails);

                    //Successfully logged in...make lock attempt to 0..if >0 then only
                    if (user.LockAttempts.GetValueOrDefault() > 0)
                    {
                        user.LockAttempts = 0;
                        this.RepositoryWrapper.UserDetailsRepository.UpdateUserLoginLockAttempt(user);
                    }
                }
                else 
                {
                    if (user.LockAttempts.GetValueOrDefault() > CommonConstants.UserLoginAttemptsCountExceeded)
                    {
                        loginStatus = (int)LoginStatusConstants.LoginAttemptExceeded;
                    }
                    else
                    {
                        user.LockAttempts = user.LockAttempts.GetValueOrDefault()+1;
                        this.RepositoryWrapper.UserDetailsRepository.UpdateUserLoginLockAttempt(user);
                    }
                }
            }
            else
            {
                loginStatus = (int)LoginStatusConstants.InvalidCredentials;
            }

            authenticateModel.UserDetails = user;
            authenticateModel.LoginResponseDetails = new LoginResponseModel
            {
                LoginStatus = loginStatus,
                LoginDetailsId = userLoginDetails.Id
            };

            return authenticateModel;
        }

        public string GetRefreshTokenByUserLoginDetailsId(LoginResponseModel input)
        {
            return RepositoryWrapper.UserLoginDetailsRepository.FindByCondition(x => x.Id == input.LoginDetailsId)
                                .Select(x=>x.LoginRefreshToken)
                                .FirstOrDefault();
        }

        public bool UpdateLoginToken(LoginResponseModel input)
        {
            return RepositoryWrapper.UserLoginDetailsRepository.UpdateUserLoginDetails(input);
        }

        public int UpdatePassword(RequestModel<SetPasswordRequestModel> input)
        {
            //  int loginStatus = (int)LoginStatusConstants.InvalidCredentials;
            UserModel user = RepositoryWrapper.UserRepository.GetUserIdByLoginId(input.RequestParameter.UserId);

            int status;
            if (user != null && user.Password == input.RequestParameter.OldPassword)
            {
                var result = RepositoryWrapper.UserRepository.UpdatePassword(input.RequestParameter);
                status = result ? 1 : 0;
                if (result)
                {
                    //Successfully logged in...make lock attempt to 0
                    user.LockAttempts = 0;
                    this.RepositoryWrapper.UserDetailsRepository.UpdateUserLoginLockAttempt(user);
                }
            }
            else
            {
                status = 2;
            }

            return status;
            //return RepositoryWrapper.UserLoginDetailsRepository.UpdateUserLoginDetails(input);
        }

        public UserModel GetUserDetailsByLoginDetailsId(RequestModel<LoginResponseModel> input)
        {
            UserModel user = RepositoryWrapper.UserLoginDetailsRepository.GetUserDetailsByLoginDetailsId(input.RequestParameter);
            return user;
        }


    }
}
