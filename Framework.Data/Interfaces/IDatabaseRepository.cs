using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

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
        /// <param name="dbDataParameter">IDbDataParameter</param>
        void AddParam(IDbDataParameter dbDataParameter);

        /// <summary>
        /// Fill the property value of the Business Entity Structured Class with the information in the SqlDataReader
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="sender">Class derived from the Framework.Entity.BussinessEntityStructure class</param>
        /// <param name="type">Type of Sender</param>
        /// <param name="typeName">Gets the name of the current member.</param>
        /// <param name="schema">List of the columns avaiable in the SqlDataReader</param>
        /// <param name="mustRaiseException">Indicates whether an exception will be throw in case of failure</param>
        void BindList<T>(SqlDataReader dataReader, T sender, Type type, string typeName, HashSet<string> schema, bool mustRaiseException) where T : BusinessEntityStructure;

        /// <summary>
        /// Check if the ParameterName is null or empty
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        string CheckParameterName(string parameterName);

        /// <summary>
        /// Release managed resources
        /// </summary>
        void Dispose();

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected 
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>The number of rows affected</returns>
        int Execute(bool stopExecutionImmediately = true);

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected 
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>The number of rows affected</returns>
        Task<int> ExecuteAsync(bool stopExecutionImmediately = true);

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected 
        /// </summary>
        /// <param name="outputParameterName">Parameter name to returned</param>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>The number of rows affected</returns>
        int Execute(string outputParameterName, bool stopExecutionImmediately = true);

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected 
        /// </summary>
        /// <param name="outputParameterName">Parameter name to returned</param>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>The number of rows affected</returns>
        Task<int> ExecuteAsync(string outputParameterName, bool stopExecutionImmediately = true);

        /// <summary>
        ///  Adds or refreshes rows in a specified range in the System.Data.DataSet to match those in the data source using the System.Data.DataTable name.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>System.Data.DataTable</returns>
        DataTable GetDataTable(bool stopExecutionImmediately = true);

        /// <summary>
        ///  Adds or refreshes rows in a specified range in the System.Data.DataSet to match those in the data source using the System.Data.DataTable name.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>System.Data.DataTable</returns>
        Task<DataTable> GetDataTableAsync(bool stopExecutionImmediately = true);

        /// <summary>
        /// Adds or refreshes rows in the System.Data.DataSet.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>System.Data.DataSet</returns>
        DataSet GetDataSet(bool stopExecutionImmediately = true);

        /// <summary>
        /// Adds or refreshes rows in the System.Data.DataSet.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>System.Data.DataSet</returns>
        Task<DataSet> GetDataSetAsync(bool stopExecutionImmediately = true);
        
        /// <summary>
        /// Get the message from the print output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GetInfoMessage(object sender, SqlInfoMessageEventArgs e);

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database (using Reflection.Emit)
        /// </summary>
        /// <returns>Generic Collection List</returns>
        IEnumerable<T> Query<T>() where T : new();

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database  (using Reflection.Emit)
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        List<T> GetListOptimized<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new();

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database  (using Reflection.Emit)
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        Task<List<T>> GetListOptimizedAsync<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new();

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        List<T> GetList<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new();

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        Task<List<T>> GetListAsync<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new();

        /// <summary>
        /// Check the parameter value
        /// </summary>
        /// <param name="parameterValue">ParameterValue</param>
        /// <returns>object</returns>
        object GetParameterValue(object parameterValue);

        /// <summary>
        /// Retuns a generic list of primitive type whose content will be filled with the information from the Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader">SqlDataReader</param>
        /// <returns></returns>
        List<T> GetPrimitiveList<T>(SqlDataReader dataReader = null) where T : IComparable, new();

        /// <summary>
        /// Retuns a generic list of primitive type whose content will be filled with the information from the Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader">SqlDataReader</param>
        /// <returns></returns>
        Task<List<T>> GetPrimitiveListAsync<T>(SqlDataReader dataReader = null) where T : IComparable, new();

        /// <summary>
        /// Get a SqlDataReader based on the System.Data.CommandType and the given parameters
        /// </summary>
        /// <returns>System.Data.SqlClient.SqlDataReader</returns>
        SqlDataReader GetReader();

        /// <summary>
        /// Get a SqlDataReader based on the System.Data.CommandType and the given parameters
        /// </summary>
        /// <returns>System.Data.SqlDataReader</returns>
        Task<SqlDataReader> GetReaderAsync();

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the
        /// result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>
        /// The first column of the first row in the result set, or a null reference if the result set is empty. 
        /// Returns a maximum of 2033 characters.
        /// </returns>
        T GetScalar<T>(bool stopExecutionImmediately = true);

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the
        /// result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>
        /// The first column of the first row in the result set, or a null reference if the result set is empty. 
        /// Returns a maximum of 2033 characters.
        /// </returns>
        Task<T> GetScalarAsync<T>(bool stopExecutionImmediately = true);

        /// <summary>
        /// Returns a System.Data.DataTable that describes the column metadata of the SqlDataReader
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <returns> HashSet<string></returns>
        HashSet<string> GetSchema(SqlDataReader dataReader);

        /// <summary>
        /// Gets the output of the parameter value
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="parameterName">ParameterName</param>
        /// <returns>An System.Object that is the value of the parameter. The default value is null.</returns>
        T GetValue<T>(string parameterName);

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT)
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <param name="parameterValue">Parameter Value</param>     
        void In(string parameterName, object parameterValue);

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT)
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <param name="parameterValue">Parameter Value</param>
        /// <param name="sqlDbType">System.Data.SqlDbType</param>
        void In(string parameterName, object parameterValue, SqlDbType sqlDbType);

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT / OUTPUT)
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <param name="parameterValue">Parameter Value</param>   
        /// <param name="size">Size</param>
        void InOut(string parameterName, object parameterValue, int size=0);

        /// <summary>
        /// Check whether the Profiler is enabled or not to log the T-SQL Statements in a log file 
        /// </summary>
        void IsProfilerEnabled();

        /// <summary>
        /// Check whether the Profiler is enabled or not to log the T-SQL Statements in a log file 
        /// </summary>
        Task IsProfilerEnabledAsync();

        /// <summary>
        /// Returns an instance of the Business Entity Structured class whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>An instance of the Business Entity Structured class</returns>
        T Map<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new();

        /// <summary>
        /// Returns an instance of the Business Entity Structured class whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>An instance of the Business Entity Structured class</returns>
        Task<T> MapAsync<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new();

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (OUTPUT)
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <param name="sqlDbType">System.Data.DbType</param>
        /// <param name="parameterValue">ParameterValue</param>       
        void Out(string parameterName, SqlDbType sqlDbType, object parameterValue = null);

        /// <summary>
        /// Opens a database connection with the property settings specified in the ConnectionString.
        /// </summary>
        void Prepare();

        /// <summary>
        /// Opens a database connection with the property settings specified in the ConnectionString.
        /// </summary>
        Task PrepareAsync();

        /// <summary>
        /// Returns the T-SQL Statement that will be execute on the Database
        /// </summary>
        /// <returns>T-SQL Statement</returns>
        string PreviewSQL();

        /// <summary>
        /// Clear all sql command parameters
        /// </summary>
        void ClearParameters();
        
        /// <summary>
        /// Closes the connection to the database. This is the preferred method of closing any open connection.
        /// Closes the command used to execute statements on the database
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        void Release(bool stopExecutionImmediately = true);

        /// <summary>
        /// Configures the System.Data.CommandType and the T-SQL statement that will be executed on the Database
        /// </summary>
        /// <param name="commandType">System.Data.CommandType</param>
        /// <param name="statement">T-SQL Statement</param>
        void Run(string statement, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Sets the database context to execute operations against the DataBase
        /// </summary>
        /// <param name="databaseContext">IDatabaseContext</param>
        void SetContext(IDatabaseContext databaseContext);

        #endregion
    }
}
