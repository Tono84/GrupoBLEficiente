using Microsoft.EntityFrameworkCore;
using GrupoBLEficienteAPI.Models;

namespace GrupoBLEficienteAPI.Services.Contract
{
    public interface IUserService
    {
        Task<Users> GetUser(string username, string password);

        Task<Users> SaveUser(Users Model);
    }
}
