using System.Web;
using System.Web.Mvc;

namespace AutoTavex
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Nimeni nu poate intra pe aplicatie fara cont,
            // cu exceptia controlerlor/fct cu [AlllowAnonymous]
            filters.Add(new AuthorizeAttribute());
        }
    }
}
