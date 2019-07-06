using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Security;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VedSoft.Logger;
using VedSoft.Utility.SerializeObjects;
using VedSoft.Model;
using VedSoft.Model.Common;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;
using log4net;


namespace VedSoft.API.Controllers
{

    public class ApiBaseController : Controller
    {
        public IVedSoftLogger ILogger { get; set; }
        private string faultExceptionMessageSplitter = "@@@@@";//Fault message would concatenated by 
        private int faultExceptionMessageArraylength = 5;////Fault message array length(ExceptionType,Exception,InnerExcepton,StackTrace,DBEntityValidationException)
        public string CurrentUniqueID { get; set; }
        public object CurrentRequestParameter { get; set; }
        public object SerializeObject { get; private set; }
        public ILog Log4NetCore { get; private set; }

        public ApiBaseController(IVedSoftLogger _iLogger)
        {
            ILogger = _iLogger;
            
            Log4NetCore = Program._log;
            ILogger.Log4NetCore = Log4NetCore;
        }

        /// <summary>
        /// Common execution place
        /// </summary>
        /// <param name="request"></param>
        /// <param name="codeToExecute"></param>
        /// <returns></returns>
        protected object GetResponse(HttpRequest request, Func<object> codeToExecute)
        {
            Stopwatch swTimer = new Stopwatch();
            swTimer.Start();
            object response = null;
            bool isExceptionOccured = false;
            LoggerModel loggerModel = new LoggerModel();
            RequestDetails requestDetails = new RequestDetails();
            HttpStatusCode httpStatusCodeOnError = HttpStatusCode.InternalServerError;
            try
            {
                //Contains all the details for logging
                loggerModel.UniqueKey = CurrentUniqueID;
                requestDetails = GetRequestDetails(request);
                loggerModel.RequestDetails = requestDetails;
                if (CurrentRequestParameter != null)
                    loggerModel.RequestParameter = SerializeJsonObject.GetJsonValue(CurrentRequestParameter);
                //Execute the code
                response = codeToExecute.Invoke();
                loggerModel.Response = Convert.ToString(response);
            }
            catch (SecurityException ex)
            {
                loggerModel.ErrorDetails = GetExceptionDetails(ex);
                httpStatusCodeOnError = HttpStatusCode.Unauthorized;
                isExceptionOccured = true;
            }
             
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {

                        string getError = reader.ReadToEnd();
                        //loggerModel.ErrorDetails = GetFaultExceptionDetails(ex);
                        if (loggerModel != null && loggerModel.ErrorDetails != null)
                        {
                            loggerModel.ErrorDetails.Exception = string.Format("-Web Exception-{0}", getError);
                        }
                        isExceptionOccured = true;
                    }
                }
            }
            catch (Exception ex)
            {
                loggerModel.ErrorDetails = GetExceptionDetails(ex);
                isExceptionOccured = true;
            }

            //timer details
            swTimer.Stop();
            loggerModel.TimeTakenMS = swTimer.ElapsedMilliseconds;

            string logDescription = SerializeJsonObject.GetJsonValue(loggerModel);
            //Log the content
            if (isExceptionOccured)
            {
           this.ILogger.LogError(logDescription);
            }
            else
            {
                this.ILogger.LogInfo(logDescription);
            }

            return response;
        }



        #region helper methods
        private FaultExceptionDetails GetExceptionDetails(Exception ex)
        {
            FaultExceptionDetails exceptionDetails = new FaultExceptionDetails();
            try
            {
                if (ex != null)
                {
                    exceptionDetails.ExceptionType = ex.GetType().ToString();
                    exceptionDetails.Exception = ex.Message;
                    if (ex.InnerException != null)
                    {
                        exceptionDetails.InnerException = ex.InnerException.Message;
                    }
                    exceptionDetails.StackTrace = ex.StackTrace;
                }
            }
            catch
            {
                //Should not happen
                exceptionDetails.Exception = "Error in  APIControllerBase GetExceptionDetails";
            }
            return exceptionDetails;
        }
        private RequestDetails GetRequestDetails(HttpRequest httpRequest)
        {
            RequestDetails requestDetails = new RequestDetails();

            try
            {
                if (httpRequest != null)
                {
                    //if (httpRequest.ContentLength>0)
                        //requestDetails.ContentHeader = httpRequest.ContentType.heHeaders.ToString();
                    if (httpRequest.Headers != null)
                        requestDetails.Header = httpRequest.Headers.ToString();
                    if (httpRequest.Method != null)
                        requestDetails.Method = httpRequest.Method.ToString();
                    if (httpRequest.Host != null)
                        requestDetails.FromURL = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(httpRequest);
                }
            }
            catch
            {
                requestDetails.ContentHeader = "Error in GetRequestDetails";
            }

            return requestDetails;
        }
      
        private FaultExceptionDetails GetFaultExceptionDetails(Exception ex)
        {
            FaultExceptionDetails exceptionDetails = new FaultExceptionDetails();
            try
            {
                string[] faultErrorDetailsArr = System.Text.RegularExpressions.Regex.Split(ex.Message, faultExceptionMessageSplitter);
                if (faultErrorDetailsArr.Length == faultExceptionMessageArraylength)
                {
                    exceptionDetails.ExceptionType = faultErrorDetailsArr[0];
                    exceptionDetails.Exception = faultErrorDetailsArr[1];
                    exceptionDetails.InnerException = faultErrorDetailsArr[2];
                    exceptionDetails.StackTrace = faultErrorDetailsArr[3];
                    exceptionDetails.DbEntityValidationException = faultErrorDetailsArr[4];
                }
            }
            catch
            {
                //Should not happen
                exceptionDetails.Exception = "Error in APIControllerBase GetFaultExceptionDetails";
            }

            return exceptionDetails;
        }
        #endregion
    }
}
