using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySiteMap.Interfaces
{
    public interface ISiteMapConfig
    {
        int TotalItensByFile { get; set; }
        string LocalFile { get; set; }
        string Domain { get; set; }
        void ValidateData();
    }
}
