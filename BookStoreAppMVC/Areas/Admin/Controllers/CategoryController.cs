using BookStoreAppMVC.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAppMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.RoleAdmin)]
    public class CategoryController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot match the Name!");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj); /*_db.Categories.Add(obj);*/
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDatabase = _unitOfWork.Category.Get(u => u.Id == id);
            /*Category? categoryFromDatabase = _db.Categories.Find(id);*/
            //Category? categoryFromDatabase2 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDatabase3 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (categoryFromDatabase == null)
            {
                return NotFound();
            }
            return View(categoryFromDatabase);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder doesn't match the Name! ");
            //}
            //if (obj.Name !=null && obj.Name.ToLower()=="test")
            //{
            //    ModelState.AddModelError("", "Test is an invalid value");
            //}
            if (ModelState.IsValid)
            {
                var existingCategory = _unitOfWork.Category.Get(u => u.Id == obj.Id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                _unitOfWork.Category.Update(obj); /*_db.Categories.Add(obj);*/
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDatabase = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryFromDatabase == null)
            {
                return NotFound();
            }
            return View(categoryFromDatabase);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }

}
