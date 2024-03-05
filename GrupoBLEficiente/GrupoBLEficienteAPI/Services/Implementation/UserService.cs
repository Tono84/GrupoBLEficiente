using Microsoft.EntityFrameworkCore;
using GrupoBLEficienteAPI.Models;
using GrupoBLEficienteAPI.Services.Contract;
using GrupoBLEficienteAPI.Helpers;

namespace GrupoBLEficienteAPI.Services.Implementation
{

    public class UserService : IUserService
    {
        private readonly GBLContext _context;
        public UserService(GBLContext context)
        {
            _context = context;
        }
        public async Task<Users> GetUser(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
        }
        public async Task<Users> SaveUser(Users Model)
        {
            Model.Password = Utilities.GetSHA256(Model.Password);
            _context.Users.Add(Model);
            await _context.SaveChangesAsync();
            return Model;
        }
    }
}
