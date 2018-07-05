using System;

namespace Framework.Data
{
    /// <summary>
    /// This class is in charge of apply dependency injection in the Data Layer
    /// </summary>
    public class ContainerDI
    {
        #region| Fields |

        /// <summary>
        /// Connection Manager
        /// </summary>
        public IConnectionManager connectionManager;

        /// <summary>
        /// Database Manager
        /// </summary>
        public IDatabaseManager databaseManager;

        /// <summary>
        /// Database Repository
        /// </summary>
        public readonly IDatabaseRepository databaseRepository;

        #endregion

        #region| Constructor |

        /// <summary>
        /// Default constructor for dependency injection
        /// </summary>
        /// <param name="_connectionManager">_connectionManager</param>
        /// <param name="_databaseManager"></param>
        /// <param name="_databaseRepository"></param>
        public ContainerDI(IConnectionManager _connectionManager, IDatabaseManager _databaseManager, IDatabaseRepository _databaseRepository)
        {
            connectionManager  = _connectionManager;
            databaseRepository = _databaseRepository;
            databaseManager    = _databaseManager;
        } 

        #endregion
    }
}
