using Microsoft.AspNetCore.Mvc;
using WebAppDisplay.Models;

namespace WebAppDisplay.Controllers
{
    public class ImageuploadController : Controller
    {
        PhotoDB dbobj =new PhotoDB();
        public IActionResult imgpageload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult imgpageClick(Photo phcls, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
               
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName); 
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
               
                phcls.Image = fileName;
            }           
            string msg = dbobj.Fn_insert(phcls);           
            TempData["msg"] = msg;
            return View("Imgpageload", phcls);
           
        }
    }
}
