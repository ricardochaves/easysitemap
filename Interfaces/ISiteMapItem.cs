using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySiteMap.Interfaces
{
    public interface ISiteMapItem
    {
        string URL { get; set; }
        double? Priority { get; set; }
        ChangeFrequency? ChangeFrequency {get; set;}
        DateTime? LastModified { get; set; }

    }
}
