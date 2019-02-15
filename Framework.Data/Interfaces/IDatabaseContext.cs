using System;

namespace Framework.Data
{
    /// <summary>
    /// Interface for database context used to set up the conection, command timeout, execution timeout, etc;
    /// </summary>
    public interface IDatabaseContext
    {
        #region| Properties |

        /// <summary>
        ///  Gets or sets the string used to open the database.
        /// </summary>
        string ConnectionString { get; set; }


        /// <summary>
        /// Gets or sets the time in seconds to wait for the command to execute. The default is 30 seconds.
        /// </summary>
        int? CommandTimeout { get; set; }

        #endregion

        #region| Methods |

        /// <summary>
        /// DataBaseManager constructor used to set the if the Transaction will be used by the application and the ConnectionString and the CommandTimeout
        /// </summary>
        /// <param name="connectionString">The string used to open the database.</param>
        /// <param name="commandTimeout">The time in seconds to wait for the command to execute. The default is 30 seconds (if null).</param>
        /// <param name="connectionTimeout"> The value of the System.Data.SqlClient.SqlConnectionStringBuilder.ConnectTimeout property, or 15 seconds if no value has been supplied.</param>
        void BuildConnectionString(string connectionString, int? commandTimeout, int? connectionTimeout);

        #endregion        
    }
}
