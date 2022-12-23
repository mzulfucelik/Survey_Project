using Repository.AppDbContexts.AppDbContext;
using Core;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<User>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<List<User>> GetWebAllUserAsync()
        {
            return await _context.Users.ToListAsync();
        }




        public async Task<List<User>> GetApiAllUserAsync()
        {
            return await _context.Users.ToListAsync();
        }



        public async Task<List<User>> GetAllUserAsync()
        {
            return await _context.Users.ToListAsync();
        }

    }
}
