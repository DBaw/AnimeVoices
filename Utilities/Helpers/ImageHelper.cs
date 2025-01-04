using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimeVoices.Utilities.Helpers
{
    public static class ImageHelper
    {
        public static Bitmap LoadFromResource(string resource)
        {
            return new Bitmap(AssetLoader.Open(new Uri(resource, UriKind.Absolute)));
        }

        public static async Task<Bitmap?> LoadFromWeb(string url)
        {
            using var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsByteArrayAsync();
                return new Bitmap(new MemoryStream(data));
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while downloading image '{url}' : {ex.Message}");
                return null;
            }
        }

        public static Bitmap LoadImage(string resource)
        {
            if (string.IsNullOrEmpty(resource))
            {
               return LoadFromResource("avares://AnimeVoices/Assets/not-found-image.png");
            }

            return LoadFromWeb(resource).Result;
        }
    }
}
