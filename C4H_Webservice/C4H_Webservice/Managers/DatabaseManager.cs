using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace C4H_Webservice.Managers
{
    public static class DatabaseManager
    {

        public static string GetConnectionString()                                                                  
        {
            try
            {
                return @"Data Source=(local);Initial Catalog=C4HSQL;Integrated Security=True";
            }
            catch { return null; }
        }
        public static SqlConnection GetSQLConnection()                                                              
        {
            if (GetConnectionString() == null)
                return null;
            return new SqlConnection(GetConnectionString());
        }

        public static bool ExecuteNonQueryCommand(string command, SqlParameter[] parameters)                        
        {
            if (GetSQLConnection() == null)
                return false;

            bool successfulQuery = false;
            SqlCommand sqlCommand = new SqlCommand(command, GetSQLConnection());

            try
            {
                sqlCommand.Parameters.AddRange(parameters);
                sqlCommand.Connection.Open();
                successfulQuery = sqlCommand.ExecuteNonQuery() > 0;
                successfulQuery = true;
            }
            catch
            { }

            if (sqlCommand.Connection != null && sqlCommand.Connection.State == ConnectionState.Open)
                sqlCommand.Connection.Close();

            return successfulQuery;
        }
        public static int ExecuteScalarQueryCommand(string command, SqlParameter[] parameters)                      
        {
            if (GetSQLConnection() == null)
                return -1;

            int id = -1;
            SqlCommand sqlCommand = new SqlCommand(command, GetSQLConnection());

            try
            {
                sqlCommand.Parameters.AddRange(parameters);
                sqlCommand.Connection.Open();
                id = (int)sqlCommand.ExecuteScalar();
            }
            catch
            { return -1; }

            if (sqlCommand.Connection != null && sqlCommand.Connection.State == ConnectionState.Open)
                sqlCommand.Connection.Close();

            return id;
        }
        public static bool ExecuteNonQueryStoredProcedure(string procedureName, SqlParameter[] parameters)          
        {
            if (GetSQLConnection() == null)
                return false;

            bool successfulQuery = false;
            SqlCommand sqlCommand = new SqlCommand(procedureName, GetSQLConnection());
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlCommand.Parameters.AddRange(parameters);
                sqlCommand.Connection.Open();
                successfulQuery = sqlCommand.ExecuteNonQuery() > 0;
                successfulQuery = true;
            }
            catch
            { }

            if (sqlCommand.Connection != null && sqlCommand.Connection.State == ConnectionState.Open)
                sqlCommand.Connection.Close();

            return successfulQuery;
        }

        public static DataTable ExecuteDataQueryCommand(string command, SqlParameter[] parameters)                  
        {
            if (GetSQLConnection() == null)
                return null;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(command, GetSQLConnection());

            try
            {
                sqlAdapter.SelectCommand.Parameters.AddRange(parameters);
                sqlAdapter.SelectCommand.Connection.Open();
                sqlAdapter.Fill(dataTable);
            }
            catch
            { dataTable = null; }

            if (sqlAdapter.SelectCommand.Connection != null && sqlAdapter.SelectCommand.Connection.State == ConnectionState.Open)
                sqlAdapter.SelectCommand.Connection.Close();

            return dataTable;
        }
        public static DataTable ExecuteDataQueryStoredProcedure(string procedureName, SqlParameter[] parameters)    
        {
            if (GetSQLConnection() == null)
                return null;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(procedureName, GetSQLConnection());
            sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlAdapter.SelectCommand.Parameters.AddRange(parameters);
                sqlAdapter.SelectCommand.Connection.Open();
                sqlAdapter.Fill(dataTable);
            }
            catch
            { dataTable = null; }

            if (sqlAdapter.SelectCommand.Connection != null && sqlAdapter.SelectCommand.Connection.State == ConnectionState.Open)
                sqlAdapter.SelectCommand.Connection.Close();

            return dataTable;
        }

    }
}