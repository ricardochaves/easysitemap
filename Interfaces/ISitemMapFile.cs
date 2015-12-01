using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySiteMap.Interfaces
{
    public interface ISitemMapFile
    {
        string fileName { get; set; }
        IEnumerable<ISiteMapItem> itens { get; set; }
        XDocument xml {get; set;}
}
}
