using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DearDiary.Models;

namespace DearDiary.Controllers.ApiControllers
{
    public class DiariesController : ApiController
    {
        private ApplicationDbContext _context;

        public DiariesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/diaries
        public IEnumerable<Diary> GetDiaries()
        {
            var diaries = _context.Diaries.ToList();
            return diaries;
        }

        //GET /api/diaries/{id}
        public Diary GetDiary(int id)
        {
            var diaryInDB = _context.Diaries.SingleOrDefault(d => d.Id == id);
            if (diaryInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return diaryInDB;
        }

        [HttpPost]
        public Diary AddDiary(Diary diary)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Diaries.Add(diary);
            _context.SaveChanges();
            return diary;
        }

        [HttpPut]
        public Diary EditDiary(int id, Diary diary)
        {
            var diaryInDB = _context.Diaries.SingleOrDefault(d => d.Id == id);
            if(diaryInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            diaryInDB.Content = diary.Content;
            diaryInDB.Title = diary.Title;
            diaryInDB.LastUpdated = DateTime.Now;
            _context.SaveChanges();
            return diary;
        }

        [HttpDelete]
        public void DeleteDiary(int id)
        {
            var diaryInDB = _context.Diaries.SingleOrDefault(d => d.Id == id);
            if (diaryInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Diaries.Remove(diaryInDB);
            _context.SaveChanges();
            
        }
    }
}
