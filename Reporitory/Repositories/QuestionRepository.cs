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
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
	{
		public QuestionRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Question>> GetQuestion()
        {
            return await _context.Questions.ToListAsync();
        }


        public async Task<List<Question>> GetWebAllQuestionAsync()
        {
            return await _context.Questions.ToListAsync();
        }




        public async Task<List<Question>> GetApiAllQuestionAsync()
        {
            return await _context.Questions.ToListAsync();
        }



        public async Task<List<Question>> GetAllQuestionAsync()
        {
            return await _context.Questions.ToListAsync();
        }


    }
}
