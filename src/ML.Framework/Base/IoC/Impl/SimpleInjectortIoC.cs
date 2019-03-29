using SIContainer = SimpleInjector.Container;

namespace ML.Framework.Base.IoC
{
    public class SimpleInjectortIoC : Container
    {
        private SIContainer _siContainer;
        public static SimpleInjectortIoC Instance { get; } = new SimpleInjectortIoC();
        public override bool ContainerWasInitialized { get => _siContainer != null; }

        protected SimpleInjectortIoC() : base()
        {

        }

        protected override void InitializeContainer()
        {
            if (_siContainer is null)
                _siContainer = new SIContainer();
        }

        public override Interface GetInstance<Interface>()
        {
            return _siContainer.GetInstance<Interface>();
        }

        public  override void Register<Interface, Implementacao>()
        {
            _siContainer.Register<Interface, Implementacao>();
        }

        public override void RegisterASingleton<Interface, Implementacao>()
        {
            _siContainer.RegisterSingleton<Interface, Implementacao>();
        }

    }

}
