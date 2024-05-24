using GeminiAPICaller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiAPICaller.Test
{
    public static class ExtensionForTesting
    {
        public static List<Part> AddPart(this List<Part> source, string city, string zipCode, string price, string meter, string type, string description)
        {

            Part part = new Part();
            part.Text = $"la ville : {city}, code postal : {zipCode}, prix : {price}, mètre carré : {meter}, type : {type}, description :  {description}";

            source.Add(part);

            return source;
        }
    }
}
