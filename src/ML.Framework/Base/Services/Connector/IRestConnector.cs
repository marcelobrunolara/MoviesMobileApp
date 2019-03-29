using ML.Framework.Base.Services.Models;
using System.Threading.Tasks;

namespace ML.Framework.Base.Services.Connector.Interface
{
    public interface IRestConnector
    {
         Task<Result<string>> GetJson(string url);
         Task<Result<string>> PostJson(string url, string conteudo);
    }
}
