

using Microsoft.AspNetCore.Authorization;

namespace FNB.Assessment.Web
{
    public class LocalhostAuthorizeAttribute : AuthorizeAttribute
    {
        protected bool AuthorizeCore()
        {
            // Check if the request is from localhost or local network
            //string userHostAddress = httpContext.Request.UserHostAddress;

            //// Check if the IP is localhost (127.0.0.1) or any variant of local addresses
            //if (userHostAddress == "127.0.0.1" || userHostAddress == "::1")
            //{
            //    return true;  // Allow access
            //}

            // Optionally, log unauthorized access attempts here
            return false;  // Deny access
        }
    }
}
