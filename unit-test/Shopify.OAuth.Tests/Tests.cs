using System;
using System.Web;
using Xunit;

namespace Shopify.OAuth.Tests
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            
            var config = new Teference.Shopify.Api.OAuthConfiguration();
            
            var request = new HttpRequest("", "https://open.inkfrog.com/services/shopify/", "code=ea0a5fe4ee80f975b0288c3741e3b305&hmac=3ef212c86a487779f46aeea95561bfc963341b1de53ab41846359878c94dd252&host=c3Rlc2hvd3RpbWUubXlzaG9waWZ5LmNvbS9hZG1pbg&shop=steshowtime.myshopify.com&timestamp=1618591179");
            var shopifySecret = "{your secret here}";// 

            // config.ApiKey = ConfigurationManager.AppSettings("ShopifyAPIConsumerSecret")
            config.SecretKey = shopifySecret;
            
            var client = new Teference.Shopify.Api.ShopifyOAuth(config);

            var state= client.AuthorizeClient(request.QueryString);
                
            Assert.True(state.IsSuccess);
            Assert.False(string.IsNullOrWhiteSpace(state.AccessToken));

        }
    }
}