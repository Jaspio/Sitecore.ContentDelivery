﻿// © 2015-2016 Sitecore Corporation A/S. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentDelivery.DataStores;
using Sitecore.Extensions.StringExtensions;

namespace Sitecore.ContentDelivery.Web
{
    public class RequestParameters
    {
        private static readonly char[] Comma =
        {
            ','
        };

        private static readonly HashSet<string> Reserved = new HashSet<string>
        {
            "skip",
            "take",
            "fields",
            "systemfields",
            "username",
            "password",
            "domain",
            "token",
            "path",
            "children"
        };

        public RequestParameters(HttpRequestBase request)
        {
            var parameters = new Dictionary<string, string>();

            foreach (var key in request.Form.AllKeys)
            {
                parameters[key] = request.Form[key] ?? string.Empty;
            }

            foreach (var key in request.QueryString.AllKeys)
            {
                parameters[key] = request.QueryString[key] ?? string.Empty;
            }

            Parse(parameters);
        }

        public RequestParameters([NotNull] Dictionary<string, string> parameters)
        {
            Parse(parameters);
        }

        [NotNull]
        public List<FieldInfo> Fields { get; } = new List<FieldInfo>();

        public bool IncludeFieldInfo { get; private set; }

        public bool IncludeSystemFields { get; private set; }

        public int Children { get; private set; }

        [NotNull]
        public Dictionary<string, string> Parameters { get; } = new Dictionary<string, string>();

        [NotNull]
        public string Path { get; private set; }

        public int Skip { get; private set; }

        public int Take { get; private set; }

        private void Parse([NotNull] Dictionary<string, string> parameters)
        {
            string value;
            if (parameters.TryGetValue("skip", out value))
            {
                int skip;
                if (int.TryParse(value, out skip))
                {
                    Skip = skip;
                }
            }

            if (parameters.TryGetValue("take", out value))
            {
                int take;
                if (int.TryParse(value, out take))
                {
                    Take = take;
                }
            }

            if (parameters.TryGetValue("children", out value))
            {
                int children;
                if (int.TryParse(value, out children))
                {
                    Children = children;
                }
            }

            if (parameters.TryGetValue("fieldinfo", out value))
            {
                bool fieldInfo;
                if (bool.TryParse(value, out fieldInfo))
                {
                    IncludeFieldInfo = fieldInfo;
                }
            }

            if (parameters.TryGetValue("path", out value))
            {
                Path = value;
            }

            foreach (var pair in parameters)
            {
                if (!Reserved.Contains(pair.Key))
                {
                    Parameters[pair.Key] = pair.Value ?? string.Empty;
                }
            }

            if (parameters.TryGetValue("fields", out value))
            {
                foreach (var field in value.Split(Comma, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()))
                {
                    var fieldName = field;
                    var format = string.Empty;

                    var n = fieldName.LastIndexOf('[');
                    if (n >= 0)
                    {
                        var m = fieldName.LastIndexOf(']');
                        if (m < n)
                        {
                            throw new InvalidOperationException("] expected");
                        }

                        format = fieldName.Mid(n + 1, m - n - 1).Trim();
                        fieldName = fieldName.Left(n).Trim();
                    }

                    var fieldDescriptor = new FieldInfo(fieldName, format);
                    Fields.Add(fieldDescriptor);
                }
            }

            IncludeSystemFields = parameters.Keys.Any(k => string.Equals(k, "systemfields", StringComparison.OrdinalIgnoreCase));
        }
    }
}
