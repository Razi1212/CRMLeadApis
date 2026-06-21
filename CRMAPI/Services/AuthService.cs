using CRMAPI.Data;
using CRMAPI.Entities;
using CRMAPI.IService;
using CRMAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRMAPI.Services
{
    public class AuthService : iAuthservice
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetLead()
        {
            return await _context.user.ToListAsync();
        }



    }
}


