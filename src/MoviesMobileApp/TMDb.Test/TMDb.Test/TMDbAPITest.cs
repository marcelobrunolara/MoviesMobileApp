using ML.Framework.Base.IoC;
using ML.Framework.Base.Services.Connector;
using ML.Framework.Base.Services.Connector.Interface;
using NUnit.Framework;

namespace TMDb.Test
{
    public class TMDbAPITest
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
        public void IoCFeatureTest()
        {
            Assert.AreEqual(_connector.GetType(), typeof(IRestConnector));           
        }

        [Test]
        public void ServiceConnectionTest()
        {
            var url = string.Concat(Constants.ApiBaseURL, Constants.ImageConfigurationsResource);
            url = string.Format(url, Constants.API_KEY);
            var result = _connector.GetJson(url).Result;

            Assert.AreEqual(result.IsValid, true);
        }
    }
}