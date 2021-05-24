// -----------------------------------------------------------------------
// <copyright file="URL.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Core.Web
{
    using System.Collections.Generic;
    using System.Linq;

    public class QueryParameter
    {
        public QueryParameter(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string DefaultValue { get; set; } = null;
    }
}
