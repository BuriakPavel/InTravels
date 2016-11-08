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
    [RoutePrefix("api/Localization")]
    public class LocalizationApiController : BaseApiController
    {
        public Dictionary<string, string> GetLocalizedStrings(string culture)
        {
            ResourceSet resourceSet = Localizations.Localization.ResourceManager.GetResourceSet(CultureInfo.GetCultureInfo(culture), true, true);

            Dictionary<string, string> localizedStrings = new Dictionary<string, string>();

            localizedStrings = resourceSet.Cast<DictionaryEntry>().ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());

            return localizedStrings;
        }
    }
}
