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
    }
}
