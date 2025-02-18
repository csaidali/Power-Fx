﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.PowerFx.Core.Utils;

namespace Microsoft.PowerFx.Core.Texl.Intellisense
{
    internal partial class Intellisense
    {
        internal sealed class CommentNodeSuggestionHandler : ISuggestionHandler
        {
            public bool Run(IntellisenseData.IntellisenseData intellisenseData)
            {
                Contracts.AssertValue(intellisenseData);

                var cursorPos = intellisenseData.CursorPos;
                var isCursorInsideComment = intellisenseData.Comments.Where(com => com.Span.Min <= cursorPos && com.Span.Lim >= cursorPos).Any();
                if (isCursorInsideComment)
                {
                    // No intellisense for editing comment
                    return true;
                }

                return false;
            }
        }
    }
}
