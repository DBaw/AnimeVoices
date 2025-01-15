using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.IO;
using System.Net;
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
            using var httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(10) // Explicit timeout
            };

            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsByteArrayAsync();
                Bitmap bitmap = new Bitmap(new MemoryStream(data));
                return bitmap;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<Bitmap> LoadImage(string? resource)
        {
            if (string.IsNullOrEmpty(resource))
            {
               return LoadFromResource("avares://AnimeVoices/Assets/not-found-image.png");
            }

            return LoadFromResource("avares://AnimeVoices/Assets/not-found-image.png");
            //return await LoadFromWeb(resource);
        }
    }
}
