using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UplodaFile.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IFormFile File { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        [HttpPost]
        public IActionResult OnPost()
        {
            if (File != null && File.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", File.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                     File.CopyToAsync(stream);
                }

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}