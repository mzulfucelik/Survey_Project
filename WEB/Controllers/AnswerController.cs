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
    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;

        public AnswerController(IAnswerService answerService, IMapper mapper)
        {
            _answerService = answerService;
            _mapper = mapper;
        } 

        public async Task<IActionResult> Index()
        {
            var answer = await _answerService.GetWebAllAnswer();
            dynamic mymodel = new ExpandoObject();
            mymodel._answer = answer;
           
            return View(mymodel);
        }



        public async Task<IActionResult> Save()
        {
            var answer = await _answerService.GetAllAsync();
            var answerDto = _mapper.Map<List<AnswerDto>>(answer.ToList());
            ViewBag.answer = new SelectList(answerDto, "Id", "Name");
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Save(AnswerDto answerDto)
        {
            if (ModelState.IsValid)
            {
                await _answerService.AddAsync(_mapper.Map<Answer>(answerDto));
                TempData.Add("Success", "Cevap başarıyla eklenmiştir.");
                return RedirectToAction(nameof(Index));
            }
            TempData.Add("Error", "Hata Oluştu. answerController|Save|54");
            var answer = await _answerService.GetAllAsync();
            var answersDto = _mapper.Map<List<AnswerDto>>(answer.ToList());
            ViewBag.answer = new SelectList(answersDto, "Id", "Name");
            return View();
        }

      


        public async Task<IActionResult> Delete(int Id)
        {
            var answer = await _answerService.GetByIdAsync(Id);
            await _answerService.RemoveAsync(answer);
            TempData.Add("Info", "cevap başarıyla silinmiştir.");
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int Id)
        {
            var answer = await _answerService.GetByIdAsync(Id);
            var answers = await _answerService.GetAllAsync();
            var answerDto = _mapper.Map<List<AnswerDto>>(answers.ToList());
            ViewBag.answer = new SelectList(answerDto, "Id", "Name", answer);
            return View(_mapper.Map<AnswerDto>(answer));
        }





    }
}