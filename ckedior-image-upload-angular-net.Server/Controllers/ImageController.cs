using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ckedior_image_upload_angular_net.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly ILogger<ImageController> _logger;
        private readonly IConfiguration _configuration;

        public ImageController(ILogger<ImageController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        // POST: api/Image
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> Upload([FromForm] IFormFile upload)
        {

            try
            {
                _logger.LogInformation(JsonSerializer.Serialize(upload));
                //If nothing was sent to the backend or the file was corrupted
                if (upload == null || upload.Length == 0)
                    return BadRequest("Invalid image file");

                //generate a unique file name
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(upload.FileName);

                string filePath = Path.Combine("wwwroot/images/", fileName);

                //Save image file to assets
                await using var fileStream = new FileStream(filePath, FileMode.Create);
                await upload.CopyToAsync(fileStream);


                //Image url path.
                string path = $"images/{fileName}";


                //Create a url generator helper function.
                string ImageUrl = Urlify(_configuration, path);

                //Return the URL to CKEditor to display
                return CreatedAtAction(null, new { url = ImageUrl });
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                return BadRequest(ex.Message);
            }
        }

        private string Urlify(IConfiguration configuration, string path)
        {
            return $"{configuration["AppUrl"]}/{path}";
        }

    }


}
