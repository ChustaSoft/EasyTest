using System;


namespace ChustaSoft.Tools.EasyTest
{
    public static class TestServiceManager
    {

        public static void GenerateMockUpService<TService>(Type type)
        {
            var helper = GetHelper<TService>(type);

            helper.SetupTestInitialData();
        }

        public static TService RefreshService<TService>(Type type)
        {
            var helper = GetHelper<TService>(type);

            return helper.MockUpService();
        }

        public static void CleanUpService<TService>(Type type, TService service)
        {
            var helper = GetHelper<TService>(type);

            helper.CleanUpMockService(service);
        }

        private static TestHelperBase<TService> GetHelper<TService>(Type type) => TestContext.Instance.TryGetHelper<TService>(type);

    }
}
