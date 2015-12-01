using EasySiteMap.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySiteMap
{
    public class SiteMapConfig : ISiteMapConfig
    {
        /// <summary>
        /// Store for the LocalFile property.</summary>
        private string _localfile;

        /// <summary>
        /// Store for the TotalItensByFile property.</summary>
        private int _totalitensbyfile;

        /// <summary>
        /// Store for the Dominio property.</summary>
        private string _dominio;

        /// <summary>
        /// Dominio </summary>
        /// <value>
        /// Domain to be used in sitemap_index links.</value>
        public string Dominio
        {
            get
            {
                return _dominio;
            }

            set
            {
                _dominio = value;
            }
        }

        /// <summary>
        /// LocalFile </summary>
        /// <value>
        /// Where the files should be saved.</value>
        public string LocalFile
        {
            get
            {
                return _localfile;
            }

            set
            {
                _localfile = value;
            }
        }

        /// <summary>
        /// TotalItensByFile </summary>
        /// <value>
        /// Maximum of URLs to a file. Strongly recommended a maximum of 50,000.</value>
        public int TotalItensByFile
        {
            get
            {
                return _totalitensbyfile;
            }

            set
            {
                _totalitensbyfile = value;
            }
        }
    }
}
