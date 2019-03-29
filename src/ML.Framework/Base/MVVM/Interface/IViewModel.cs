namespace ML.Framework.Base.MVVM.Interface
{
    public interface IViewModel
    {
        IPageProxy PageProxy { get; }
        void ExecuteBeforeBinding();
    }
}
