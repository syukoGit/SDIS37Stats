// -----------------------------------------------------------------------
// <copyright file="PostData.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Core.Web
{
    /// <summary>
    /// Class for make the post data used by the <see cref="URL"/> class.
    /// </summary>
    public class PostData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostData"/> class.
        /// </summary>
        /// <param name="name">The parameter's name of the post data.</param>
        public PostData(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the parameter's name of the post data.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the default value of the post data.
        /// </summary>
        public string DefaultValue { get; init; } = null;
    }
}
