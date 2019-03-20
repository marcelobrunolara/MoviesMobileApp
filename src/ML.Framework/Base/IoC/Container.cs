using System;
using System.Collections.Generic;
using System.Text;

namespace ML.Framework.Base.IoC
{
    public abstract class Container : IContainer 
    {
        public virtual bool ContainerWasInitialized { get => throw new NotImplementedException(); }

        public Container()
        {
            InitializeContainer();
        }

        protected virtual void InitializeContainer()
        {
            throw new NotImplementedException();
        }
        public virtual TInterface GetInstance<TInterface>() where TInterface : class
        {
            throw new NotImplementedException();
        }

        public virtual void Register<TInterface, TImplementacao>() where TInterface : class
                where TImplementacao : class, TInterface
        {
            throw new NotImplementedException();
        }

        public virtual void RegisterASingleton<TInterface, TImplementacao>() where TInterface : class
        where TImplementacao : class, TInterface
        {
            throw new NotImplementedException();
        }
    }
}
