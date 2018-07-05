using System;
using System.Collections.Generic;

using Framework.Core;

namespace Framework.Data
{
    /// <summary>
    /// Handles Datababases Connections and operations
    /// </summary>
    [Serializable]
    public abstract class DataBaseManager: IDatabaseManager, IDisposable 
    {
        #region| Fields |

        /// <summary>
        /// Indicates if an error ocurred
        /// </summary>
        public bool hasError       = false;

        /// <summary>
        /// Indicates if an error ocurred on all DataBase Collection
        /// </summary>
        public bool hasErrorOnAll  = false;

        /// <summary>
        /// Gets a message that describes the current exception
        /// </summary>
        public string errorMessage = string.Empty;

        #endregion

        #region| Properties |

        /// <summary>
        ///  Gets or sets the Database Collection in which commands will be executed
        /// </summary>
        public List<IDatabaseContext> Databases { get; set; }

        /// <summary>
        /// Indicates the Execution Type for DML operations
        /// </summary>
        public ExecutionType ExecutionType { get; set; }

        /// <summary>
        /// Indicates if an error ocurred
        /// </summary>
        public bool HasError { get; set; }
    

        /// <summary>
        /// Indicates if an error ocurred on all DataBase Collection
        /// </summary>
        public bool HasErrorOnAll { get; set; }
     

        /// <summary>
        /// Gets a message that describes the current exception
        /// </summary>
        public string ErrorMessage { get; set; }

        #endregion

        #region| Constructor |

        /// <summary>
        /// Provides T-SQL statement execution in a specified Database
        /// </summary>
        public DataBaseManager()
        {

        }

        /// <summary>
        /// Provides T-SQL statement execution in a specified Database
        /// </summary>
        /// <param name="ExecutionType">ExecutionType</param>
        protected DataBaseManager(ExecutionType ExecutionType)
        {
            this.ExecutionType = ExecutionType;
            this.Databases     = new List<IDatabaseContext>();
        }

        /// <summary>
        /// Provides T-SQL statement execution in a specified Database
        /// </summary>
        /// <param name="oDataBase">DataBase</param>
        /// <param name="ExecutionType">ExecutionType</param>
        protected DataBaseManager(IDatabaseContext oDataBase, ExecutionType ExecutionType)
        {
            this.Databases = new List<IDatabaseContext>();

            if (oDataBase.IsNull())
            {
                throw new ArgumentNullException("Framework: The DatabaseContext cannot be null");
            }
            else
            {
                this.Databases.Add(oDataBase);
                this.ExecutionType = ExecutionType;
            }
        }

        /// <summary>
        /// Provides T-SQL statement execution in one or more Databases
        /// </summary>
        /// <param name="oDataBases">List of DataBases</param>
        /// <param name="ExecutionType">ExecutionType</param>
        protected DataBaseManager(List<IDatabaseContext> oDataBases, ExecutionType ExecutionType)
        {
            if (oDataBases.IsNull())
            {
                throw new Exception("Framework: The DatabaseContext list cannot be null.");
            }
            else
            {
                this.Databases = oDataBases;
                this.ExecutionType = ExecutionType;
            }
        }

        #endregion

        #region| Destructor |

        /// <summary>
        /// Default destructor
        /// </summary>
        ~DataBaseManager()
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
            if (Databases.IsNotNull())
            {
                this.Databases.Clear();
            }

            GC.SuppressFinalize(this);
        }

        #endregion        
    }
}
