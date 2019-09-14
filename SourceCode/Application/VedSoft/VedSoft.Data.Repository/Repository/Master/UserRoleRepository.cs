using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VedSoft.Data.Contracts.Model;
using VedSoft.Data.Contracts.Repository.Master;
using VedSoft.Model.Common;
using VedSoft.Model.User;
using VedSoft.Utility.Constants;
using VedSoft.Utility;

namespace VedSoft.Data.Repository.Repository.Master
{
    public class UserRoleRepository : RepositoryBase<UserRoleDB>, IUserRoleRepository
    {
        public UserRoleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public int AddUserRole(RequestModel<UserRoleModel> input)
        {
            //Make db object
            UserRoleDB userRoleDB = new UserRoleDB
            {
                CreatedBy = input.RequestParameter.UserId,
                CreatedDate = DateTime.Now,
                Active = CommonConstants.ActiveStatus,
                CustomerId = input.CustomerId.GetValueOrDefault(),
                Name = input.RequestParameter.Name,
                Description = input.RequestParameter.Description
            };

            //Save in database
            RepositoryContext.Add(userRoleDB);
            this.RepositoryContext.SaveChanges();

            input.RequestParameter.Id = userRoleDB.Id;

            return userRoleDB.Id;
        }

        public int UpdateUserRole(RequestModel<UserRoleModel> input)
        {
            var userRole = this.RepositoryContext.UserRole
                            .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                            .FirstOrDefault();
            if (userRole != null)
            {
                userRole.Name = input.RequestParameter.Name;
                userRole.Description = input.RequestParameter.Description;
                userRole.ModifiedBy = input.RequestParameter.UserId;
                userRole.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(userRole);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public List<UserRoleModel> GetUserRoles(SearchRequestModel<UserRoleModel> input)
        {
            List<UserRoleModel> userRoleModelList = new List<UserRoleModel>();
            var userRoleList = this.RepositoryContext.UserRole
                                      .Where(x => x.CustomerId == input.CustomerId
                                      && x.Active == CommonConstants.ActiveStatus)
                                      .Page(input.PageSize, input.PageNumber);


            foreach (var userRole in userRoleList.ToList())
            {
                userRoleModelList.Add(new UserRoleModel
                {
                    Id = userRole.Id,
                    Name = userRole.Name,
                    Description=userRole.Description
                });
            }

            return userRoleModelList;
        }

        public int MakeInActiveUserRole(RequestModel<UserRoleModel> input)
        {
            var userRole = this.RepositoryContext.UserRole
                                    .Where(x => x.Id == input.RequestParameter.Id && x.Active == CommonConstants.ActiveStatus)
                                    .FirstOrDefault();
            if (userRole != null)
            {
                userRole.Active = CommonConstants.InActiveStatus;
                userRole.ModifiedBy = input.RequestParameter.UserId;
                userRole.ModifiedDate = DateTime.Now;
            }

            //Save in database
            this.RepositoryContext.Update(userRole);
            this.RepositoryContext.SaveChanges();

            return CommonConstants.Success;
        }

        public bool DoesUserRoleExist(RequestModel<UserRoleModel> input)
        {
            return this.RepositoryContext.UserRole
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Active == CommonConstants.ActiveStatus
                                  && x.Name.ToLower() == input.RequestParameter.Name.ToLower()
                                   )
                                  .Count() > 0;
        }

        public bool DoesUserRoleExistUpdate(RequestModel<UserRoleModel> input)
        {
            return this.RepositoryContext.UserRole
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && (x.Name.ToLower() == input.RequestParameter.Name.ToLower())
                                  && x.Active == CommonConstants.ActiveStatus
                                  && x.Id != input.RequestParameter.Id)
                                  .Count() > 0;
        }

        public bool DoesUserRoleIdExist(RequestModel<UserRoleModel> input)
        {
            return this.RepositoryContext.UserRole
                                  .Where(x => x.CustomerId == input.CustomerId
                                  && x.Id == input.RequestParameter.Id
                                   && x.Active == CommonConstants.ActiveStatus
                                  )
                                  .Count() > 0;
        }
    }
}
