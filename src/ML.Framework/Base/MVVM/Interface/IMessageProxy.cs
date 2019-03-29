using System.Threading.Tasks;

namespace ML.Framework.Base.MVVM.Interface
{
    public interface IMessageProxy
    {
        Task<string> ShowActionSheet(string title, string cancel, params string[] options);

        Task ShowAlert(string title, string message, string cancel);

        Task<bool> ShowAlert(string title, string message, string accept, string cancel);
    }
}
