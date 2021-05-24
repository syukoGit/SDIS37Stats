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
        /// Gets or sets all available query parameters with their default value.
        /// </summary>
        public QueryParameter[] QueryParameters { get; set; }

        /// <summary>
        /// Gets or sets all available post data with their defualt value.
        /// </summary>
        public PostData[] PostDatas { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the web page use the JavaScript.
        /// </summary>
        public bool UseJS { get; set; } = false;

        /// <summary>
        /// Gets the absolute url and the post data.
        /// </summary>
        /// <param name="queryParameters">The query parameters with key is the name of parameter and the value is value of query parameter.</param>
        /// <param name="postData">The post data with key is the name of parameter and the value is value of query parameter.</param>
        /// <returns>Returns the absolute url and the post data.</returns>
        public (string absoluteUrl, string postData) GetAbsoluteUrlAndPostData(Dictionary<string, string> queryParameters, Dictionary<string, string> postData)
        {
            return (this.GetAbsoluteUrl(queryParameters), this.GetPostData(postData));
        }

        /// <summary>
        /// Gets the absolute url.
        /// </summary>
        /// <param name="queryParameters">The query parameters with key is the name of parameter and the value is value of query parameter.</param>
        /// <returns>Returns the absolute url.</returns>
        public string GetAbsoluteUrl(Dictionary<string, string> queryParameters = null)
        {
            string output = this.Url;

            List<string> queryParam = new ();

            if (queryParameters != null && queryParameters.Count > 0)
            {
                queryParam.AddRange(queryParameters.Where(c => !string.IsNullOrWhiteSpace(c.Value)).Select(c => c.Key + "=" + c.Value));
            }

            if (this.QueryParameters != null && this.QueryParameters.Length > 0)
            {
                if (queryParameters != null)
                {
                    queryParam.AddRange(this.QueryParameters.Where(c => !queryParameters.ContainsKey(c.Name) && !string.IsNullOrWhiteSpace(c.DefaultValue)).Select(c => c.Name + "=" + c.DefaultValue));
                }
                else
                {
                    queryParam.AddRange(this.QueryParameters.Where(c => !string.IsNullOrWhiteSpace(c.DefaultValue)).Select(c => c.Name + "=" + c.DefaultValue));
                }
            }

            if (queryParam.Count > 0)
            {
                output += "?" + string.Join("&", queryParam);
            }

            return output;
        }

        /// <summary>
        /// Gets the post data.
        /// </summary>
        /// <param name="postDataWithValue">The post data with key is the name of parameter and the value is value of query parameter.</param>
        /// <returns>Returns the post data.</returns>
        public string GetPostData(Dictionary<string, string> postDataWithValue = null)
        {
            string output = string.Empty;

            List<string> postDatas = new ();

            if (postDataWithValue != null && postDataWithValue.Count > 0)
            {
                postDatas.AddRange(postDataWithValue.Where(c => !string.IsNullOrWhiteSpace(c.Value)).Select(c => c.Key + "=" + c.Value));
            }

            if (this.PostDatas != null && this.PostDatas.Length > 0)
            {
                if (postDataWithValue != null)
                {
                    postDatas.AddRange(this.PostDatas.Where(c => !postDataWithValue.ContainsKey(c.Name) && !string.IsNullOrWhiteSpace(c.DefaultValue)).Select(c => c.Name + "=" + c.DefaultValue));
                }
                else
                {
                    postDatas.AddRange(this.PostDatas.Where(c => !string.IsNullOrWhiteSpace(c.DefaultValue)).Select(c => c.Name + "=" + c.DefaultValue));
                }
            }

            if (postDatas.Count > 0)
            {
                output = string.Join("&", postDatas);
            }

            return output;
        }

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current object.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current object.</returns>
        public override string ToString()
        {
            return this.Url;
        }
    }
}
