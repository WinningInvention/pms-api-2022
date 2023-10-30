using DomainLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using Serviceslayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Serviceslayer.Logics
{
    public class DatabaseCallService : IDatabaseCallService
    {
        private readonly IConfiguration _config;

        public DatabaseCallService(IConfiguration config)
        {
            _config = config;
        }
        public bool InsertDatawithStoredProcedure(string storedprocedureName, string storedprocedureparametername, string jsonvalue)
        {
            SqlConnection connectionstring = new SqlConnection(_config.GetConnectionString("myconn"));
            try
            {
                SqlCommand cmd = new SqlCommand(storedprocedureName, connectionstring);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(storedprocedureparametername, jsonvalue);
                //cmd.Parameters["@insertFlag"].Direction = ParameterDirection.Output;
                connectionstring.Open();
                var operationFlag = cmd.ExecuteNonQuery();
                return operationFlag == 0 ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally{
                connectionstring.Close();
            }      
        }

        public bool ExecuteCmdNonQuery(string CommandName, params object[] optionalParams)
        {
            DataSet ds = new DataSet();
            var rowsAffected = 0;
            using (SqlConnection sqlConn = new SqlConnection(_config.GetConnectionString("myconn")))
            {
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = CommandName;
                sqlCmd.Connection = sqlConn;
                ProcessParameter(ref sqlCmd, optionalParams);
                rowsAffected =  sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }
            return rowsAffected > 0 ? true : false;
        }

        static SqlParameterCollection ProcessParameter(ref SqlCommand cmd, params object[] optionalParams)
        {

            if (optionalParams != null && optionalParams.Length > 0)
            {
                for (int idx = 0; idx < optionalParams.Length - 1; idx = idx + 2)
                {
                    SqlParameter aParam = cmd.CreateParameter();
                    aParam.ParameterName = optionalParams[idx].ToString();
                    aParam.Value = optionalParams[idx + 1];
                    aParam.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(aParam);
                }
            }
            return cmd.Parameters;
        }
    }
}
