using System;
using System.Collections.Generic;
using System.Text;

namespace ML.Framework.Base.IoC
{
    public interface IContainer
    {
        bool ContainerWasInitialized { get; }
        void Register<TInterface, TImplementacao>() where TInterface : class
                where TImplementacao : class, TInterface;
        void RegisterASingleton<TInterface, TImplementacao>() where TInterface : class
        where TImplementacao : class, TInterface;
        TInterface GetInstance<TInterface>() where TInterface : class;
    }
}
