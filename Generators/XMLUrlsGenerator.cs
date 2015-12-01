using EasySiteMap.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySiteMap.Generators
{

    /// <summary>
    /// Logic which is generated throughout the body of the XML file sitemap.xml.</summary>
    /// <remarks>
    /// </remarks>
    public class XMLUrlsGenerator : IXMLUrlGenerator
    {

        private static readonly XNamespace _xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
        private static readonly XNamespace _xsi = "http://www.w3.org/2001/XMLSchema-instance";
        private static readonly string _xsilocation = "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd";


        public XDocument GenerateXMLUrls(IEnumerable<ISiteMapItem> itens)
        {
            return new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                                                    new XElement(_xmlns + "urlset",
                                                    new XAttribute("xmlns", _xmlns),
                                                    new XAttribute(XNamespace.Xmlns + "xsi", _xsi),
                                                    new XAttribute(_xsi + "schemaLocation", _xsilocation),
                                      from i in itens
                                      select CreateItemElement(i)
                                      )
                                 );
        }


        private XElement CreateItemElement(ISiteMapItem item)
        {
            try
            {
                var itemElement = new XElement(_xmlns + "url", new XElement(_xmlns + "loc", item.URL.ToLowerInvariant()));

                // all other elements are optional

                if (item.LastModified.HasValue)
                    itemElement.Add(new XElement(_xmlns + "lastmod", item.LastModified.Value.ToString("yyyy-MM-dd")));

                if (item.ChangeFrequency.HasValue)
                    itemElement.Add(new XElement(_xmlns + "changefreq", item.ChangeFrequency.Value.ToString().ToLower()));

                if (item.Priority.HasValue)
                    itemElement.Add(new XElement(_xmlns + "priority", item.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));

                return itemElement;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro in CreateItemElement", ex);
            }
        }
    }
}
