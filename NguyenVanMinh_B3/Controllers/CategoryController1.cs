using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NguyenVanMinh_B3.Data;
namespace NguyenVanMinh_B3.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            var _categories = SeedData.categories;
            return View(_categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            //lay ra category co id chuyen vao tu seeddata
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            //neu category =null thi tra ve trang notfound
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Models.Category category)
        {
            if (ModelState.IsValid)
            {
                //lay max id trong danh sach SeedData.categories
                int maxId = SeedData.categories.Max(c => c.Id);
                //set i cho category
                category.Id = maxId + 1;
                //them category vao danh sach SeedData.categories
                SeedData.categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => id == id);
            if (category == null)
                return (NotFound());
            {

            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([FromRoute] int id)
        {
            var esxistingCategory = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (esxistingCategory == null)
            {
                return NotFound();

            }
            SeedData.categories.Remove(esxistingCategory);
            return RedirectToAction(nameof(Index));
        


          
            }
        }
    }

