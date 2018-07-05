using System;
using System.Collections.Generic;

namespace Framework.Data
{
    /// <summary>
    /// This interface defines the method's signatures to set the database connections and its behavior
    /// </summary>
    public interface IConnectionManager
    {
        #region| Methods | 

        /// <summary>
        /// Provides T-SQL statement execution in one or more databases
        /// This constructor will try to get the list of servers in the Framework.config file
        /// </summary>
        /// <returns></returns>
        IDatabaseManager Configure(bool LoadFromXML = false, ExecutionType ExecutionType = ExecutionType.ExecuteOnFirst);

        /// <summary>
        /// Provides T-SQL statement execution in the specific database
        /// using the default command timeout (30) seconds
        /// </summary>
        /// <param name="Connection">The string used to open the database.</param>
        /// <returns>DataBaseManager</returns>
        IDatabaseManager Configure(string Connection);


        /// <summary>
        /// Provides T-SQL statement execution in the specific databases
        /// </summary>
        /// <param name="Connection">The string used to open the database.</param>
        /// <param name="CommandTimeout">The time in seconds to wait for the command to execute.</param>
        /// <returns>DataBaseManager</returns>
        IDatabaseManager Configure(string Connection, int CommandTimeout);

        /// <summary>
        /// Provides T-SQL statement execution in the specific databases
        /// </summary>
        /// <param name="Connection">The string used to open the database.</param>
        /// <param name="CommandTimeout">The time in seconds to wait for the command to execute.</param>
        /// <param name="ExecutionType">ExecutionType</param>
        /// <returns>DataBaseManager</returns>
        IDatabaseManager Configure(string Connection, int CommandTimeout, ExecutionType ExecutionType);

        /// <summary>
        /// Provides T-SQL statement execution in one or more databases
        /// using the default command timeout (30) seconds.
        /// 
        /// The T-SQL statement will be executed in the first server of the list, 
        /// if it runs sucessfully, the execution stops and it will not be propagated to the remaining servers.
        /// Otherwise, the execution will continue
        /// </summary>
        /// <param name="Connections">The database connection string param array</param>
        /// <returns>DataBaseManager</returns>
        IDatabaseManager Configure(params string[] Connections);

        /// <summary>
        /// Provides T-SQL statement execution in one or more databases
        /// using the default command timeout (30) seconds.
        /// </summary>
        /// <param name="Connections">The database connection string param array</param>
        /// <param name="ExecutionType">
        ///     if the ExecutionType = ExecutionType.ExecuteOnFirst:
        ///         The T-SQL statement will be executed in the first server of the list, 
        ///         if it runs sucessfully, the execution stops and it will not be propagated to the remaining servers.
        ///         Otherwise, the execution will continue
        ///     
        ///     if the ExecutionType = ExecutionType.ExecuteOnAll:
        ///         The T-SQL statement will be executed in the all of the server of the list
        /// </param>
        /// <returns>DataBaseManager</returns>
        IDatabaseManager Configure(ExecutionType ExecutionType, params string[] Connections);

        /// <summary>
        /// Provides T-SQL statement execution in one or more databases
        /// </summary>
        /// <param name="ExecutionType">
        ///     if the ExecutionType = ExecutionType.ExecuteOnFirst:
        ///         The T-SQL statement will be executed in the first server of the list, 
        ///         if it runs sucessfully, the execution stops and it will not be propagated to the remaining servers.
        ///         Otherwise, the execution will continue
        ///     
        ///     if the ExecutionType = ExecutionType.ExecuteOnAll:
        ///         The T-SQL statement will be executed in the all of the server of the list
        /// </param>
        /// <param name="CommandTimeout">The time in seconds to wait for the command to execute.</param>
        /// <param name="Connections">The database connection string param array</param>
        /// <returns>DataBaseManager</returns>
        IDatabaseManager Configure(ExecutionType ExecutionType, int CommandTimeout, params string[] Connections);

        /// <summary>
        /// Provides T-SQL statement execution in one or more databases
        /// using the default command timeout (30) seconds.
        /// </summary>
        /// <param name="Connections">A database connection list</param>
        /// <returns>DataBaseManager</returns>
        IDatabaseManager Configure(List<string> Connections);

        /// <summary>
        /// Provides T-SQL statement execution in one or more databases
        /// using the default command timeout (30) seconds.
        /// </summary>
        /// <param name="Connections">A database connection list</param>
        /// <param name="ExecutionType">
        ///     if the ExecutionType = ExecutionType.ExecuteOnFirst:
        ///         The T-SQL statement will be executed in the first server of the list, 
        ///         if it runs sucessfully, the execution stops and it will not be propagated to the remaining servers.
        ///         Otherwise, the execution will continue
        ///     
        ///     if the ExecutionType = ExecutionType.ExecuteOnAll:
        ///         The T-SQL statement will be executed in the all of the server of the list
        /// </param> T-SQL statement will be executed in the all of the server of the list
        /// <returns>DataBaseManager</returns>
        IDatabaseManager Configure(ExecutionType ExecutionType, List<string> Connections);

        /// <summary>
        /// Provides T-SQL statement execution in one or more databases
        /// </summary>
        /// <param name="ExecutionType">
        ///     if the ExecutionType = ExecutionType.ExecuteOnFirst:
        ///         The T-SQL statement will be executed in the first server of the list, 
        ///         if it runs sucessfully, the execution stops and it will not be propagated to the remaining servers.
        ///         Otherwise, the execution will continue
        ///     
        ///     if the ExecutionType = ExecutionType.ExecuteOnAll:
        ///         The T-SQL statement will be executed in the all of the server of the list
        /// </param>
        /// <param name="CommandTimeout">The time in seconds to wait for the command to execute.</param>
        /// <param name="Connections">The database connection string param array</param>
        /// <returns>DataBaseManager</returns>
        IDatabaseManager Configure(ExecutionType ExecutionType, int CommandTimeout, List<string> Connections);

        /// <summary>
        /// Provides T-SQL statement execution in the databases
        /// This constructor will try to get the list of servers in the Framework.config file
        /// </summary>
        IDatabaseManager ConfigureFromXML(ExecutionType ExecutionType);

        /// <summary>
        /// Retuns an IEnumerable collections of ConnectionString
        /// </summary>
        /// <param name="Connections">Connections</param>
        /// <returns>IEnumerable</returns>
        IEnumerable<string> GetConnections(params string[] Connections);
      

        #endregion
    }
}
