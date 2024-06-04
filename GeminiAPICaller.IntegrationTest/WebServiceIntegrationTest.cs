using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace GeminiAPICaller.IntegrationTest
{
    public class WebServiceIntegrationTest : IClassFixture<WebApplicationFactory<GeminiAPICaller.WebService.Program>>
    {

        private readonly WebApplicationFactory<GeminiAPICaller.WebService.Program> _factory = new WebApplicationFactory<GeminiAPICaller.WebService.Program>();

        private HttpClient _httpClient;
        private HttpResponseMessage _response;

       /* public WebServiceIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }*/


        [Fact]
        public async Task Test_Gemini_API()
        {
            string context = "Je vais te donner des informations concernant une annonce immobilière, je vais te donner la ville, le code postal, le prix, le nombre de mètres carrés, le type à savoir si une maison appartement ou terrain et la description de l'annonce, je veux que tu me donnes comme information le nombre d'habitants dans la ville, le est-ce qu'il y a des commerces dans la ville ( Boulangerie,boucher, Poste, Supermarché). Si non,donne moi la ville la plus proche avec ces commerces.Je veux que tu me dises si il y a une école primaire sinon la ville la plus proche avec l'école primaire et le temps pour y aller en te basant sur la ville donné.Je veux que tu me dises si il y a un collège sinon la ville la plus proche avec un collège et le temps pour y aller en te basant sur la ville donné.Je veux que tu me dises si il y a un lycée sinon la ville la plus proche avec un lycée et le temps pour y aller en te basant sur la ville donné.Si la ville possède une gare Si non, la ville la plus proche avec une gare  et le temps pour y aller en te basant sur la ville donné.";
            string informations = "amberieu en bugey/01/189900/95/Maison/A 15 mn de Ambérieu en Bugey en direction de Meximieux sur la commune de Saint Maurice de Rémens. Agréable maison de village comprenant 3 chambres ainsi qu'une mezzanine, une buanderie et un garage. Vous apprécierez également la proximité de l'école primaires, accessible en quelques minutes à pied garantissant un quotidien simplifié pour vos enfants. Pour les amoureux de la nature, plusieurs parcs et forêts sont à découvrir aux alentours, promettant de belles escapades en plein air.";
            string url = "https://localhost:7061/WebService/GeminiAPI";

            _factory.Dispose();
            _httpClient = _factory.CreateClient();

            UriBuilder uriBuilder = new UriBuilder(url);
            var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
            query["informations"] = informations;
            query["context"] = context;
            uriBuilder.Query = query.ToString();

            // Envoyer la requête GET
            try
            {
                _response = await _httpClient.GetAsync(uriBuilder.ToString());
            }
            catch
            {
                
            }

            Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
        }
    }
}