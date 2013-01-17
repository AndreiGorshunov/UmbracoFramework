// -----------------------------------------------------------------------
// <copyright file="MediaHelper.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Xml;
using umbraco.MacroEngines;
using UmbracoFramework.Diagnostics;

namespace UmbracoFramework.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class MediaHelper
    {
        public static string GetMediaUrl(dynamic model, string imageFieldName)
        {
            try
            {
                return model.Media(imageFieldName).umbracoFile;
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
