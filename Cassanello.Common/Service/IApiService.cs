using Cassanello.Common.Models;
using System.Threading.Tasks;

namespace Cassanello.Common.Service
{
    public interface IApiService
    {
        Task<Response> GetVisitadorByEmail(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);

        Task<Response> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);

    }
}
