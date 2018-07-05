using System;

namespace Framework.Data
{
    /// <summary>
    /// Handles Database Connection and sets the time in seconds to wait for the command to execute
    /// </summary>
    [Serializable]
    public abstract class DatabaseContext : IDatabaseContext, IDisposable
    {
        #region| Fields |

        /// <summary>
        /// TESTE
        /// </summary>
        public bool hasError = false;

        #endregion

        #region| Properties |

        /// <summary>
        ///  Gets or sets the user ID to be used when connecting to the database.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Gets or sets the password for the database account.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the name of the database associated with the connection.
        /// </summary>
        public string InitialCatalog { get; set; }

        /// <summary>
        ///  Gets or sets the string used to open the database.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name or network address of the instance of the database to connect to.
        /// </summary>
        public string DataSource { get; set; }

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

        /// <summary>
        /// Gets a message that describes the current exception
        /// </summary>
        public bool HasError { get; set; } 

        #endregion

        #region| Constructor |

        /// <summary>
        /// DataBaseManager default constructor
        /// </summary>
        public DatabaseContext() : this(string.Empty, null)
        {
        }

        /// <summary>
        /// DataBaseManager constructor used to set the Command Timeout
        /// </summary>
        /// <param name="CommandTimeout">The time in seconds to wait for the command to execute. The default is 30 seconds (if null).</param>
        public DatabaseContext(int? CommandTimeout) : this(string.Empty, CommandTimeout)
        {
        }

        /// <summary>
        /// DataBaseManager constructor used to set the ConnectionString
        /// </summary>
        /// <param name="ConnectionString">The string used to open the database.</param>
        public DatabaseContext(string ConnectionString) : this(ConnectionString, null)
        {
        }

        /// <summary>
        /// DataBaseManager constructor used to set the if the Transaction will be used by the application and the ConnectionString and the CommandTimeout
        /// </summary>
        /// <param name="ConnectionString">The string used to open the database.</param>
        /// <param name="CommandTimeout">The time in seconds to wait for the command to execute. The default is 30 seconds (if null).</param>
        public DatabaseContext(string ConnectionString, int? CommandTimeout)
        {
            BuildConnectionString(ConnectionString, CommandTimeout);         
        }

        #endregion

        #region| Methods

        /// <summary>
        /// DataBaseManager constructor used to set the if the Transaction will be used by the application and the ConnectionString and the CommandTimeout
        /// </summary>
        /// <param name="ConnectionString">The string used to open the database.</param>
        /// <param name="CommandTimeout">The time in seconds to wait for the command to execute. The default is 30 seconds (if null).</param>
        abstract public void BuildConnectionString(string ConnectionString, int? CommandTimeout);      

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