using GeminiAPICaller.Model;
using GeminiAPICaller.Model.Message.Prompt;
using GeminiAPICaller.Model.Response.Prompt;
using System.IO;
using System.Runtime.CompilerServices;

namespace GeminiAPICaller.Test
{
    [TestClass]
    public class GeminiCallerTest
    {
       private GeminiAPICaller.Core.GeminiAPICaller _caller = new GeminiAPICaller.Core.GeminiAPICaller();

        [TestMethod]
        public async Task Test_Gemini_call()
        {
            GeminiPromptMessage geminiPromptBase = new GeminiPromptMessage();

            Content content = new Content()
            {
                Parts = new List<Part>()
            };
          
            content.Parts.AddPart("amberieu en bugey", "01", "189900", "95", "Maison", "A 15 mn de Amb�rieu en Bugey en direction de Meximieux sur la commune de Saint Maurice de R�mens. Agr�able maison de village comprenant 3 chambres ainsi qu'une mezzanine, une buanderie et un garage. Vous appr�cierez �galement la proximit� de l'�cole primaires, accessible en quelques minutes � pied garantissant un quotidien simplifi� pour vos enfants. Pour les amoureux de la nature, plusieurs parcs et for�ts sont � d�couvrir aux alentours, promettant de belles escapades en plein air.");

            geminiPromptBase.Contents = new List<Content> { content };
            geminiPromptBase.SystemInstruction = new SystemInstruction();

            geminiPromptBase.SystemInstruction.Parts = new List<Part> { new Part
            {
                Text = "Je vais te donner des informations concernant une annonce immobili�re, je vais te donner la ville, le code postal, le prix, le nombre de m�tres carr�s, le type � savoir si une maison appartement ou terrain et la description de l'annonce, je veux que tu me donnes comme information le nombre d'habitants dans la ville, le est-ce qu'il y a des commerces dans la ville ( Boulangerie,boucher, Poste, Supermarch�). Si non,donne moi la ville la plus proche avec ces commerces.Je veux que tu me dises si il y a une �cole primaire sinon la ville la plus proche avec l'�cole primaire et le temps pour y aller en te basant sur la ville donn�.Je veux que tu me dises si il y a un coll�ge sinon la ville la plus proche avec un coll�ge et le temps pour y aller en te basant sur la ville donn�.Je veux que tu me dises si il y a un lyc�e sinon la ville la plus proche avec un lyc�e et le temps pour y aller en te basant sur la ville donn�.Si la ville poss�de une gare Si non, la ville la plus proche avec une gare  et le temps pour y aller en te basant sur la ville donn�."
            } };

            GeminiPromptResponse response = await _caller.SendPromptAsync(geminiPromptBase);

            Assert.IsNotNull(response);
        }
    }
}