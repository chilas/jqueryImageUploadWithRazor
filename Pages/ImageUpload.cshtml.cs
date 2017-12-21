using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jqueryRazorpagesSimpleFileUpload.Pages
{
    public class ImageUploadModel : PageModel
    {

        public void OnGetAsync(string filename)
        {
        }

        public async Task OnPostAsync(IFormFile image)
        {
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/uploads",
                        image.FileName);

            var memory = new MemoryStream();

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
        }
    }
}
