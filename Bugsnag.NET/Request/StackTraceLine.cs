﻿using Bugsnag.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Bugsnag.Common;

namespace Bugsnag.NET.Request
{
    public class StackTraceLine : IStackTraceLine
    {
        public static IEnumerable<IStackTraceLine> Build(Exception ex) => Build(ex, x => x);
        public static IEnumerable<IStackTraceLine> Build(Exception ex, Func<IStackTraceLine, IStackTraceLine> transformStackTraceLine)
        {
            foreach (var line in ex.ToLines())
            {
                yield return transformStackTraceLine(
                    new StackTraceLine
                    {
                        File = line.ParseFile(),
                        LineNumber = line.ParseLineNumber(),
                        Method = line.ParseMethodName(),
                        InProject = true,
                    }
                );
            }
        }

        [Obsolete]
        internal static IEnumerable<IStackTraceLine> Build(string memberName, string sourceFilePath, int sourceLineNumber)
        {
            yield return new StackTraceLine
            {
                File = sourceFilePath,
                LineNumber = sourceLineNumber,
                Method = memberName
            };
        }

        public string File { get; private set; }

        public int LineNumber { get; private set; }

        public int? ColumnNumber { get; private set; }

        public string Method { get; private set; }

        public bool InProject { get; private set; }
    }
}
