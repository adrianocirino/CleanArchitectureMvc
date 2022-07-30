﻿using System;
using CleanArchitectureMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CleanArchitectureMvc.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitectureMvc.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);
        }
        
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetById(id);

            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetById(id);
            
            return View(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(categoryDto);
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetById(id);
            if (categoryDto == null) return NotFound();
            
            return View(categoryDto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
