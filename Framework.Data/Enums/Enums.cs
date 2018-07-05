using System;

namespace Framework.Data
{
    /// <summary>
    /// Indicates the Execution Type for DML operations
    /// </summary>
    public enum ExecutionType
    {
        /// <summary>
        /// Executes T-SQL statements for Insert, Update, Delete operations in all Database Collection
        /// </summary>
        ExecuteOnAll,

        /// <summary>
        /// Executes T-SQL statements in the first Database, if an error occurs the execution goes to the next Database available
        /// It can be used for all T-SQL statement
        /// </summary>
        ExecuteOnFirst

    }
}
