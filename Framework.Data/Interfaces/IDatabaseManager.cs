using System;
using System.Collections.Generic;

namespace Framework.Data
{
    /// <summary>
    /// Interface that set the method's signature used by the database manager
    /// </summary>
    public interface IDatabaseManager: IDisposable
    {
        #region| Properties |

        /// <summary>
        ///  Gets or sets the Database Collection in which commands will be executed
        /// </summary>
        List<IDatabaseContext> Databases { get; set; }

        /// <summary>
        /// Indicates the Execution Type for DML operations
        /// </summary>
        ExecutionType ExecutionType { get; set; }

        /// <summary>
        /// Indicates if an error ocurred
        /// </summary>
        bool HasError { get; set; }

        /// <summary>
        /// Indicates if an error ocurred on all DataBase Collection
        /// </summary>
        bool HasErrorOnAll { get; set; }

        /// <summary>
        /// Gets a message that describes the current exception
        /// </summary>
        string ErrorMessage { get; set; } 

        #endregion

    }
}
