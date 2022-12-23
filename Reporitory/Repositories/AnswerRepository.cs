using Repository.AppDbContexts.AppDbContext;
using Core.Models;
using Core;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
	{
        public AnswerRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Answer>> GetAnswer()
        {
            return await _context.Answers.ToListAsync();
        }


        public async Task<List<Answer>> GetWebAllAnswerAsync()
        {
            return await _context.Answers.ToListAsync();
        }




        public async Task<List<Answer>> GetApiAllAnswerAsync()
        {
            return await _context.Answers.ToListAsync();
        }



        public async Task<List<Answer>> GetAllAnswerAsync()
        {
            return await _context.Answers.ToListAsync();
        }

    


    }
}
