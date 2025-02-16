using System.ComponentModel.DataAnnotations;

namespace URLShortnerMicroserivce.Model
{
    /// <summary>
    /// Request data flow object generate short url method.
    /// </summary>
    public class GenerateShortUrlRequest
    {
        /// <summary>
        /// Instance  of string representing the longUrl.
        /// </summary>
        public string longUrl { get; set; }
    }
}
