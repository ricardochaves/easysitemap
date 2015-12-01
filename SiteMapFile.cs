using EasySiteMap.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySiteMap
{
    class SiteMapFile : ISitemMapFile
    {
        /// <summary>
        /// Store for the fileName property.</summary>
        private string _filename;

        /// <summary>
        /// Store for the itens property.</summary>
        private List<ISiteMapItem> _itens;

        /// <summary>
        /// Store for the xml property.</summary>
        private XDocument _xml;

        /// <summary>
        /// fileName </summary>
        /// <value>
        /// File name.</value>
        public string fileName
        {
            get
            {
                return _filename;
            }

            set
            {
                _filename = value;
            }
        }

        /// <summary>
        /// itens </summary>
        /// <value>
        /// All URLs belonging to the file.</value>
        public IEnumerable<ISiteMapItem> itens
        {
            get
            {
                return _itens;
            }

            set
            {
                _itens = value.ToList();
            }
        }

        /// <summary>
        /// xml </summary>
        /// <value>
        /// The content in the xml file.</value>
        public XDocument xml
        {
            get
            {
                return _xml;
            }

            set
            {
                _xml = value;
            }
        }
    }
}
