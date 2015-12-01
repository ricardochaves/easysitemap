using EasySiteMap.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySiteMap.Generators
{
    /// <summary>
    /// Logic which is generated throughout the body of the XML file sitemap_index.xml.</summary>
    /// <remarks>
    /// </remarks>
    class XMLIndexGenerator : IXMLIndexGenerator
    {
        private static readonly XNamespace _xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
        private static readonly XNamespace _xsi = "http://www.w3.org/2001/XMLSchema-instance";
        private static readonly string _xsilocation = "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd";


        public XDocument GenerateXMLIndex(IEnumerable<ISitemMapFile> itens, string dominio)
        {
            return new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                                                    new XElement(_xmlns + "sitemapindex",
                                                    new XAttribute("xmlns", _xmlns),
                                                    new XAttribute(XNamespace.Xmlns + "xsi", _xsi),
                                                    new XAttribute(_xsi + "schemaLocation", _xsilocation),
                                      from i in itens
                                      select CreateItemElement(i, dominio)
                                      )
                                 );
        }


        private XElement CreateItemElement(ISitemMapFile item, string dominio)
        {
            try
            {
                var itemElement = new XElement(_xmlns + "sitemap", new XElement(_xmlns + "loc", dominio.ToLowerInvariant() + "/" + item.fileName.ToLowerInvariant()));

                
                return itemElement;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro in CreateItemElement", ex);
            }
        }
    }
}
