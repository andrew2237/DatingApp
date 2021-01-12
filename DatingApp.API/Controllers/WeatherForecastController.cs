﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Design;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context=context;
        }
        // GET api/values
        [HttpGet]

        public async Task<IActionResult> GetValues()
        {
           var values=await _context.Values.ToListAsync();
           return Ok(values);
        }

        [AllowAnonymous]
         [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
           var value=await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
           return Ok(value);
        }
    }
}
