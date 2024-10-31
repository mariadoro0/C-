using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudAPI.Models;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {
        private readonly CrudContext _context;

        public StudentiController(CrudContext context)
        {
            _context = context;
        }

        [HttpGet("{classe}")]
        public List<Studenti> StudentiList(string classe) {
            var studentiList = _context.Studentis.Where(x=>x.Classe==classe).ToList();
            return studentiList;
        }

        [HttpGet("/count")]
        public int CountStudenti() {  return _context.Studentis.Count(); }

    }
}
