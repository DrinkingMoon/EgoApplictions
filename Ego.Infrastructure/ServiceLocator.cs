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
        private readonly IUnityContainer _container;
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
            _container = new UnityContainer();
            unitySection.Configure(_container);

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
        private IEnumerable<ParameterOverride> GetParameterOverrides(params KeyValuePair<string,object>[] keyValuePairs)
        {
            List<ParameterOverride> overrides = new List<ParameterOverride>();

            foreach (KeyValuePair<string, object> item in keyValuePairs)
            {
                overrides.Add(new ParameterOverride(item.Key, item.Value));
            }

            return overrides;
        }
        #endregion

        #region Public Methods
        public T GetService<T>()
        {
            return _container.Resolve<T>();
        }
        public T GetService<T>(string name)
        {
            return _container.Resolve<T>(name, null);
        }
        public T GetService<T>(params KeyValuePair<string, object>[] keyValuePairs)
        {
            return _container.Resolve<T>(GetParameterOverrides(keyValuePairs).ToArray());
        }
        public T GetService<T>(string name = null, params KeyValuePair<string, object>[] keyValuePairs)
        {
            return _container.Resolve<T>(name, GetParameterOverrides(keyValuePairs).ToArray());
        }
        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.ResolveAll<T>();
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
            return _container.Resolve(serviceType);
        }

        #endregion
    }
}
