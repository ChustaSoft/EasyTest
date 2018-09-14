namespace ChustaSoft.Tools.EasyTest
{
    public abstract class TestHelperBase<T>
    {

        public void SetupTestInitialData()
        {
            var applicationService = MockUpService();

            CreateStartData(applicationService);
        }


        public abstract T MockUpService();

        public abstract void CleanUpMockService(T testService);


        protected abstract void CreateStartData(T testService);

    }
}
