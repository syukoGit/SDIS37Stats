using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIS37Stats.Core.Web
{
    public class URL
    {
        public URL(string url)
        {
            this.Url = url;
        }

        public string Url { get; private set; } = string.Empty;

        public QueryParameter[] QueryParameters { get; set; }

        public PostData[] PostDatas { get; set; }

        public bool UseJS { get; set; } = false;

        public IEnumerable<string> GetQueryParametersNames()
        {
            return this.QueryParameters.Select(c => c.Name);
        }

        #region public
        public (string absoluteUrl, string postData) GetAbsoluteUrlAndPostData(Dictionary<string, string> queryParameters, Dictionary<string, string> postData)
        {
            return (this.GetAbsoluteUrl(queryParameters), this.GetPostData(postData));
        }

        public string GetAbsoluteUrl(Dictionary<string, string> queryParameters = null)
        {
            string output = this.Url;

            List<string> queryParam = new();

            if (queryParameters != null && queryParameters.Count() > 0)
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

            if (queryParam.Count() > 0)
            {
                output += "?" + string.Join("&", queryParam);
            }

            return output;
        }

        public string GetPostData(Dictionary<string, string> postDataWithValue = null)
        {
            string output = string.Empty;

            List<string> postDatas = new();

            if (postDataWithValue != null && postDataWithValue.Count() > 0)
            {
                postDatas.AddRange(postDataWithValue.Where(c => !string.IsNullOrWhiteSpace(c.Value)).Select(c => c.Key + "=" + c.Value));
            }

            if (this.PostDatas != null && this.PostDatas.Count() > 0)
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

            if (postDatas.Count() > 0)
            {
                output = string.Join("&", postDatas);
            }

            return output;
        }

        public override string ToString()
        {
            return this.Url;
        }
        #endregion
    }

    public class QueryParameter
    {
        public QueryParameter(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string DefaultValue { get; set; } = null;
    }

    public class PostData
    {
        public PostData(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string DefaultValue { get; set; } = null;
    }
}
