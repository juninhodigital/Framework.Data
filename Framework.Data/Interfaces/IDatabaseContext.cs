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
        ///  Gets or sets the user ID to be used when connecting to the database
        /// </summary>
        string UserID { get; set; }

        /// <summary>
        /// Gets or sets the password for the database account.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the name of the database associated with the connection.
        /// </summary>
        string InitialCatalog { get; set; }

        /// <summary>
        ///  Gets or sets the string used to open the database.
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name or network address of the instance of the database to connect to.
        /// </summary>
        string DataSource { get; set; }

        /// <summary>
        /// Gets or sets the time in seconds to wait for the command to execute. The default is 30 seconds.
        /// </summary>
        int? CommandTimeout { get; set; }

        /// <summary>
        /// Gets or sets the length of time (in seconds) to wait for a connection to 
        /// the server before terminating the attempt and generating an error.
        /// </summary>
        ///<remarks>
        /// Gets the value of the ConnectTimeout property, or 15 seconds if no value has been supplied.
        ///</remarks>
        int? ConnectTimeout { get; set; }

        /// <summary>
        /// Indicates if an error ocurred
        /// </summary>
        bool HasError { get; set; }

        #endregion

        #region| Methods |

        /// <summary>
        /// DataBaseManager constructor used to set the if the Transaction will be used by the application and the ConnectionString and the CommandTimeout
        /// </summary>
        /// <param name="ConnectionString">The string used to open the database.</param>
        /// <param name="CommandTimeout">The time in seconds to wait for the command to execute. The default is 30 seconds (if null).</param>
        void BuildConnectionString(string ConnectionString, int? CommandTimeout);

        #endregion        
    }
}
