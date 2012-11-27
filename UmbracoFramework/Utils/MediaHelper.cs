// -----------------------------------------------------------------------
// <copyright file="MediaHelper.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

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
            string src;

            try
            {
                src = model.Media(imageFieldName).umbracoFile;
            }
            catch (Exception ex)
            {
                src = string.Empty;
            }

            return src;
        }
    }
}
