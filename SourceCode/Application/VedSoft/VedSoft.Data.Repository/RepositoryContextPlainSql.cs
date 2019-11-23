using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using VedSoft.Data.Contracts.Model;
using VedSoft.Model;
using VedSoft.Model.Common;
using VedSoft.Model.Master;
using VedSoft.Utility.Constants;

namespace VedSoft.Data.Repository
{
    public partial class RepositoryContext : DbContext
    {
        public IEnumerable<T> ExecuteSP<T>(DynamicParameters DynamicParametersList, string spName)
        {
            IEnumerable<T> result = null;

            using (var conn = new MySqlConnection(ConfigKeys.MySqlConnectionString))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    if (conn.State == ConnectionState.Open)
                    {
                        result = SqlMapper.Query<T>(conn, spName, param: DynamicParametersList, commandType: CommandType.StoredProcedure);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return result;
        }

        public IEnumerable<T> ExecuteSqlQuery<T>(string sqlQuery)
        {
            IEnumerable<T> result = null;

            using (var conn = new MySqlConnection(ConfigKeys.MySqlConnectionString))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    if (conn.State == ConnectionState.Open)
                    {
                        result = SqlMapper.Query<T>(conn, sqlQuery, commandType: CommandType.Text);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return result;
        }


    }
}
