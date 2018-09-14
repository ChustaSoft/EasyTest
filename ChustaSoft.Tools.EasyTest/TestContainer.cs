using System;
using System.Collections.Generic;


namespace ChustaSoft.Tools.EasyTest
{
    public class TestContainer
    {

        internal Dictionary<Type, object> RegisteredContext = new Dictionary<Type, object>();


        public void ResolveTestContext<TDto, THelper>()
        {
            var implementedHelper = Activator.CreateInstance(typeof(THelper));

            RegisteredContext.Add(typeof(TDto), implementedHelper);
        }

    }
}