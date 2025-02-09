﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musictify.Data;
using Musictify.Models;

namespace Musictify.Controllers
{
    public class SingerPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SingerPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SingerPage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Singer.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = await _context.Singer
                .FirstOrDefaultAsync(m => m.SingerID == id);
            if (singer == null)
            {
                return NotFound();
            }

            return View(singer);
        }

        private bool SingerExists(int id)
        {
            return _context.Singer.Any(e => e.SingerID == id);
        }
    }
}
