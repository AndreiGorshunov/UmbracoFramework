using UmbracoFramework.Diagnostics;

namespace UmbracoFramework.Utils
{
    using System;

    public static class MediaHelper
    {
        public static string GetMediaUrl(dynamic model, string imageFieldName)
        {
            try
            {
                if (model != null && model.imageFieldName != null && model.Media(imageFieldName) != null)
                {
                    return model.Media(imageFieldName).umbracoFile;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                Log.Error(typeof(MediaHelper), ex);
                return string.Empty;
            }
        }

        public static string GetMediaUrl(dynamic model, string imageFieldName, int widht, int height)
        {
            try
            {
                string url = GetMediaUrl(model, imageFieldName);
                return GetImageGenUrl(url, widht, height);
            }
            catch (Exception ex)
            {
                Log.Error(typeof(MediaHelper), ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the imagegen url for a image
        /// </summary>
        /// <param name="path">The path to the image</param>
        /// <param name="width">The desired width</param>
        /// <param name="height">The desired height</param>
        /// <param name="keepconstraints">Keep the constraints of the image</param>
        /// <param name="usegrayscale">Render the image in grayscale</param>
        /// <returns>The imagegen path for the image</returns>
        public static string GetImageGenUrl(string path, int width, int height, bool keepconstraints = true, bool usegrayscale = false)
        {
            return string.Format(
                "/imagegen.ashx?image={0}&width={1}&height={2}&constrain={3}&colormode={4}",
                path, 
                width, 
                height, 
                keepconstraints, 
                usegrayscale ? "grayscale" : string.Empty);
        }
    }
}
