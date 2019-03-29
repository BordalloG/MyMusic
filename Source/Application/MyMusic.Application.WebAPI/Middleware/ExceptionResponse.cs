namespace MyMusic.Application.WebAPI.Middleware
{
    using MyMusic.Domain.Exceptions;
    using Newtonsoft.Json;
    using System;
    using System.Net;

    namespace Client.API.Middleware.Models
    {
        /// <summary>
        /// Model para padronizar exceções
        /// </summary>
        public class ExceptionResponse
        {
            private ExceptionResponse()
            {
            }

            /// <summary>
            /// Construtor recebendo exception para tratar
            /// </summary>
            /// <param name="exception"></param>
            public ExceptionResponse(Exception exception)
            {
                var response = GetCompleteException(exception);
                Error = response.Error;
                InnerError = response.InnerError;
            }

            /// <summary>
            /// Response error
            /// </summary>
            [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
            public ErrorObject Error { get; private set; }

            /// <summary>
            /// Response inner error
            /// </summary>
            [JsonProperty("innerError", NullValueHandling = NullValueHandling.Ignore)]
            public ExceptionResponse InnerError { get; private set; }

            private ExceptionResponse GetCompleteException(Exception exception)
            {

                var statusCode = exception is NotFoundException ? HttpStatusCode.NotFound :
                    exception is BadRequestException ? HttpStatusCode.BadRequest :
                    exception is NoContentException ? HttpStatusCode.NoContent :
                    HttpStatusCode.InternalServerError;


                var response = new ExceptionResponse
                {
                    Error = new ErrorObject
                    {
                        Message = exception.Message,
                        Target = exception.Source,
                        Code = statusCode
                    },
                    InnerError = exception.InnerException != null
                        ? GetCompleteException(exception.InnerException)
                        : default
                };

                return response;
            }
        }
    }

}
