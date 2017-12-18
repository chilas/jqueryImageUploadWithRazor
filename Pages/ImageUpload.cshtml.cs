using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jqueryRazorpagesSimpleFileUpload.Pages
{
    public class ImageUploadModel : PageModel
    {

        //public IFormFile Image { get; set; }
        public string RecentImagePath { get; set; }
        public string ErrorMessage { get; set; }
        public void OnGetAsync(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                RecentImagePath = $"/uploads/{filename}";
            }
        }

        public async Task<IActionResult> OnPostAsync(IFormFile image, string name)
        {
            if (image == null || image.Length == 0) return RedirectToPagePermanent("./ImageUpload");
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/uploads",
                        image.FileName);

            var memory = new MemoryStream();

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return RedirectToPagePermanent("./ImageUpload", new { filename = image.FileName });
        }
    }
}
