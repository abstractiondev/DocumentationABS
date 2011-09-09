using System;
using System.Linq;

namespace Documentation_v1_0
{
    public static class HeaderTypeExt
    {
        public static void SetHeaderTextContent(this HeaderType header, string styleName, string textContent)
        {
            if(header == null)
                throw new ArgumentNullException("header");
            header.AddHeaderTextContent(styleName, textContent);
        }

        public static void AddHeaderTextContent(this HeaderType header, string styleName, string textContent)
        {
            if (header == null)
                throw new ArgumentNullException("header");
            TextType[] content = (header.Paragraph ?? new TextType[0]).Union(
                new[]
                    {
                        new TextType
                            {
                                styleRef = styleName,
                                TextContent = textContent
                            }
                    }).ToArray();
            header.Paragraph = content;
        }
    }
}