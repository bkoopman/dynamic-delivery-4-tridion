using System.IO;

namespace DD4T.Mvc.Html
{
    public static class ImageHelper
    {
        public static string ResizeToWidth(this string url, int width, bool allowStretch = true)
        {
            return ResizeToDimension(url, width, 'w', allowStretch);
        }

        public static string ResizeToHeight(this string url, int height, bool allowStretch = true)
        {
            return ResizeToDimension(url, height, 'h', allowStretch);
        }

        public static string ResizeToWidthAndHeight(this string url, int width, int height, bool allowDistort = true)
        {
            return ResizeToDimension(ResizeToDimension(url, width, 'w'), height, 'h', allowDistort);
        }

        private static string ResizeToDimension(string url, int val, char dimension, bool allowDistort = true)
        {
            string extension = Path.GetExtension(url);

            if (!string.IsNullOrEmpty(extension))
            {
                url = string.Format("{0}_{1}{2}{3}{4}", url.Substring(0, url.LastIndexOf(".")), dimension, val, allowDistort ? "" : "_n",extension);
            }
            return url;
        }
    }
}
