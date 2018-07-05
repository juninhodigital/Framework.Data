using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
        protected readonly IDatabaseRepository DB;

        #endregion

        #region| Constructor |

        /// <summary>
        /// Default Constructor 
        /// </summary>
        /// <param name="DI"></param>
        public DatabaseCore(ContainerDI DI)
        {
            DB = DI.databaseRepository;
            DB.SetManager(DI.databaseManager);

            DI = null;
        }       

        #endregion

        #region| IDisposable Members |

        /// <summary>
        /// IDisposable implementation 
        /// </summary>
        public void Dispose()
        {
            DB.Dispose();

        }

        #endregion

        #region| Methods |

        /// <summary>
        /// Adds the specified IDbDataParameter object to the parameter collection
        /// </summary>
        /// <param name="oDbParameter">IDbDataParameter</param>
        public void AddParam(IDbDataParameter oDbParameter)
        {
            DB.AddParam(oDbParameter);
        }

        /// <summary>
        /// Fill the property value of the Business Entity Structured Class with the information in the IDataReader
        /// </summary>
        /// <param name="oIDataReader">IDataReader</param>
        /// <param name="Sender">Class derived from the Framework.Entity.BussinessEntityStructure class</param>
        /// <param name="oType">Type of Sender</param>
        /// <param name="TypeName">Gets the name of the current member.</param>
        /// <param name="oSchema">List of the columns avaiable in the IDataReader</param>
        /// <param name="MustRaiseException">Indicates whether an exception will be throw in case of failure</param>
        public void BindList<T>(IDataReader oIDataReader, T Sender, Type oType, string TypeName, List<string> oSchema, bool MustRaiseException) where T : BusinessEntityStructure
        {
            DB.BindList<T>(oIDataReader, Sender, oType, TypeName, oSchema, MustRaiseException);
        }

        /// <summary>
        /// Check whether an error occured in all database collection
        /// </summary>
        public void CheckErrorsOnAll()
        {
            DB.CheckErrorsOnAll();
        }

        /// <summary>
        /// Check if the ParameterName is null or empty
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <returns></returns>
        public string CheckParameterName(string ParameterName)
        {
            return DB.CheckParameterName(ParameterName);
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected 
        /// </summary>
        /// <returns>The number of rows affected</returns>
        public int Execute()
        {
            return DB.Execute();
        }

        /// <summary>
        ///  Adds or refreshes rows in a specified range in the System.Data.DataSet to match those in the data source using the System.Data.DataTable name.
        /// </summary>
        /// <returns>System.Data.DataTable</returns>
        public DataTable GetDataTable()
        {
            return DB.GetDataTable();
        }

        /// <summary>
        /// Adds or refreshes rows in the System.Data.DataSet.
        /// </summary>
        /// <returns>System.Data.DataSet</returns>
        public DataSet GetDataSet()
        {
            return DB.GetDataSet();
        }

        /// <summary>
        /// Get the message from the print output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            DB.GetInfoMessage(sender, e);
        }

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="oIDataReader">IDataReader</param>
        /// <param name="IsUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        public List<T> GetList<T>(IDataReader oIDataReader = null, bool IsUsingNextResult = false) where T : BusinessEntityStructure
        {
            return DB.GetList<T>(oIDataReader, IsUsingNextResult);
        }

        /// <summary>
        /// Check the parameter value
        /// </summary>
        /// <param name="ParameterValue">ParameterValue</param>
        /// <returns>object</returns>
        public object GetParameterValue(object ParameterValue)
        {
            return DB.GetParameterValue(ParameterValue);
        }

        /// <summary>
        /// Retuns a generic list of primitive type whose content will be filled with the information from the Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oIDataReader"></param>
        /// <returns></returns>
        public List<T> GetPrimitiveList<T>(IDataReader oIDataReader = null) where T : IComparable
        {
            return DB.GetPrimitiveList<T>(oIDataReader);
        }

        /// <summary>
        /// Get a IDataReader based on the System.Data.CommandType and the given parameters
        /// </summary>
        /// <returns>System.Data.IDataReader</returns>
        public IDataReader GetReader()
        {
            return DB.GetReader();
        }

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the
        /// result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <returns>
        /// The first column of the first row in the result set, or a null reference if the result set is empty. 
        /// Returns a maximum of 2033 characters.
        /// </returns>
        public T GetScalar<T>()
        {
            return DB.GetScalar<T>();
        }

        /// <summary>
        /// Returns a System.Data.DataTable that describes the column metadata of the IDataReader
        /// </summary>
        /// <param name="oIDataReader"></param>
        /// <returns></returns>
        public List<string> GetSchema(IDataReader oIDataReader)
        {
            return DB.GetSchema(oIDataReader);
        }

        /// <summary>
        /// Gets the output of the parameter value
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="ParameterName">ParameterName</param>
        /// <returns>An System.Object that is the value of the parameter. The default value is null.</returns>
        public T GetValue<T>(string ParameterName)
        {
            return DB.GetValue<T>(ParameterName);
        }

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT)
        /// </summary>
        /// <param name="ParameterName">Parameter Name</param>
        /// <param name="ParameterValue">Parameter Value</param>    
        public void In(string ParameterName, object ParameterValue)
        {
            DB.In(ParameterName, ParameterValue);
        }

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT)
        /// </summary>
        /// <param name="ParameterName">Parameter Name</param>
        /// <param name="ParameterValue">Parameter Value</param>
        /// <param name="ParameterType">System.Data.SqlDbType</param>
        public void In(string ParameterName, object ParameterValue, SqlDbType ParameterType)
        {
            DB.In(ParameterName, ParameterValue, ParameterType);
        }

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (INPUT / OUTPUT)
        /// </summary>
        /// <param name="ParameterName">Parameter Name</param>
        /// <param name="ParameterValue">Parameter Value</param>
        public void InOut(string ParameterName, object ParameterValue)
        {
            DB.InOut(ParameterName, ParameterValue);
        }

        /// <summary>
        /// Check whether the Profiler is enabled or not to log the T-SQL Statements in a log file 
        /// </summary>
        public void IsProfilerEnabled()
        {
            DB.IsProfilerEnabled();
        }

        /// <summary>
        /// Logs the errors into the Database class
        /// </summary>
        /// <param name="oDataBaseManager">DataBaseManager</param>
        /// <param name="oDataBase">DataBase</param>
        /// <param name="Error">Exception</param>
        public void LogError(IDatabaseManager oDataBaseManager, IDatabaseContext oDataBase, Exception Error)
        {
            DB.LogError(oDataBaseManager, oDataBase, Error);
        }

        /// <summary>
        /// Returns an instance of the Business Entity Structured class whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="oIDataReader">IDataReader</param>
        /// <param name="IsUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>An instance of the Business Entity Structured class</returns>
        public T Map<T>(IDataReader oIDataReader = null, bool IsUsingNextResult = false) where T : BusinessEntityStructure
        {
            return DB.Map<T>(oIDataReader, IsUsingNextResult);
        }

        /// <summary>
        /// Adds the specified parameter object to the parameter collection (OUTPUT)
        /// </summary>
        /// <param name="ParameterName">Parameter Name</param>
        /// <param name="ParameterType">System.Data.DbType</param>
        /// <param name="ParameterValue">ParameterValue</param>     
        public void Out(string ParameterName, SqlDbType ParameterType, object ParameterValue = null)
        {
            DB.Out(ParameterName, ParameterType, ParameterValue);
        }

        /// <summary>
        /// Opens a database connection with the property settings specified in the ConnectionString.
        /// </summary>
        public void Prepare(IDatabaseContext oDataBase)
        {
            DB.Prepare(oDataBase);
        }

        /// <summary>
        /// Returns the T-SQL Statement that will be execute on the Database
        /// </summary>
        /// <returns>T-SQL Statement</returns>
        public string PreviewSQL()
        {
            return DB.PreviewSQL();
        }

        /// <summary>
        /// Closes the connection to the database. This is the preferred method of closing any open connection.
        /// Closes the command used to execute statements on the database
        /// </summary>
        public void Release()
        {
            DB.Release();
        }

        /// <summary>
        /// Configures the System.Data.CommandType and the T-SQL statement that will be executed on the Database
        /// </summary>
        /// <param name="CommandType">System.Data.CommandType</param>
        /// <param name="Statement">T-SQL Statement</param>
        public void Run(string Statement, CommandType CommandType = CommandType.StoredProcedure)
        {
            DB.Run(Statement, CommandType);
        }

        /// <summary>
        /// Sets the DataBaseManager to execute operations against the DataBase
        /// </summary>
        /// <param name="oDM">DataBaseManager</param>
        public void SetManager(IDatabaseManager oDM)
        {
            DB.SetManager(oDM);
        } 

        #endregion
    }
}
