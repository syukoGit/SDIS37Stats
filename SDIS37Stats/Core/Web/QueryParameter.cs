// -----------------------------------------------------------------------
// <copyright file="QueryParameter.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Core.Web
{
    /// <summary>
    /// Class for make the query parameters used by the <see cref="URL"/> class.
    /// </summary>
    public class QueryParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParameter"/> class.
        /// </summary>
        /// <param name="name">The query parameter's name.</param>
        public QueryParameter(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the query parameter's name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the default value of the query parameter.
        /// </summary>
        public string DefaultValue { get; set; } = null;
    }
}
