﻿using Newtonsoft.Json;
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

namespace VedSoft.Business.Master
{
    public class MasterBusiness : BusinessBase, IMasterBusiness
    {
        //To add a new customer
        public ResultModel AddCustomer(CustomerModel input)
        {
            //Make db object
            CustomerModelDB objCustomerModelDB = new CustomerModelDB {
                 Active=input.Active,
                 Address=input.Address,
                 Code=input.Code,
                 ContactNumber=input.ContactNumber,
                 CreatedBy=input.CreatedBy,
                 CreatedDate=input.CreatedDate,
                 Description=input.Description,
                 Name=input.Name,
                 OtherInfo=input.OtherInfo,
                 SubDomain=input.SubDomain
            };

            //Save in database
            RepositoryWrapper.CustomerRepository.Create(objCustomerModelDB);
            RepositoryWrapper.CustomerRepository.Save();

            return new ResultModel { PrimaryKey=input.CustomerId };
        }

        //To get the customer details by Id
        public CustomerModel GetCustomerDetailsById(CustomerModel input)
        {
            var customerDetails = RepositoryWrapper
                                    .CustomerRepository
                                    .FindByCondition(x => x.CustomerId == input.CustomerId)
                                    .FirstOrDefault();
            
            return new CustomerModel {
                Code =customerDetails.Code,
                Address =customerDetails.Address,
                Active =customerDetails.Active,
                ContactNumber =customerDetails.ContactNumber,
                CreatedBy=customerDetails.CreatedBy,
                CreatedDate =customerDetails.CreatedDate,
                CustomerId =customerDetails.CustomerId,
                Description =customerDetails.Description,
                Name=customerDetails.Name,
                OtherInfo =customerDetails.OtherInfo,
                SubDomain =customerDetails.SubDomain
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

        public int AddCourseHierarchy(RequestModel<CourseHiearchyModel> input)
        {
            if(!RepositoryWrapper.MasterRepository.DoesCourseHieararchyExist(input))
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
    }
}

