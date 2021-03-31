using API.Helpers;
using Microsoft.AspNetCore.Http;

namespace API.Resources
{
    public class ProductPhotoDto
    {
         [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new[] {".jpg", ".png", ".jpeg"})]
        public IFormFile Photo { get; set; }
    }
}