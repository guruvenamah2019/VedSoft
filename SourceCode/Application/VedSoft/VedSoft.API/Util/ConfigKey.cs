using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace VedSoft.API.Util
{
    public class ConfigKey
    {
        //static IConfiguration _configuration;
        //public ConfigKey(IConfiguration config)
        //{
        //    _configuration = config;
        //}
        //////public static IConfiguration Config;
        public static string JWTSecurityKey { get; set; }
        public static int JWTAccessTokenDurationInSeconds { get; set; }
        public static string JWTTokenIssuer { get; set; }
        public static string JWTTokenAudience { get; set; }
        public static string MySqlConnectionString { get; set; }

        //public static string JWTSecurityKey = _configuration.GetSection("JWTSecurityKey").Value;
        //public static int JWTAccessTokenDurationInSeconds = Convert.ToInt32(_configuration.GetSection("JWTAccessTokenDurationInSeconds").Value);
        //public static string JWTTokenIssuer = _configuration.GetSection("JWTTokenIssuer").Value;
        //public static string JWTTokenAudience = _configuration.GetSection("JWTTokenAudience").Value;
    }

   
}
