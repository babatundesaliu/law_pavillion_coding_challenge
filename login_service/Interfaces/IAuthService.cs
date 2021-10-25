using login_service.DTOs;
using System.Threading.Tasks;

namespace login_service.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}