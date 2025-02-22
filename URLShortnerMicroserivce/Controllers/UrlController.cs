using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShortnerMicroserivce.Model;
using URLShortnerMicroserivce.Services;

namespace URLShortnerMicroserivce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        /// <summary>
        /// Instance of IUrlShortenerService.
        /// </summary>
        private IUrlShortenerService _urlShortenerService;

        public UrlController(IUrlShortenerService urlShortenerService) 
        {
         _urlShortenerService = urlShortenerService;
        }

        /// <summary>
        /// This will provide a short url for given long url.
        /// </summary>
        /// <param name="request"> Instance of GenerateShortUrlRequest</param>
        /// <returns> On completion will return the long url with valid statuscode.</returns>
        [HttpPost("generateShortUrl")]
        public async Task<IActionResult> generateShortUrl([FromBody] GenerateShortUrlRequest request )
        {

            var shortUrl = await _urlShortenerService.ShortenUrlAsync(request.longUrl);
            GenerateShortUrlResponse generateShortUrlResponse = new GenerateShortUrlResponse();
            generateShortUrlResponse.longUrl = request.longUrl;
            generateShortUrlResponse.shortUrl = shortUrl;

            return CreatedAtAction(nameof(generateShortUrl), generateShortUrlResponse);
        }

        /// <summary>
        /// retrives the orignal URL associated with the short URL.
        /// </summary>
        /// <param name="request">Instance of GetOrignalUrlRequest containing the short URL to which find the orignal URL.</param>
        /// <returns>Response with short URL and long URL along with message if not found it will be error message.</returns>
        [HttpPost("getOrignalUrl")]
        public async Task<IActionResult> getOrignalUrl([FromBody] GetOrignalUrlRequest request)
        {
            var longUrlResponse = await _urlShortenerService.GetOriginalUrlAsync(request.shortUrl);

            GetOrignalUrlResponse getOrignalUrlResponse = new GetOrignalUrlResponse();
            getOrignalUrlResponse.shortUrl = request.shortUrl;
            getOrignalUrlResponse.longUrl = longUrlResponse;

            if (longUrlResponse == null)
            {
                getOrignalUrlResponse.message = "URL not present into the database.";
            }


            return Ok(getOrignalUrlResponse);
        }

    }
}
