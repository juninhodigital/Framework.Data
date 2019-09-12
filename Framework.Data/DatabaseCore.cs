﻿using System;
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
        /// Fill the property value of the Business Entity Structured Class with the information in the IDataReader
        /// </summary>
        /// <param name="dataReader">IDataReader</param>
        /// <param name="sender">Class derived from the Framework.Entity.BussinessEntityStructure class</param>
        /// <param name="type">Type of Sender</param>
        /// <param name="typeName">Gets the name of the current member.</param>
        /// <param name="schema">List of the columns avaiable in the IDataReader</param>
        /// <param name="mustRaiseException">Indicates whether an exception will be throw in case of failure</param>
        public void BindList<T>(IDataReader dataReader, T sender, Type type, string typeName, HashSet<string> schema, bool mustRaiseException) where T : BusinessEntityStructure
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
        /// <returns>The number of rows affected</returns>
        public int Execute()
        {
            return databaseRepository.Execute();
        }

        /// <summary>
        ///  Adds or refreshes rows in a specified range in the System.Data.DataSet to match those in the data source using the System.Data.DataTable name.
        /// </summary>
        /// <returns>System.Data.DataTable</returns>
        public DataTable GetDataTable()
        {
            return databaseRepository.GetDataTable();
        }

        /// <summary>
        /// Adds or refreshes rows in the System.Data.DataSet.
        /// </summary>
        /// <returns>System.Data.DataSet</returns>
        public DataSet GetDataSet()
        {
            return databaseRepository.GetDataSet();
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
        /// <param name="dataReader">IDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        public IEnumerable<T> GetListOptimized<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new()
        {
            return databaseRepository.GetListOptimized<T>(dataReader, isUsingNextResult);
        }

        /// <summary>
        /// Returns a generic collection list with instances of the Business Entity Structured class 
        /// whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="dataReader">IDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>Generic Collection List</returns>
        public IEnumerable<T> GetList<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new()
        {
            return databaseRepository.GetList<T>(dataReader, isUsingNextResult);
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
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public List<T> GetPrimitiveList<T>(IDataReader dataReader = null) where T : IComparable, new()
        {
            return databaseRepository.GetPrimitiveList<T>(dataReader);
        }

        /// <summary>
        /// Get a IDataReader based on the System.Data.CommandType and the given parameters
        /// </summary>
        /// <returns>System.mData.IDataReader</returns>
        public SqlDataReader GetReader()
        {
            return databaseRepository.GetReader();
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
            return databaseRepository.GetScalar<T>();
        }

        /// <summary>
        /// Returns a System.Data.DataTable that describes the column metadata of the IDataReader
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public HashSet<string> GetSchema(IDataReader dataReader)
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
        public void InOut(string parameterName, object parameterValue)
        {
            databaseRepository.InOut(parameterName, parameterValue);
        }

        /// <summary>
        /// Check whether the Profiler is enabled or not to log the T-SQL Statements in a log file 
        /// </summary>
        public void IsProfilerEnabled()
        {
            databaseRepository.IsProfilerEnabled();
        }

        /// <summary>
        /// Returns an instance of the Business Entity Structured class whose properties will be filled with the information from the Database
        /// </summary>
        /// <param name="dataReader">IDataReader</param>
        /// <param name="isUsingNextResult">Indicates if is using multiple resultsets</param>
        /// <returns>An instance of the Business Entity Structured class</returns>
        public T Map<T>(SqlDataReader dataReader = null, bool isUsingNextResult = false) where T : BusinessEntityStructure, new()
        {
            return databaseRepository.Map<T>(dataReader, isUsingNextResult);
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
        /// Returns the T-SQL Statement that will be execute on the Database
        /// </summary>
        /// <returns>T-SQL Statement</returns>
        public string PreviewSQL()
        {
            return databaseRepository.PreviewSQL();
        }

        /// <summary>
        /// Closes the connection to the database. This is the preferred method of closing any open connection.
        /// Closes the command used to execute statements on the database
        /// </summary>
        public void Release()
        {
            databaseRepository.Release();
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
