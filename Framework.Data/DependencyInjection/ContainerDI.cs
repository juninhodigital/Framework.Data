using System;
using System.Diagnostics;

namespace Framework.Data
{
    /// <summary>
    /// This class is in charge of apply dependency injection in the Data Layer
    /// </summary>
    /// <remarks>
    /// https://blogs.msdn.microsoft.com/jaredpar/2011/03/18/debuggerdisplay-attribute-best-practices/
    /// </remarks>
    [DebuggerDisplay("{DebuggerDisplayInfo,nq}")]
    public class ContainerDI
    {
        #region| Properties |

        /// <summary>
        /// Database Context
        /// </summary>
        public IDatabaseContext DatabaseContext
        {
            get; private set;
        }

        /// <summary>
        /// Database Repository
        /// </summary>
        public readonly IDatabaseRepository DatabaseRepository;

        /// <summary>
        /// Debugger display information
        /// </summary>
        private string DebuggerDisplayInfo
        {
            get
            {
                return string.Format("Connection: {0}, timeout: {1}", DatabaseContext.ConnectionString, DatabaseContext.CommandTimeout);
            }
        }

        #endregion

        #region| Constructor |

        /// <summary>
        /// Default constructor for dependency injection
        /// </summary>
        /// <param name="_databaseManager"></param>
        /// <param name="databaseRepository"></param>
        public ContainerDI(IDatabaseContext databaseContext, IDatabaseRepository databaseRepository)
        {
            DatabaseRepository = databaseRepository;
            DatabaseContext    = databaseContext;
        }

        #endregion

    }
}
