using System;
using System.Linq;

namespace Documentation_v1_0
{
    public static class DocumentTypeExt
    {
        public static void AddHeader(this DocumentType document, HeaderType header)
        {
            if(document == null)
                throw new ArgumentNullException("document");
            if (header == null)
                return;
            HeaderType[] content = (document.Content ?? new HeaderType[0]).Union(
                new []
                    {
                        header
                    }).ToArray();
            document.Content = content;
        }
    }
}