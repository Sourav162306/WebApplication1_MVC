using Microsoft.AspNetCore.Mvc;
using Web1.DataAccess.Data;
using Web1.DataAccess.Repository.IRepository;
using Web1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Products")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> ObjCategoryList = _unitOfWork.Product.GetAll().ToList();
            return View(ObjCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromunitOfWork = _unitOfWork.Product.Get(u => u.Id == id);
            //Category? categoryFromunitOfWork2 = _unitOfWork.Categories.FirstOrDefault(u=>u.Id == id);
            //Category? categoryFromunitOfWork3 = _unitOfWork.Categories.Where(u=>u.Id == id).FirstOrDefault();

            if (productFromunitOfWork == null)
            {
                return NotFound();
            }

            return View(productFromunitOfWork);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");

            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? categoryFromunitOfWork = _unitOfWork.Product.Get(u => u.Id == id);
            if (categoryFromunitOfWork == null)
            {
                return NotFound();
            }

            return View(categoryFromunitOfWork);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound(id);
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
