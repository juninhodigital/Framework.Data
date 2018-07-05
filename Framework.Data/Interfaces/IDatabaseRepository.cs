using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Framework.Entity;

namespace Framework.Data
{
    /// <summary>
    /// Interface that sets the method's signature that will be implemented by the database repository service
    /// </summary>
    public interface IDatabaseRepository
    {
        #region| Methods |

        /// <summary>
        /// Adds the specified IDbDataParameter object to the parameter collection
        /// </summary>
        /// <param name="oDbParameter">IDbDataParameter</param>
        void AddParam(IDbDataParameter oDbParameter);

        /// <summary>
        /// Fill the property value of the Business Entity Structured Class with the information in the IDataReader
        /// </summary>
        /// <param name="oIDataReader">IDataReader</param>
        /// <param name="Sender">Class derived from the Framework.Entity.BussinessEntityStructure class</param>
        /// <param name="oType">Type of Sender</param>
        /// <param name="TypeName">Gets the name of the current member.</param>
        /// <param name="oSchema">List of the columns avaiable in the IDataReader</param>
        /// <param name="MustRaiseException">Indicates whether an exception will be throw in case of failure</param>
        void BindList<T>(IDataReader oIDataReader, T Sender, Type oType, string TypeName, List<string> oSchema, bool MustRaiseException) where T : BusinessEntityStructure;

        /// <summary>
        /// Check whether an error occured in all database collection
        /// </summary>
        void CheckErrorsOnAll();

        /// <summary>
        /// Check if the ParameterName is null or empty
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <returns></returns>
        string CheckParameterName(string ParameterName);

        /// <summary>
        /// Release managed resources
        /// </summary>
        void Dispose();

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected 
        /// </summary>
        /// <returns>The number of rows affected</returns>
        int Execute();

        /// <summary>
        ///  Adds or refreshes rows in a specified range in the System.Data.DataSet to match those in the data source using the System.Data.DataTable name.
        /// </summary>
        /// <returns>System.Data.DataTable</returns>
        DataTable GetDataTable();

        /// <summary>
        /// Adds or refreshes rows in the System.Data.DataSet.
        /// </summary>
        /// <returns>System.Data.DataSet</returns>
        DataSet GetDataSet();

        /// <summary>
        /// Get the message from the print output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GetInfoMessage(object sender, SqlInfoMessageEventArgs e);

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="oIDataReader">IDataReader</param>
        /// <param name="IsUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        List<T> GetList<T>(IDataReader oIDataReader = null, bool IsUsingNextResult = false) where T : BusinessEntityStructure;

        /// <summary>
        /// Check the parameter value
        /// </summary>
        /// <param name="ParameterValue">ParameterValue</param>
        /// <returns>object</returns>
        object GetParameterValue(object ParameterValue);

        /// <summary>
        /// Retuns a generic list of primitive type whose content will be filled with the information from the Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oIDataReader"></param>
        /// <returns></returns>
        List<T> GetPrimitiveList<T>(IDataReader oIDataReader = null) where T : IComparable;

        /// <summary>
        /// Get a IDataReader based on the System.Data.CommandType and the given parameters
        /// </summary>
        /// <returns>System.Data.IDataReader</returns>
        IDataReader GetReader();

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the
        /// result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <returns>
        /// The first column of the first row in the result set, or a null reference if the result set is empty. 
        /// Returns a maximum of 2033 characters.
        /// </returns>
        T GetScalar<T>();

        /// <summary>
        /// Returns a System.Data.DataTable that describes the column metadata of the IDataReader
        /// </summary>
        /// <param name="oIDataReader"></param>
        /// <returns></returns>
        List<string> GetSchema(IDataReader oIDataReader);

        /// <summary>
        /// Gets the output of the parameter value
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="ParameterName">ParameterName</param>
        /// <returns>An System.Object that is the value of the parameter. The default value is null.</returns>
        T GetValue<T>(string ParameterName);

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT)
        /// </summary>
        /// <param name="ParameterName">Parameter Name</param>
        /// <param name="ParameterValue">Parameter Value</param>     
        void In(string ParameterName, object ParameterValue);

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT)
        /// </summary>
        /// <param name="ParameterName">Parameter Name</param>
        /// <param name="ParameterValue">Parameter Value</param>
        /// <param name="ParameterType">System.Data.SqlDbType</param>
        void In(string ParameterName, object ParameterValue, SqlDbType ParameterType);

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT / OUTPUT)
        /// </summary>
        /// <param name="ParameterName">Parameter Name</param>
        /// <param name="ParameterValue">Parameter Value</param>       
        void InOut(string ParameterName, object ParameterValue);

        /// <summary>
        /// Check whether the Profiler is enabled or not to log the T-SQL Statements in a log file 
        /// </summary>
        void IsProfilerEnabled();

        /// <summary>
        /// Logs the errors into the Database class
        /// </summary>
        /// <param name="oDataBaseManager">DataBaseManager</param>
        /// <param name="oDataBase">DataBase</param>
        /// <param name="Error">Exception</param>
        void LogError(IDatabaseManager oDataBaseManager, IDatabaseContext oDataBase, Exception Error);

        /// <summary>
        /// Returns an instance of the Business Entity Structured class whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="oIDataReader">IDataReader</param>
        /// <param name="IsUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>An instance of the Business Entity Structured class</returns>
        T Map<T>(IDataReader oIDataReader = null, bool IsUsingNextResult = false) where T : BusinessEntityStructure;

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (OUTPUT)
        /// </summary>
        /// <param name="ParameterName">Parameter Name</param>
        /// <param name="ParameterType">System.Data.DbType</param>
        /// <param name="ParameterValue">ParameterValue</param>       
        void Out(string ParameterName, SqlDbType ParameterType, object ParameterValue = null);

        /// <summary>
        /// Opens a database connection with the property settings specified in the ConnectionString.
        /// </summary>
        void Prepare(IDatabaseContext oDataBase);

        /// <summary>
        /// Returns the T-SQL Statement that will be execute on the Database
        /// </summary>
        /// <returns>T-SQL Statement</returns>
        string PreviewSQL();

        /// <summary>
        /// Closes the connection to the database. This is the preferred method of closing any open connection.
        /// Closes the command used to execute statements on the database
        /// </summary>
        void Release();

        /// <summary>
        /// Configures the System.Data.CommandType and the T-SQL statement that will be executed on the Database
        /// </summary>
        /// <param name="CommandType">System.Data.CommandType</param>
        /// <param name="Statement">T-SQL Statement</param>
        void Run(string Statement, CommandType CommandType = CommandType.StoredProcedure);

        /// <summary>
        /// Sets the DataBaseManager to execute operations against the DataBase
        /// </summary>
        /// <param name="oDM">DataBaseManager</param>
        void SetManager(IDatabaseManager oDM);

        #endregion
    }
}
