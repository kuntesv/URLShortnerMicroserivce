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

            return Created(new Uri(""), generateShortUrlResponse);
        }

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
