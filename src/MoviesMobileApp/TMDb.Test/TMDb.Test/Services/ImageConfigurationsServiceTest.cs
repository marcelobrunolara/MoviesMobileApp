using ML.Framework.Base.IoC;
using ML.Framework.Base.Services.Connector;
using ML.Framework.Base.Services.Connector.Interface;
using NUnit.Framework;
using Newtonsoft.Json;
using MoviesMobileApp.Services.Models.MovieDb;
using ML.Framework.Base.Services.Models;
using System;
using System.Net;

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

            if (result.IsValid)
            {
                var configurationModel = JsonConvert.DeserializeObject<ConfigurationModel>(result.Content);
                Assert.AreEqual(configurationModel.GetType(), typeof(ConfigurationModel));
            }
            if (result.HttpStatusCode is (int)HttpStatusCode.Unauthorized ||
                result.HttpStatusCode is (int)HttpStatusCode.NotFound)
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(result.Content);
                Assert.AreEqual(errorModel.GetType(), typeof(ErrorModel));
            }

        }

    }
}
