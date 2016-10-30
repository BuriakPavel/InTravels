using Localizations;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Resources;
using System.Web.Http;

namespace InTravels.WebAPI.Controllers
{
    public class LocalizationApiController : BaseApiController
    {
        public string GetLocalizedStrings(string culture)
        {
            ResourceSet resourceSet = Localizations.Localization.ResourceManager.GetResourceSet(CultureInfo.GetCultureInfo(culture), true, true);

            resourceSet.Cast<DictionaryEntry>()
           .ToDictionary(x => x.Key.ToString(),
                         x => x.Value.ToString());

            string json = "";

            foreach (DictionaryEntry item in resourceSet)
            {
                if (json != "") { json += ", "; }
                json += "\"" + item.Key + "\": \"" + item.Value + "\"";
            }

            return "{ " + json + " }";
        }
    }
}
