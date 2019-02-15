using System;

namespace Framework.Data
{
    /// <summary>
    /// Handles Database Connection and sets the time in seconds to wait for the command to execute
    /// </summary>
    [Serializable]
    public abstract class DatabaseContext : IDatabaseContext, IDisposable
    {
        #region| Properties |

        /// <summary>
        ///  Gets or sets the string used to open the database.
        /// </summary>
        public string ConnectionString { get; set; }
   
        /// <summary>
        /// Gets or sets the time in seconds to wait for the command to execute. The default is 30 seconds.
        /// </summary>
        public int? CommandTimeout { get; set; }

        /// <summary>
        /// Gets or sets the length of time (in seconds) to wait for a connection to 
        /// the server before terminating the attempt and generating an error.
        /// </summary>
        ///<remarks>
        /// Gets the value of the ConnectTimeout property, or 15 seconds if no value has been supplied.
        ///</remarks>
        public int? ConnectTimeout { get; set; }

        #endregion

        #region| Constructor |

        /// <summary>
        /// DataBaseManager constructor used to set the if the Transaction will be used by the application and the ConnectionString and the CommandTimeout
        /// </summary>
        /// <param name="connectionString">The string used to open the database.</param>
        /// <param name="commandTimeout">The time in seconds to wait for the command to execute. The default is 30 seconds (if null).</param>
        /// <param name="connectionTimeout"> The value of the System.Data.SqlClient.SqlConnectionStringBuilder.ConnectTimeout property, or 15 seconds if no value has been supplied.</param>
        public DatabaseContext(string connectionString, int? commandTimeout, int? connectionTimeout)
        {
            BuildConnectionString(connectionString, commandTimeout, connectionTimeout);         
        }

        #endregion

        #region| Methods |

        /// <summary>
        /// DataBaseManager constructor used to set the if the Transaction will be used by the application and the ConnectionString and the CommandTimeout
        /// </summary>
        /// <param name="connectionString">The string used to open the database.</param>
        /// <param name="commandTimeout">The time in seconds to wait for the command to execute. The default is 30 seconds (if null).</param>
        /// <param name="connectionTimeout"> The value of the System.Data.SqlClient.SqlConnectionStringBuilder.ConnectTimeout property, or 15 seconds if no value has been supplied.</param>
        abstract public void BuildConnectionString(string connectionString, int? commandTimeout, int? connectionTimeout);      

        #endregion

        #region| Destructor |

        /// <summary>
        /// Default destructor
        /// </summary>
        ~DatabaseContext()
        {
            this.Dispose();
        }

        #endregion

        #region| IDisposable Members |

        /// <summary>
        /// Release allocated resources
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion       
    }
}