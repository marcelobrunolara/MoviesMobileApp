namespace ML.Framework.Base.Servicos.Conector
{
    public class URLHelper
    {
        public static string MakeURL(string urlBase, string urlResource, params object[] args)
        {
            var url = string.Concat(urlBase, urlResource);
            var urlArgs = string.Format(url, args);
            return urlArgs;
        }
    }
}
