using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySiteMap.Interfaces
{
    public interface ISiteMapIndex
    {
        ISiteMapConfig Config { get; set; }
        IEnumerable<ISitemMapFile> Files { get; set; }
        IEnumerable<ISiteMapItem> AllUrls { get; set; }
        void ProcessURL();
        XDocument xml { get; set; }
    }
}
