using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DearDiary.ViewModels;
using DearDiary.Models;

namespace DearDiary.Controllers
{
    public class DiariesController : Controller
    {
        // GET: Diaries

        private ApplicationDbContext _context;

        public DiariesController(){
               _context =new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var notes = _context.Diaries.ToList();
            var viewModel = new DiaryIndexViewModel
            {
                Diaries = notes
            };
            return View(viewModel);
        }

        public ActionResult ViewDiary(int id)
        {
            var diaryInDB = _context.Diaries.SingleOrDefault( d => d.Id==id);
            if (diaryInDB == null)
                return HttpNotFound();
            var viewModel = new ViewDiaryViewModel
            {
                Diary = diaryInDB
            };
            return View(viewModel);
        }

        public ActionResult DiaryForm()
        {
            var viewModel = new DiaryFormViewModel
            {
                Diary = new Diary()
            };
            return View(viewModel);
        }


        public ActionResult DiaryEdit(int id)
        {
            var diary = _context.Diaries.SingleOrDefault(d => d.Id == id);
            var viewModel = new DiaryFormViewModel
            {
                Diary = diary
            };
            return View("DiaryForm", viewModel);
        }



        public ActionResult Save(Diary diary)
        {
            diary.Created = DateTime.Now;
            diary.LastUpdated = DateTime.Now;
            _context.Diaries.Add(diary);
            _context.SaveChanges();
            return RedirectToAction("Index", "Diaries");
        }
    }
}