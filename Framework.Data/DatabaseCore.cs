using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Framework.Entity;

namespace Framework.Data
{
    /// <summary>
    /// This class provides core database services
    /// </summary>
    public abstract class DatabaseCore: IDatabaseRepository, IDisposable
    {
        #region| Fields |

        /// <summary>
        /// Interface that sets the method's signature that will be implemented by the database repository service
        /// </summary>
        protected readonly IDatabaseRepository databaseRepository;

        #endregion

        #region| Constructor |

        /// <summary>
        /// Default constructor 
        /// </summary>
        /// <param name="container">Dependency injection container</param>
        public DatabaseCore(ContainerDI container)
        {
            databaseRepository = container.DatabaseRepository;
            databaseRepository.SetContext(container.DatabaseContext);

            container = null;
        }       

        #endregion

        #region| IDisposable Members |

        /// <summary>
        /// IDisposable implementation 
        /// </summary>
        public void Dispose()
        {
            databaseRepository.Dispose();

        }

        #endregion

        #region| Methods |

        /// <summary>
        /// Adds the specified IDbDataParameter object to the parameter collection
        /// </summary>
        /// <param name="dbDataParameter">IDbDataParameter</param>
        public void AddParam(IDbDataParameter dbDataParameter)
        {
            databaseRepository.AddParam(dbDataParameter);
        }

        /// <summary>
        /// Fill the property value of the Business Entity Structured Class with the information in the SqlDataReader
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="sender">Class derived from the Framework.Entity.BussinessEntityStructure class</param>
        /// <param name="type">Type of Sender</param>
        /// <param name="typeName">Gets the name of the current member.</param>
        /// <param name="schema">List of the columns avaiable in the SqlDataReader</param>
        /// <param name="mustRaiseException">Indicates whether an exception will be throw in case of failure</param>
        public void BindList<T>(SqlDataReader dataReader, T sender, Type type, string typeName, HashSet<string> schema, bool mustRaiseException) where T : BusinessEntityStructure
        {
            databaseRepository.BindList<T>(dataReader, sender, type, typeName, schema, mustRaiseException);
        }
       
