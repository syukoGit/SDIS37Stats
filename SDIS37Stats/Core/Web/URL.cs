// -----------------------------------------------------------------------
// <copyright file="URL.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Core.Web
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class for creates a url with the available query parameters or the available post data.
    /// </summary>
    public class URL
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="URL"/> class.
        /// </summary>
        /// <param name="url">The web url to be used by the <see cref="URL"/> instance.</param>
        public URL(string url)
        {
            this.Url = url;
        }

        /// <summary>
        /// Gets the url.
        /// </summary>
        public string Url { get; private set; } = string.Empty;

        /// <summary>
        /// Gets all available query parameters.
        /// </summary>
        public Dictionary<string, string> QueryParameters { get; init; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets all available post data.
        /// </summary>
        public Dictionary<string, string> PostData { get; init; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets a value indicating whether the web page use the JavaScript.
        /// </summary>
        public bool UseJS { get; set; } = false;

        /// <summary>
        /// Gets the absolute url and the post data.
        /// </summary>
        /// <returns>Returns the absolute url and the post data.</returns>
        public (string absoluteUrl, string postData) GetAbsoluteUrlAndPostData()
        {
            return (this.GetAbsoluteUrl(), this.GetPostData());
        }

        /// <summary>
        /// Gets the absolute url.
        /// </summary>
        /// <returns>Returns the absolute url.</returns>
        public string GetAbsoluteUrl()
        {
            return this.QueryParameters.Count > 0 ? this.Url + "?" + string.Join("&", this.QueryParameters.Select(c => c.Key + "=" + c.Value)) : this.Url;
        }

        /// <summary>
        /// Gets the post data.
        /// </summary>
        /// <returns>Returns the post data.</returns>
        public string GetPostData()
        {
            return this.PostData.Count > 0 ? string.Join("&", this.PostData.Select(c => c.Key + "=" + c.Value)) : string.Empty;
        }

        /// <summary>
        /// Returns a absolute url that represents the current object.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current object.</returns>
        public override string ToString()
        {
            return this.GetAbsoluteUrl();
        }
    }
}
