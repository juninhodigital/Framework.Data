using System;

namespace Framework.Data
{
    /// <summary>
    /// This class is a gateway to the data access layer
    /// </summary>
    /// <typeparam name="TDatabaseCore"></typeparam>
    public abstract class DatabaseHub<TDatabaseCore> where TDatabaseCore : DatabaseCore, IDisposable
    {
        #region| Properties |

        /// <summary>
        /// It provides core database services
        /// </summary>
        protected TDatabaseCore DAL = null;

        #endregion

        #region| Constructor |

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="DI"></param>
        public DatabaseHub(ContainerDI DI)
        {
            DAL = Activator.CreateInstance(typeof(TDatabaseCore), new object[] { DI }) as TDatabaseCore;
        }

        #endregion

        #region| IDisposable Members |

        /// <summary>
        ///  IDisposable implementation
        /// </summary>
        public void Dispose()
        {
            DAL.Dispose();

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
