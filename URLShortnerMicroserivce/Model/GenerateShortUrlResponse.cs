namespace URLShortnerMicroserivce.Model
{
    /// <summary>
    /// Response model class for generateShortUrl.
    /// </summary>
    public class GenerateShortUrlResponse
    {
        /// <summary>
        /// Instance of string
        /// </summary>
        public string longUrl {  get; set; }

        /// <summary>
        /// Instance of string
        /// </summary>
        public string shortUrl { get; set; }
    }
}
