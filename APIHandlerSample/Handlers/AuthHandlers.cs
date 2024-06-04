using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace APIHandlerSample.Handlers
{
    public class AuthHandlers : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
        
            try
            {
                string path = request.RequestUri.ToString();
                if (request.Headers.Contains("Token"))
                {
                    string content = await request.Content.ReadAsStringAsync();
                    //we can manupalte the content if needed and add this to the passing request
                    request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                    return await base.SendAsync(request, cancellationToken);

                }
                else
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad data");
                }
            }
            catch (Exception ex)
            {

                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}