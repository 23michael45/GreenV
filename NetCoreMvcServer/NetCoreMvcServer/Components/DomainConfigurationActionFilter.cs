//using Microsoft.AspNetCore.Mvc.Filters;

//public class DomainConfigurationActionFilter : ActionFilterAttribute
//{
//    private readonly IBusRepository _rp;

//    public DomainConfigurationActionFilter(IBusRepository rp)
//    {
//    }

//    public override void OnActionExecuting(ActionExecutingContext actionContext)
//    {
//        var request = actionContext.HttpContext.Request;
//        var response = actionContext.HttpContext.Response;

//        string host = request.GetUri().Host;

//        if (!request.Cookies.ContainsKey(CookieHelper.LanguageIdCookieName) || !request.Cookies.ContainsKey(CookieHelper.CultureCookieName))
//        {

//            LanguageModel language = Task.Run(async () => await _rp.GetLanguageDefaultAsync(host)).Result;

//            response.Cookies.Append(CookieHelper.LanguageIdCookieName, language.LanguageId,
//                new CookieOptions { Expires = DateTime.Today.AddYears(1) });
//            response.Cookies.Append(CookieHelper.CultureCookieName, $"c={language.CultureInfo}|uic={language.CultureInfo}",
//                new CookieOptions { Expires = DateTime.Today.AddYears(1) });


//            response.Redirect(request.GetUri().PathAndQuery);

//#if NET452
//            //Thread.CurrentThread.CurrentCulture = new CultureInfo(language.CultureInfo);
//            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(language.CultureInfo);

//#else
//            //CultureInfo.CurrentCulture = new CultureInfo(language.CultureInfo);
//            //CultureInfo.CurrentUICulture = new CultureInfo(language.CultureInfo);
//#endif

//            //Thread.CurrentThread.CurrentCulture = new CultureInfo(language.CultureInfo);
//            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(language.CultureInfo);
//        }

//        //initialize countryId for host
//        if (!request.Cookies.ContainsKey("CountryId"))
//        {
//            string countryId = Task.Run(async () => await _rp.GetCountryIdDefaultAsync(host)).Result;
//            response.Cookies.Append("CountryId", countryId, new CookieOptions { Expires = DateTime.Today.AddYears(1) });
//        }


//        if (!request.Cookies.ContainsKey(CookieHelper.CurrencyIdCookieName)
//            || !Task.Run(async () => await _rp.IsCurrencyFoundAsync(request.Cookies[CookieHelper.CurrencyIdCookieName])).Result)
//        {

//            string currencyId = Task.Run(async () => await _rp.GetCurrencyIdDefaultAsync(host)).Result;
//            response.Cookies.Append(CookieHelper.CurrencyIdCookieName, currencyId, new CookieOptions { Expires = DateTime.Today.AddYears(1) });

//        }

//        base.OnActionExecuting(actionContext);
//    }