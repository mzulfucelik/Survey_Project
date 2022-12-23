using Microsoft.AspNetCore.Mvc;
using Survey_Project.Core.Services;
using Survey_Project.Core.DTOs;
using Survey_Project.Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;
using Core.DTOs;
using Core.Models;

namespace Survey_Project.WEB.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        } 

        public async Task<IActionResult> Index()
        {
            var question = await _questionService.GetWebAllQuestion();
            dynamic mymodel = new ExpandoObject();
            mymodel._question = question;
           
            return View(mymodel);
        }



        public async Task<IActionResult> Save()
        {
            var question = await _questionService.GetAllAsync();
            var questionDto = _mapper.Map<List<QuestionDto>>(question.ToList());
            ViewBag.question = new SelectList(questionDto, "Id", "Name");
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Save(QuestionDto questionDto)
        {
            if (ModelState.IsValid)
            {
                await _questionService.AddAsync(_mapper.Map<Question>(questionDto));
                TempData.Add("Success", "Soru başarıyla eklenmiştir.");
                return RedirectToAction(nameof(Index));
            }
            TempData.Add("Error", "Hata Oluştu. QuestionController|Save|54");
            var question = await _questionService.GetAllAsync();
            var questionsDto = _mapper.Map<List<QuestionDto>>(question.ToList());
            ViewBag.question = new SelectList(questionsDto, "Id", "Name");
            return View();
        }

      


        public async Task<IActionResult> Delete(int Id)
        {
            var question = await _questionService.GetByIdAsync(Id);
            await _questionService.RemoveAsync(question);
            TempData.Add("Info", "Soru başarıyla silinmiştir.");
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int Id)
        {
            var question = await _questionService.GetByIdAsync(Id);
            var questions = await _questionService.GetAllAsync();
            var questionDto = _mapper.Map<List<QuestionDto>>(questions.ToList());
            ViewBag.question = new SelectList(questionDto, "Id", "Name", question);
            return View(_mapper.Map<QuestionDto>(question));
        }





    }
}