using LLM.Store.ApplicationCore.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Utils
{
    public static class DBUtil
    {

        static readonly string connectionString;
        //public static IConfiguration Configuration { get; }
        static DBUtil()
        {
            connectionString = ConnectionStringSettingsProvider.ConnectionString;
        }

        //#region Data Update handlers

        /// <summary>z
        /// Executes Update statements in the database.
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParams">array of object</param>
        /// <param name="getId">bool</param>
        /// <returns>int</returns>
        public static int Update(string spName, DbParam[] spParams, bool getId)
        {
            using (DbConnection connection = (new MySqlConnection()))
            {
                int retValue = 0;
                connection.ConnectionString = connectionString;

                using (DbCommand command = (new MySqlCommand()))
                {
                    command.Connection = connection;
                    command.CommandText = spName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 1800;

                    if (spParams != null)
                    {
                        AssignParameters(command, spParams);
                    }

                    connection.Open();

                    try
                    {
                        if (getId)
                        {
                            MySqlParameter spParameter = new MySqlParameter("lngReturn", MySqlDbType.Int32);
                            spParameter.Direction = ParameterDirection.ReturnValue;
                            command.Parameters.Add(spParameter);

                            command.ExecuteNonQuery();
                            retValue = int.Parse(spParameter.Value.ToString());
                        }
                        else
                        {
                            retValue = command.ExecuteNonQuery();
                        }
                        AssignOutputParameters(command, spParams);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }

                        connection.Dispose();
                    }

                    return retValue;
                }
            }
        }

        /// <summary>
        /// Executes update statement in database
        /// </summary>
        /// <param name="ds">System.Data.DataSet</param>
        /// <param name="spInsert">string</param>
        /// <param name="spUpdate">string</param>
        /// <param name="spDelete">string</param>
        /// <param name="spParams">array of object</param>
        /// <param name="getId">bool</param>
        /// <returns>bool</returns>
        public static int DSUpdate(DataSet ds, string spInsert, string spUpdate, string spDelete, DbParam[] spParams, bool getId)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            int blnReturnValue = 0;

            using (MySqlConnection connection = (new MySqlConnection()))
            {
                connection.ConnectionString = connectionString;

                adapter.InsertCommand = (MySqlCommand)AssignParameters(new MySqlCommand(spInsert), spParams);
                adapter.UpdateCommand = (MySqlCommand)AssignParameters(new MySqlCommand(spUpdate), spParams);
                adapter.DeleteCommand = (MySqlCommand)AssignParameters(new MySqlCommand(spDelete), spParams);

                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

                adapter.InsertCommand.Connection = connection;
                adapter.UpdateCommand.Connection = connection;
                adapter.DeleteCommand.Connection = connection;
                try
                {
                    connection.Open();
                    blnReturnValue = adapter.Update(ds, ds.Tables[0].TableName);

                }
                catch
                {
                    blnReturnValue = -1;
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }

            return blnReturnValue;
        }

        /// <summary>
        /// Executes update statement in database
        /// </summary>
        /// <param name="ds">System.Data.DataSet</param>
        /// <param name="spInsert">string</param>
        /// <param name="spUpdate">string</param>
        /// <param name="spDelete">string</param>
        /// <param name="spParams">array of object</param>
        /// <param name="getId">bool</param>
        /// <returns>bool</returns>
        public static bool Update(DataSet ds, string spInsert, string spUpdate, string spDelete, DbParam[] spParams, bool getId)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            bool blnReturnValue = true;

            using (MySqlConnection connection = (new MySqlConnection()))
            {
                connection.ConnectionString = connectionString;

                adapter.InsertCommand = (MySqlCommand)AssignParameters(new MySqlCommand(spInsert), spParams);
                adapter.UpdateCommand = (MySqlCommand)AssignParameters(new MySqlCommand(spUpdate), spParams);
                adapter.DeleteCommand = (MySqlCommand)AssignParameters(new MySqlCommand(spDelete), spParams);

                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
                adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

                adapter.InsertCommand.Connection = connection;
                adapter.UpdateCommand.Connection = connection;
                adapter.DeleteCommand.Connection = connection;
                try
                {
                    connection.Open();
                    int returnValue = adapter.Update(ds, ds.Tables[0].TableName);
                    if (returnValue == -1)
                    {
                        blnReturnValue = false;
                    }
                }
                catch
                {
                    blnReturnValue = false;
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }

            return blnReturnValue;
        }

        /// <summary>
        /// Executes Update statements in the database.
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParams">string</param>
        /// <returns>int</returns>
        public static int Update(string spName, DbParam[] spParams)
        {
            return Update(spName, spParams, false);
        }

        /// <summary>
        /// Executes Insert statements in the database. Optionally returns new identifier.
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParams">array of object</param>
        /// <param name="getId">bool</param>
        /// <returns>int</returns>
        public static int Insert(string spName, DbParam[] spParams, bool getId)
        {
            using (DbConnection connection = (new MySqlConnection()))
            {
                int retValue = 0;
                connection.ConnectionString = connectionString;

                using (DbCommand command = (new MySqlCommand()))
                {

                    command.Connection = connection;
                    command.CommandTimeout = 1800;
                    command.CommandText = spName;
                    command.CommandType = CommandType.StoredProcedure;

                    if (spParams != null)
                    {
                        AssignParameters(command, spParams);
                    }

                    connection.Open();

                    try
                    {
                        if (getId)
                        {
                            MySqlParameter spParameter = new MySqlParameter("lngReturn", MySqlDbType.Int32);
                            spParameter.Direction = ParameterDirection.ReturnValue;
                            command.Parameters.Add(spParameter);

                            command.ExecuteNonQuery();
                            retValue = int.Parse(spParameter.Value.ToString());
                        }
                        else
                        {
                            retValue = command.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }

                        connection.Dispose();
                    }

                    return retValue;
                }
            }
        }

        /// <summary>
        /// Executes Insert statements in the database.
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParams">array of object</param>
        public static void Insert(string spName, DbParam[] spParams)
        {
            Insert(spName, spParams, false);
        }

        //#endregion

        #region Data Retrieve Handlers

        /// <summary>
        ///  Populates a DataSet according to a stored procedure and parameters.
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParams">array of object</param>
        /// <returns>System.Data.DataSet</returns>
        public static DataSet GetDataSet(string spName, DbParam[] spParams)
        {
            return GetDataSet(spName, spParams, null);
        }

        /// <summary>
        /// overloaded method to populate a DataSet according to a stored procedure and parameters.
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParams">array of object</param>
        /// <param name="Timeout">int</param>
        /// <returns>System.Data.DataSet</returns>
        public static DataSet GetDataSet(string spName, DbParam[] spParams, int? Timeout)
        {

            using (DbConnection connection = (new MySqlConnection()))
            {
                connection.ConnectionString = connectionString;



                using (DbCommand command = (new MySqlCommand()))
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spName;

                    if (Timeout.HasValue)
                    {
                        command.CommandTimeout = Timeout.Value;
                    }
                    command.CommandTimeout = 1800;
                    if (spParams != null)
                    {
                        AssignParameters(command, spParams);
                    }

                    using (DbDataAdapter adapter = (new MySqlDataAdapter()))
                    {
                        adapter.SelectCommand = command;

                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        return ds;
                    }
                }
            }
        }

        /// <summary>
        /// overloaded method to populate a DataTable according to a stored procedure and parameters.
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParams">array of object</param>
        /// <returns>System.Data.DataTable</returns>
        public static DataTable GetDataTable(string spName, DbParam[] spParams)
        {
            DataTable dt = null;
            DataSet ds = GetDataSet(spName, spParams);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            return dt;
        }

        /// <summary>
        /// overloaded method to populate a DataRow according to a stored procedure and parameters.
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParams">array of object</param>
        /// <returns>System.Data.DataRow</returns>
        public static DataRow GetDataRow(string spName, DbParam[] spParams)
        {
            DataRow row = null;

            DataTable dt = GetDataTable(spName, spParams);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    row = dt.Rows[0];
                }
            }

            return row;
        }

        /// <summary>
        /// Executes a stored procedure and returns a scalar value.
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParams">array of object</param>
        /// <returns>object</returns>
        public static object GetScalar(string spName, DbParam[] spParams)
        {
            using (DbConnection connection = (new MySqlConnection()))
            {

                connection.ConnectionString = connectionString;

                using (DbCommand command = (new MySqlCommand()))
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spName;

                    if (spParams != null)
                    {
                        AssignParameters(command, spParams);
                    }

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

        #endregion

        #region Utility methods

        /// <summary>
        /// Assigns paramets to DbCommand
        /// </summary>
        /// <param name="command">System.Data.Common.DbCommand</param>
        /// <param name="spParams">array of object</param>
        /// <returns>System.Data.Common.DbCommand</returns>
        private static DbCommand AssignParameters(DbCommand command, DbParam[] spParams)
        {
            if (spParams != null)
            {
                foreach (DbParam spParam in spParams)
                {
                    MySqlParameter spParameter = new MySqlParameter();

                    spParameter.MySqlDbType = spParam.ParamType;
                    spParameter.ParameterName = spParam.ParamName;
                    spParameter.Value = spParam.ParamValue;
                    spParameter.Direction = spParam.ParamDirection;
                    spParameter.SourceColumn = spParam.ParamSourceColumn;
                    spParameter.Size = spParam.Size;

                    command.Parameters.Add(spParameter);
                }
            }

            return command;
        }

        /// <summary>
        /// Escapes an input string for database processing, that is, 
        /// surround it with quotes and change any quote in the string to 
        /// two adjacent quotes (i.e. escape it). 
        /// If input string is null or empty a NULL string is returned.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <returns>Escaped output string.</returns>
        public static string Escape(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "NULL";
            else
                return "'" + s.Trim().Replace("'", "''") + "'";
        }

        /// <summary>
        /// Escapes an input string for database processing, that is, 
        /// surround it with quotes and change any quote in the string to 
        /// two adjacent quotes (i.e. escape it). 
        /// Also trims string at a given maximum length.
        /// If input string is null or empty a NULL string is returned.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <param name="maxLength">Maximum length of output string.</param>
        /// <returns>Escaped output string.</returns>
        public static string Escape(string s, int maxLength)
        {
            if (String.IsNullOrEmpty(s))
                return "NULL";
            else
            {
                s = s.Trim();
                if (s.Length > maxLength) s = s.Substring(0, maxLength - 1);
                return "'" + s.Trim().Replace("'", "''") + "'";
            }
        }

        /// <summary>
        /// converts an object to double value
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>double</returns>
        public static double ToDouble(object value)
        {
            double retValue = 0;

            if (value != DBNull.Value)
            {
                double.TryParse(value.ToString(), out retValue);
            }

            return retValue;
        }

        /// <summary>
        /// converts an object to decimal
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(object value)
        {
            decimal retValue = 0;

            if (value != DBNull.Value)
            {
                decimal.TryParse(value.ToString(), out retValue);
            }

            return retValue;
        }

        /// <summary>
        /// converts an object to float
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>float</returns>
        public static float ToFloat(object value)
        {
            float retValue = 0;

            if (value != DBNull.Value)
            {
                float.TryParse(value.ToString(), out retValue);
            }

            return retValue;
        }
        /// <summary>
        ///  converts an object to integer value
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>int</returns>
        public static int ToInteger(object value)
        {
            int retValue = 0;

            if (value != DBNull.Value)
            {
                int.TryParse(value.ToString(), out retValue);
            }

            return retValue;
        }

        /// <summary>
        ///  converts an object to long value
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>System.Int64</returns>
        public static long ToLong(object value)
        {
            long retValue = 0;

            if (value != DBNull.Value)
            {
                long.TryParse(value.ToString(), out retValue);
            }

            return retValue;
        }

        /// <summary>
        ///  converts an object to string value
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>string</returns>
        public static string ToString(object value)
        {
            string retValue = "";

            if (value != DBNull.Value && value != null)
            {
                retValue = Convert.ToString(value);
            }

            return retValue;
        }

        /// <summary>
        ///  converts an object to boolean value
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>bool</returns>
        public static bool ToBoolean(object value)
        {
            bool retValue = false;

            if (value != DBNull.Value)
            {
                try
                {
                    value = Convert.ToBoolean(value);
                }
                catch { }
                bool.TryParse(value.ToString(), out retValue);
            }

            return retValue;
        }

        /// <summary>
        ///  converts an object to datetime value
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>System.DateTime</returns>
        public static DateTime ToDateTime(object value)
        {
            DateTime retValue = new DateTime();

            if (value != DBNull.Value)
            {
                DateTime.TryParse(value.ToString(), out retValue);
            }

            return retValue;
        }

        /// <summary>
        ///  converts an object to bigint value
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>Int32</returns>
        public static long ToBigInteger(object value)
        {
            long retValue = 0;
            if (value != DBNull.Value)
            {
                try
                {
                    retValue = long.Parse(value.ToString());
                }
                catch { }
            }
            return retValue;
        }
        #endregion

        public static bool IsDataExists(DataSet ds, int TableCount)
        {
            return (ds != null && ds.Tables.Count > TableCount && ds.Tables[TableCount].Rows.Count > 0);
        }
        public static bool IsDataExists(DataSet ds)
        {
            return (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0);
        }
        public static bool IsDataExists(DataTable dt)
        {
            return (dt != null && dt.Rows.Count > 0);
        }
        public static bool IsDataTableExists(DataTable dt)
        {
            return (dt != null && dt.Rows.Count > 0);
        }
        public static string ToFormatedDatetime(object value)
        {
            string ReturnString = string.Empty;
            try
            {
                if (value != DBNull.Value && value != null)
                {
                    ReturnString = Convert.ToDateTime(value).ToString("MMM dd, yyyy");
                }
            }
            catch { ReturnString = ""; }
            return ReturnString;
        }

        public static float ToFloatValue(object value)
        {
            float retValue = 0;

            if (value != DBNull.Value)
            {
                float.TryParse(value.ToString(), out retValue);
            }

            return retValue;
        }
        public static string GetCurrencyCode(object value, string type)
        {
            string retValue = string.Empty;

            if (value != DBNull.Value && value != null)
            {
                switch (value.ToString())
                {
                    case "UAE Dirham":
                        {
                            if (type == "0")
                            {
                                retValue = "AED";
                            }
                            else
                            {
                                retValue = "Fills";
                            }
                            break;
                        }
                    case "Omani Riyal":
                        {
                            if (type == "0")
                            {
                                retValue = "Riyal";
                            }
                            else
                            {
                                retValue = "Fills";
                            }
                            break;
                        }
                    case "Pakistani Rupees":
                        {
                            if (type == "0")
                            {
                                retValue = "Rupees";
                            }
                            else
                            {
                                retValue = "Paisa";
                            }
                            break;
                        }
                    case "Bahrain Dinar":
                        {
                            if (type == "0")
                            {
                                retValue = "Dinar";
                            }
                            else
                            {
                                retValue = "Dinar";
                            }
                            break;
                        }
                    case "Other":
                        {
                            retValue = "";
                            break;
                        }
                }
            }

            return retValue;
        }

        public static float Truncate(this float value, int digits)
        {
            double result = Math.Round(value, 2);
            return (float)result;
        }
        /// <summary>
        ///  /// <param name="CreatedBy">Dheeraj</param>
        private static DbCommand AssignOutputParameters(DbCommand command, DbParam[] spParams)
        {
            if (spParams != null)
            {
                if (spParams.Length > 0)
                {
                    var outparams = from c in spParams
                                    where c.ParamDirection == ParameterDirection.InputOutput ||
                                        c.ParamDirection == ParameterDirection.Output
                                    select c;

                    foreach (DbParam param in outparams)
                    {
                        if (command.Parameters[param.ParamName] != null)
                        {
                            param.ParamValue = command.Parameters[param.ParamName].Value;
                        }
                    }
                }
            }
            return command;
        }
        public static async Task<int> ExecuteNonQueryAsync(string spName, params DbParam[] spParams)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (DbCommand command = new MySqlCommand(spName, connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (spParams != null)
                        {
                            AssignParameters(command, spParams);
                        }
                        //command.Parameters.AddRange(spParams);
                        await connection.OpenAsync();
                        return await command.ExecuteNonQueryAsync();
                    }
                    finally
                    {
                        await connection.CloseAsync();
                        // connection.Close();
                    }
                }
            }

        }
        /// <summary>
        ///  /// <param name="CreatedBy">Dheeraj</param>
        /// Executes Insert statements in the database. Optionally returns new identifier.
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParams">array of object</param>
        /// <param name="getId">bool</param>
        /// <returns>int</returns>
        public static async Task<int> InsertAsync(string spName, DbParam[] spParams, bool getId)
        {
            using (var connection = (new MySqlConnection()))
            {
                int retValue = 0;
                connection.ConnectionString = connectionString;

                using (DbCommand command = (new MySqlCommand()))
                {

                    command.Connection = connection;
                    command.CommandTimeout = 1800;
                    command.CommandText = spName;
                    command.CommandType = CommandType.StoredProcedure;

                    if (spParams != null)
                    {
                        AssignParameters(command, spParams);
                    }

                    await connection.OpenAsync();

                    try
                    {
                        if (getId)
                        {
                            MySqlParameter spParameter = new MySqlParameter("lngReturn", MySqlDbType.Int32);
                            spParameter.Direction = ParameterDirection.ReturnValue;
                            command.Parameters.Add(spParameter);

                            await command.ExecuteNonQueryAsync();
                            retValue = int.Parse(spParameter.Value.ToString());
                        }
                        else
                        {
                            retValue = await command.ExecuteNonQueryAsync();
                            // retValue = command.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {

                            await connection.CloseAsync();
                        }

                        connection.Dispose();
                    }

                    return retValue;
                }
            }
        }
        /// <summary>
        /// <param name="CreatedBy">Dheeraj</param>
        /// overloaded method to populate a DataSet according to a stored procedure and parameters.
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParams">array of object</param>
        /// <param name="Timeout">int</param>
        /// <returns>System.Data.DataSet</returns>
        public static async Task<DataSet> GetDataSetAsync(string spName, DbParam[] spParams, int? Timeout)
        {
            using (DbConnection connection = (new MySqlConnection()))
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = (new MySqlCommand()))
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spName;

                    if (Timeout.HasValue)
                    {
                        command.CommandTimeout = Timeout.Value;
                    }
                    else
                    {
                        command.CommandTimeout = 1800;
                    }
                    if (spParams != null)
                    {
                        AssignParameters(command, spParams);
                    }

                    using (DbDataAdapter adapter = (new MySqlDataAdapter()))
                    {
                        adapter.SelectCommand = command;

                        DataSet ds = new DataSet();
                        // await adapter.FillAsync(ds);
                        await Task.Run(() => adapter.Fill(ds));

                        return ds;
                    }
                }
            }
        }
        public static async Task<DataSet> GetDataSetAsync(string spName, DbParam[] spParams, int? Timeout, DbConnection dbConnection, DbTransaction dbTransaction)
        {

            using (DbCommand command = (new MySqlCommand()))
            {
                command.Connection = dbConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                command.Transaction = dbTransaction;//to set

                if (Timeout.HasValue)
                {
                    command.CommandTimeout = Timeout.Value;
                }
                else
                {
                    command.CommandTimeout = 1800;
                }
                if (spParams != null)
                {
                    AssignParameters(command, spParams);
                }

                using (DbDataAdapter adapter = (new MySqlDataAdapter()))
                {
                    adapter.SelectCommand = command;
                    DataSet ds = new DataSet();
                    await Task.Run(() => adapter.Fill(ds));
                    return ds;
                }

            }
        }
        //public static string ToSqliteString(object value)
        //{
        //    string retValue = "";
        //    if (value != DBNull.Value)
        //    {
        //        retValue = value.ToString();
        //    }
        //    return CommonFunctions.ReplaceSQForSQLiteInser(retValue);
        //}
        public static async Task<DataTable> GetDataTableAsync(string spName, DbParam[] spParams, int? Timeout)
        {
            DataTable dt = null;
            DataSet ds = await GetDataSetAsync(spName, spParams, Timeout);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            return dt;
        }
        public static async Task<DataTable> GetDataTableAsync(string spName, DbParam[] spParams, int? Timeout, DbConnection dbConnection, DbTransaction dbTransaction)
        {
            DataTable dt = null;
            DataSet ds = await GetDataSetAsync(spName, spParams, Timeout, dbConnection, dbTransaction);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            return dt;
        }
        public static List<T> ConvertDataTable<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToLower() == column.ColumnName.ToLower())
                    {
                        switch (pro.PropertyType.Name.ToLower())
                        //switch (column.DataType.Name.ToLower())
                        {
                            case "int32":
                                {
                                    pro.SetValue(obj, ToInteger(dr[column.ColumnName]), null);
                                    break;
                                }
                            case "decimal":
                                {
                                    pro.SetValue(obj, ToDecimal(dr[column.ColumnName]), null);
                                    break;
                                }
                            case "datetime":
                                {
                                    pro.SetValue(obj, ToDateTime(dr[column.ColumnName]), null);
                                    break;
                                }
                            case "string":
                                {
                                    pro.SetValue(obj, ToString(dr[column.ColumnName]), null);
                                    break;
                                }
                            case "uint64":
                                {
                                    pro.SetValue(obj, ToInteger(dr[column.ColumnName]), null);
                                    break;
                                }
                            default:
                                {
                                    pro.SetValue(obj, dr[column.ColumnName], null);
                                    break;
                                }
                        }

                    }
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}

