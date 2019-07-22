using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.Resolution;

namespace Ego.Infrastructure
{
    /// <summary>
    /// Represents the Service Locator.
    /// </summary>
    public sealed class ServiceLocator : IServiceProvider
    {
        #region Private Fields
        private readonly IUnityContainer container;
        #endregion

        #region Private Static Fields
        private static readonly ServiceLocator instance = new ServiceLocator();
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of <c>ServiceLocator</c> class.
        /// </summary>
        private ServiceLocator()
        {
            ////根据文件名获取指定config文件
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"Config/Unity.config";
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
            container = new UnityContainer();
            unitySection.Configure(container);

        }
        #endregion

        #region Public Static Properties
        /// <summary>
        /// Gets the singleton instance of the <c>ServiceLocator</c> class.
        /// </summary>
        public static ServiceLocator Instance
        {
            get { return instance; }
        }
        #endregion

        #region Private Methods
        private IEnumerable<ParameterOverride> GetParameterOverrides(Dictionary<string, object> dic)
        {
            List<ParameterOverride> overrides = new List<ParameterOverride>();

            foreach (KeyValuePair<string, object> item in dic)
            {
                overrides.Add(new ParameterOverride(item.Key, item.Value));
            }

            return overrides;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the service instance with the given type.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        /// <returns>The service instance.</returns>
        public T GetService<T>()
        {
            return container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return container.ResolveAll<T>();
        }
        /// <summary>
        /// Gets the service instance with the given type by using the overrided arguments.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        /// <param name="overridedArguments">The overrided arguments.</param>
        /// <returns>The service instance.</returns>
        public T GetService<T>(Dictionary<string, object> dic)
        {
            return container.Resolve<T>(GetParameterOverrides(dic).ToArray());
        }
        /// <summary>
        /// Gets the service instance with the given type by using the overrided arguments.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <param name="overridedArguments">The overrided arguments.</param>
        /// <returns>The service instance.</returns>
        public object GetService(Type serviceType, Dictionary<string, object> dic)
        {
            return container.Resolve(serviceType, GetParameterOverrides(dic).ToArray());
        }
        #endregion

        #region IServiceProvider Members
        /// <summary>
        /// Gets the service instance with the given type.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <returns>The service instance.</returns>
        public object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        #endregion
    }
}
