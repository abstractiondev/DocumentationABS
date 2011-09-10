using System;
using System.Linq;

namespace Documentation_v1_0
{
    public static class HeaderTypeExt
    {
        public static void AddSubHeader(this HeaderType header, HeaderType subHeader)
        {
            HeaderType[] content = (header.Header ?? new HeaderType[0]).Union(
                new[]
                    {
                        subHeader
                    }).ToArray();
            header.Header = content;
        }

        public static void AddSubHeaderTextContent(this HeaderType header, string headerText, string styleName, string textContent)
        {
            if (header == null)
                throw new ArgumentNullException("header");
            HeaderType subHeader = new HeaderType
                                       {
                                           text = headerText,
                                           level = header.level + 1,
                                       };
            subHeader.AddHeaderTextContent(styleName, textContent);
            header.AddSubHeader(subHeader);
        }

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