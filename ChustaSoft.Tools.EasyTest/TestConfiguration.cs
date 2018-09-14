using System;
using System.Collections.Generic;


namespace ChustaSoft.Tools.EasyTest
{
    public abstract class TestConfiguration
    {

        internal Dictionary<Type, object> Container()
        {
            var container = new TestContainer();

            Configure(container);

            return container.RegisteredContext;
        }


        public abstract void Configure(TestContainer container);

    }
}
