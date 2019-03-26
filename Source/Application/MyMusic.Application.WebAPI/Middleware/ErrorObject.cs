using Newtonsoft.Json;
using System.Net;

namespace MyMusic.Application.WebAPI.Middleware
{
    /// <summary>
    /// Objeto de padrão de responses com erro
    /// </summary>
    public class ErrorObject
    {
        /// <summary>
        /// Código da response
        /// </summary>
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// Message da response
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// Target da response
        /// </summary>
        [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; }
    }
}
