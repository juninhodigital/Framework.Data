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