        /// <summary>
        /// Check if the ParameterName is null or empty
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public string CheckParameterName(string parameterName)
        {
            return databaseRepository.CheckParameterName(parameterName);
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected 
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>The number of rows affected</returns>
        public int Execute(bool stopExecutionImmediately = true)
        {
            return databaseRepository.Execute(stopExecutionImmediately);
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected 
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>The number of rows affected</returns>
        public async Task<int> ExecuteAsync(bool stopExecutionImmediately = true)
        {
            return await databaseRepository.ExecuteAsync(stopExecutionImmediately);
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected 
        /// </summary>
        /// <param name="outputParameterName">Parameter name to returned</param>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>The number of rows affected</returns>
        public int Execute(string outputParameterName, bool stopExecutionImmediately = true)
        {
            return databaseRepository.Execute(outputParameterName, stopExecutionImmediately);
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected 
        /// </summary>
        /// <param name="outputParameterName">Parameter name to returned</param>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>The number of rows affected</returns>
        public async Task<int> ExecuteAsync(string outputParameterName, bool stopExecutionImmediately = true)
        {
            return await databaseRepository.ExecuteAsync(outputParameterName, stopExecutionImmediately);
        }

        /// <summary>
        ///  Adds or refreshes rows in a specified range in the System.Data.DataSet to match those in the data source using the System.Data.DataTable name.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>System.Data.DataTable</returns>
        public DataTable GetDataTable(bool stopExecutionImmediately = true)
        {
            return databaseRepository.GetDataTable(stopExecutionImmediately);
        }

        /// <summary>
        ///  Adds or refreshes rows in a specified range in the System.Data.DataSet to match those in the data source using the System.Data.DataTable name.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>System.Data.DataTable</returns>
        public async Task<DataTable> GetDataTableAsync(bool stopExecutionImmediately = true)
        {
            return await databaseRepository.GetDataTableAsync(stopExecutionImmediately);
        }

        /// <summary>
        /// Adds or refreshes rows in the System.Data.DataSet.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>System.Data.DataSet</returns>
        public DataSet GetDataSet(bool stopExecutionImmediately = true)
        {
            return databaseRepository.GetDataSet(stopExecutionImmediately);
        }

        /// <summary>
        /// Adds or refreshes rows in the System.Data.DataSet.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>System.Data.DataSet</returns>
        public async Task<DataSet> GetDataSetAsync(bool stopExecutionImmediately = true)
        {
            return await databaseRepository.GetDataSetAsync(stopExecutionImmediately);
        }

        /// <summary>
        /// Get the message from the print output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            databaseRepository.GetInfoMessage(sender, e);
        }

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database (using Reflection.Emit)
        /// </summary>
        /// <returns>Generic Collection List</returns>
        public IEnumerable<T> Query<T>() where T: new()
        {
            return databaseRepository.Query<T>();
        }

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database  (using Reflection.Emit)
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        public List<T> GetListOptimized<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new()
        {
            return databaseRepository.GetListOptimized<T>(dataReader, isUsingNextResult);
        }

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database  (using Reflection.Emit)
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        public async Task<List<T>> GetListOptimizedAsync<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new()
        {
            return await databaseRepository.GetListOptimizedAsync<T>(dataReader, isUsingNextResult);
        }

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        public List<T> GetList<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new()
        {
            return databaseRepository.GetList<T>(dataReader, isUsingNextResult);
        }

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        public async Task<List<T>> GetListAsync<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new()
        {
            return await databaseRepository.GetListAsync<T>(dataReader, isUsingNextResult);
        }

        /// <summary>
        /// Check the parameter value
        /// </summary>
        /// <param name="parameterValue">ParameterValue</param>
        /// <returns>object</returns>
        public object GetParameterValue(object parameterValue)
        {
            return databaseRepository.GetParameterValue(parameterValue);
        }

        /// <summary>
        /// Retuns a generic list of primitive type whose content will be filled with the information from the Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader">SqlDataReader</param>
        /// <returns></returns>
        public List<T> GetPrimitiveList<T>(SqlDataReader dataReader = null) where T : IComparable, new()
        {
            return databaseRepository.GetPrimitiveList<T>(dataReader);
        }

        /// <summary>
        /// Retuns a generic list of primitive type whose content will be filled with the information from the Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader">SqlDataReader</param>
        /// <returns></returns>
        public async Task<List<T>> GetPrimitiveListAsync<T>(SqlDataReader dataReader = null) where T : IComparable, new()
        {
            return await databaseRepository.GetPrimitiveListAsync<T>(dataReader);
        }

        /// <summary>
        /// Get a SqlDataReader based on the System.Data.CommandType and the given parameters
        /// </summary>
        /// <returns>System.Data.SqlClient.SqlDataReader</returns>
        public SqlDataReader GetReader()
        {
            return databaseRepository.GetReader();
        }

        /// <summary>
        /// Get a SqlDataReader based on the System.Data.CommandType and the given parameters
        /// </summary>
        /// <returns>System.Data.SqlClient.SqlDataReader</returns>
        public async Task<SqlDataReader> GetReaderAsync()
        {
            return await databaseRepository.GetReaderAsync();
        }

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the
        /// result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>
        /// The first column of the first row in the result set, or a null reference if the result set is empty. 
        /// Returns a maximum of 2033 characters.
        /// </returns>
        public T GetScalar<T>(bool stopExecutionImmediately = true)
        {
            return databaseRepository.GetScalar<T>(stopExecutionImmediately);
        }

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the
        /// result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        /// <returns>
        /// The first column of the first row in the result set, or a null reference if the result set is empty. 
        /// Returns a maximum of 2033 characters.
        /// </returns>
        public async Task<T> GetScalarAsync<T>(bool stopExecutionImmediately = true)
        {
            return await databaseRepository.GetScalarAsync<T>(stopExecutionImmediately);
        }

        /// <summary>
        /// Returns a System.Data.DataTable that describes the column metadata of the SqlDataReader
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <returns></returns>
        public HashSet<string> GetSchema(SqlDataReader dataReader)
        {
            return databaseRepository.GetSchema(dataReader);
        }

        /// <summary>
        /// Gets the output of the parameter value
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="parameterName">ParameterName</param>
        /// <returns>An System.Object that is the value of the parameter. The default value is null.</returns>
        public T GetValue<T>(string parameterName)
        {
            return databaseRepository.GetValue<T>(parameterName);
        }

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT)
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <param name="parameterValue">Parameter Value</param>    
        public void In(string parameterName, object parameterValue)
        {
            databaseRepository.In(parameterName, parameterValue);
        }

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT)
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <param name="parameterValue">Parameter Value</param>
        /// <param name="sqlDbType">System.Data.SqlDbType</param>
        public void In(string parameterName, object parameterValue, SqlDbType sqlDbType)
        {
            databaseRepository.In(parameterName, parameterValue, sqlDbType);
        }

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT / OUTPUT)
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <param name="parameterValue">Parameter Value</param>
        /// <param name="size">Size</param>
        public void InOut(string parameterName, object parameterValue, int size=0)
        {
            databaseRepository.InOut(parameterName, parameterValue, size);
        }

