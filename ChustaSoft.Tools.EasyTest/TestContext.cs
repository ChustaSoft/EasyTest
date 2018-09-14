using System;
using System.Collections.Generic;
using System.Linq;


namespace ChustaSoft.Tools.EasyTest
{
    public class TestContext
    {

        private static TestContext _instance;

        private TestContext(TestConfiguration configuration)
        {
            RegisteredTests = configuration.Container();
        }

        public static TestContext Instance => GetInstance();
        
        private static TestContext GetInstance()
        {
            if (_instance == null)
            {
                var implementation = GetImplementedConfiguration();

                _instance = new TestContext(implementation);
            }

            return _instance;
        }

        public TestHelperBase<TService> TryGetHelper<TService>(Type type)
        {
            if (RegisteredTests.ContainsKey(type))
                return (TestHelperBase<TService>)RegisteredTests[type];

            throw new Exception("Test not registered");
        }

        private Dictionary<Type, object> RegisteredTests;

        private static TestConfiguration GetImplementedConfiguration()
        {
            var type = typeof(TestConfiguration);
            var implementation = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Single(p => type.IsAssignableFrom(p) && p.Name != type.Name);

            return (TestConfiguration)Activator.CreateInstance(implementation);
        }

    }
}
