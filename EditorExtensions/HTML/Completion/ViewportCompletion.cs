﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Utilities;
using Microsoft.Web.Editor;
using Microsoft.Html.Editor.Completion.Def;
using Microsoft.Web.Core.ContentTypes;

namespace MadsKristensen.EditorExtensions.Html
{
    [HtmlCompletionProvider(CompletionTypes.Values, "meta", "content")]
    [ContentType(HtmlContentTypeDefinition.HtmlContentType)]
    public class ViewportCompletion : StaticListCompletion
    {
        protected override string KeyProperty { get { return "name"; } }
        public ViewportCompletion()
            : base(new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "viewport", Values(
                    "width=device-width, initial-scale=1.0", 
                    "width=device-width, initial-scale=1.0, user-scalable=no", 
                    "width=device-width, initial-scale=1.0, maximum-scale=1", 
                    "width=device-width, initial-scale=1.0, minimum-scale=1"
                )}
            }) { }
    }
}
