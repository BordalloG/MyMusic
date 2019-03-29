using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Domain.Interfaces.Domain
{
    public interface IHttpClientHelperDomainService
    {
        Task<string> HttpGet(string url);
    }
}
