
using System;
using Microsoft.EntityFrameworkCore;
using URLShortnerMicroserivce.Data;
using URLShortnerMicroserivce.Model;

namespace URLShortnerMicroserivce.Services
{
    public class URLShortenerService : IUrlShortenerService
    {
        private UrlShortenerContext _context = new UrlShortenerContext();

        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
        private Random _random = new Random();
        
        public  async Task<string?> GetOriginalUrlAsync(string shortUrl)
        {

            var response =  await _context.UrlMappings.FirstOrDefaultAsync(s => s.shortUrl == shortUrl);
            if (response != null)
            {
                return response.longUrl;
            }
            return null;
        }

        public async Task<string> ShortenUrlAsync(string originalUrl)
        {
           var shortcode =  GenerateShortCode();
           var shortUrl = "newgen.ly" + shortcode;

            var mapping = new UrlMapping();
            mapping.shortUrl = shortUrl;
            mapping.longUrl = originalUrl;

            var response = await _context.UrlMappings.AddAsync(mapping);

            await _context.SaveChangesAsync();
            return response.Entity.shortUrl;
        }



        private string GenerateShortCode(int length = 6)
        {
            return new string(Enumerable.Repeat(Alphabet, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }







    }
}
