using ML.Framework.Base.IoC;
using ML.Framework.Base.Servicos.Conector;
using ML.Framework.Base.Servicos.Conector.Interface;
using NUnit.Framework;
using Newtonsoft.Json;
using MoviesMobileApp.Services.Models.MovieDb;

namespace TMDb.Test.Services
{
    public class ImageConfigurationsServiceTest
    {
        private IRestConnector _connector;

        #region Setup

        [SetUp]
        public void Setup()
        {
            RegisterContainer();
            SetConnectorInstance();
        }

        private void RegisterContainer()
        {
            IoCHelper.Container.Register<IRestConnector, RestConnector>();
        }

        private void SetConnectorInstance()
        {
            _connector = IoCHelper.Container.GetInstance<IRestConnector>();
        }

        #endregion

        [Test]
        public void GetConfigurationTest()
        {
            var url = string.Concat(Constants.ApiBaseURL, Constants.ImageConfigurationsResource);
            url = string.Format(url, Constants.API_KEY);
            var result = _connector.GetJson(url).Result;             
            var configurationModel = JsonConvert.DeserializeObject<ConfigurationModel>(result.Content);

            Assert.AreNotEqual(configurationModel, null);
        }
    }
}
