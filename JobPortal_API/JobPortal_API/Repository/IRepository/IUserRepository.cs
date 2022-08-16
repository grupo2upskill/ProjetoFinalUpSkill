using JobPortal_API.DTOs;
using JobPortal_API.Models;

namespace JobPortal_API.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniquerUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
