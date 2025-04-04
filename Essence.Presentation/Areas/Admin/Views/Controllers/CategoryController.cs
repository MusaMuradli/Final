﻿using Essence.Business.Dtos.CategoryDtos;
using Essence.Business.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllCategories();
        return View(categories);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var dto = await _categoryService.GetCreateDtoAsync();
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            dto = await _categoryService.GetCreateDtoAsync(dto);
            return View(dto);
        }

        var result = await _categoryService.CreateAsync(dto, ModelState);

        if (!result)
        {
            dto = await _categoryService.GetCreateDtoAsync(dto);
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var dto = await _categoryService.GetUpdatedDtoAsync(id);
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(CategoryUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _categoryService.UpdateAsync(dto, ModelState);

        if (!result)
        {
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _categoryService.DeleteAsync(id); // Silmə əməliyyatı
            return RedirectToAction(nameof(Index)); // Admin panelə geri dön
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message); // Hər hansı bir xəta baş verərsə, error əlavə et
            return RedirectToAction(nameof(Index)); // Eyni səhifəyə geri dön
        }
    }

    [HttpGet]
    public async Task<IActionResult> DeletedCategories()
    {
        var deletedCategories = await _categoryService.GetDeletedCategories();
        return View(deletedCategories);
    }



}
