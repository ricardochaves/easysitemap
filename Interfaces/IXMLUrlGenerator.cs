using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySiteMap.Interfaces
{
    public interface IXMLUrlGenerator
    {
        XDocument GenerateXMLUrls(IEnumerable<ISiteMapItem> itens);
    }
}