        /// <summary>
        /// Check whether the Profiler is enabled or not to log the T-SQL Statements in a log file 
        /// </summary>
        public void IsProfilerEnabled()
        {
            databaseRepository.IsProfilerEnabled();
        }

        /// <summary>
        /// Check whether the Profiler is enabled or not to log the T-SQL Statements in a log file 
        /// </summary>
        public async Task IsProfilerEnabledAsync()
        {
            await databaseRepository.IsProfilerEnabledAsync();
        }

        /// <summary>
        /// Returns an instance of the Business Entity Structured class whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>An instance of the Business Entity Structured class</returns>
        public T Map<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new()
        {
            return databaseRepository.Map<T>(dataReader, isUsingNextResult);
        }

        /// <summary>
        /// Returns an instance of the Business Entity Structured class whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="dataReader">SqlDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>An instance of the Business Entity Structured class</returns>
        public async Task<T> MapAsync<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new()
        {
            return await databaseRepository.MapAsync<T>(dataReader, isUsingNextResult);
        }

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (OUTPUT)
        /// </summary>
        /// <param name="parameterName">Parameter Name</param>
        /// <param name="sqlDbType">System.Data.DbType</param>
        /// <param name="parameterValue">ParameterValue</param>     
        public void Out(string parameterName, SqlDbType sqlDbType, object parameterValue = null)
        {
            databaseRepository.Out(parameterName, sqlDbType, parameterValue);
        }

        /// <summary>
        /// Opens a database connection with the property settings specified in the ConnectionString.
        /// </summary>
        public void Prepare()
        {
            databaseRepository.Prepare();
        }

        /// <summary>
        /// Opens a database connection with the property settings specified in the ConnectionString.
        /// </summary>
        public async Task PrepareAsync()
        {
            await databaseRepository.PrepareAsync();
        }

        /// <summary>
        /// Returns the T-SQL Statement that will be execute on the Database
        /// </summary>
        /// <returns>T-SQL Statement</returns>
        public string PreviewSQL()
        {
            return databaseRepository.PreviewSQL();
        }

        /// <summary>
        /// Clear all sql command parameters
        /// </summary>
        public void ClearParameters()
        {
            databaseRepository.ClearParameters();
        }

        /// <summary>
        /// Closes the connection to the database. This is the preferred method of closing any open connection.
        /// Closes the command used to execute statements on the database
        /// </summary>
        /// <param name="stopExecutionImmediately">If true, the connection will be released immediately after the t-sql statement execution. Otherwise, it will wait for the next one</param>
        public void Release(bool stopExecutionImmediately = true)
        {
            databaseRepository.Release(stopExecutionImmediately);
        }

        /// <summary>
        /// Configures the System.Data.CommandType and the T-SQL statement that will be executed on the Database
        /// </summary>
        /// <param name="commandType">System.Data.CommandType</param>
        /// <param name="statement">T-SQL Statement</param>
        public void Run(string statement, CommandType commandType = CommandType.StoredProcedure)
        {
            databaseRepository.Run(statement, commandType);
        }

        /// <summary>
        /// Sets the database context to execute operations against the DataBase
        /// </summary>
        /// <param name="databaseContext">IDatabaseContext</param>
        public void SetContext(IDatabaseContext databaseContext)
        {
            databaseRepository.SetContext(databaseContext);
        } 

        #endregion
    }
}
