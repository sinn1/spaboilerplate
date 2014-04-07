using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using SPABoilerplate.DAL.Common;

namespace SPABoilerplate.Helpers
{
    public static class ErrorResponse
    {
        public static HttpResponseMessage Create(DataAccessError error)
        {
            switch (error)
            {
                case DataAccessError.NOT_FOUND:
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                case DataAccessError.OUT_OF_SYNC:
                    return new HttpResponseMessage(HttpStatusCode.Conflict);
                default:
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}