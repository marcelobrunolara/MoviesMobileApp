using ML.Framework.Base.Servicos.Models;
using System.Threading.Tasks;

namespace ML.Framework.Base.Servicos.Conector.Interface
{
    public interface IRestConnector
    {
         Task<Result<string>> GetJson(string url);
         Task<Result<string>> PostJson(string url, string conteudo);
    }
}
