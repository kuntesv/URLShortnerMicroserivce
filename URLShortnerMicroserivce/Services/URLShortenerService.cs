
using System;
using URLShortnerMicroserivce.Model;

namespace URLShortnerMicroserivce.Services
{
    public class URLShortenerService : IUrlShortenerService
    {

        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
        private Random _random = new Random();
        
        public Task<string?> GetOriginalUrlAsync(string shortCode)
        {
            throw new NotImplementedException();
        }

        public Task<string> ShortenUrlAsync(string originalUrl)
        {
           var shortcode =  GenerateShortCode();
           var shortUrl = "newgen.ly" + shortcode;

            var mapping = new UrlMapping();
            mapping.shortUrl = shortUrl;
            mapping.longUrl = originalUrl;

            throw new NotImplementedException();
        }



        private string GenerateShortCode(int length = 6)
        {
            return new string(Enumerable.Repeat(Alphabet, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }







    }
}
