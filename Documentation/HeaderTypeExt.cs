using System;
using System.Linq;

namespace Documentation_v1_0
{
    public static class HeaderTypeExt
    {
        public static void AddSubHeader(this HeaderType header, HeaderType subHeader)
        {
            if(header == null)
                throw new ArgumentNullException("header");
            if (subHeader == null)
                return;
            HeaderType[] content = (header.Header ?? new HeaderType[0]).Union(
                new[]
                    {
                        subHeader
                    }).ToArray();
            header.Header = content;
        }

        public static void AddSubHeaderTableContent(this HeaderType header, string headerText, TableType tableContent)
        {
            if(header == null)
                throw new ArgumentNullException("header");
            HeaderType subHeader = new HeaderType
            {
                text = headerText,
                level = header.level + 1,
            };
            subHeader.AddHeaderTableContent(tableContent);
            header.AddSubHeader(subHeader);
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

        public static void AddHeaderTableContent(this HeaderType header, TableType tableContent)
        {
            if (header == null)
                throw new ArgumentNullException("header");
            ParagraphType[] content = (header.Paragraph ?? new ParagraphType[0]).Union(
                new ParagraphType[]
                    {
                        new ParagraphType
                            {
                                Item = tableContent
                            }

                    }).ToArray();
            header.Paragraph = content;
        }

        public static void AddHeaderTextContent(this HeaderType header, string styleName, string textContent)
        {
            if (header == null)
                throw new ArgumentNullException("header");
            ParagraphType[] content = (header.Paragraph ?? new ParagraphType[0]).Union(
                new ParagraphType[]
                    {
                        new ParagraphType
                            {
                                Item =          new TextType
                                                    {
                                                        styleRef = styleName,
                                                        TextContent = textContent
                                                    }
                            }

                    }).ToArray();
            header.Paragraph = content;
        }
    }
}