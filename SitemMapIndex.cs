using EasySiteMap.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySiteMap
{
    class SitemMapIndex : ISiteMapIndex
    {
        private XDocument _xml;
        private ISiteMapConfig _config;
        private List<ISitemMapFile> _files = new List<ISitemMapFile>();
        private IXMLUrlGenerator _UrlXMLGenerator;
        private IXMLIndexGenerator _IndexXMLGenerator;
        private List<ISiteMapItem> _urls = new List<ISiteMapItem>();

        public SitemMapIndex(IXMLUrlGenerator UrlXMLGenerator, IXMLIndexGenerator IndexXMLGenerator, ISiteMapConfig config)
        {
            _config = config;
            _UrlXMLGenerator = UrlXMLGenerator;
            _IndexXMLGenerator = IndexXMLGenerator;
        }

        public ISiteMapConfig Config
        {
            get
            {
                return _config;
            }

            set
            {
                _config = value;
            }
        }

        public IEnumerable<ISitemMapFile> Files
        {
            get
            {
                return _files;
            }

            set
            {
                _files = value.ToList();
            }
        }

        public IEnumerable<ISiteMapItem> AllUrls
        {
            get
            {
                return _urls;
            }

            set
            {
                _urls = value.ToList();
            }
        }

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

        private void SplitFiles()
        {

            List<SiteMapItem> itensFile = new List<SiteMapItem>();

            int cont = 0;

            foreach (var item in _urls)
            {
                itensFile.Add((SiteMapItem)item);
                cont = cont + 1;

                if (cont == _config.TotalItensByFile)
                {
                    _files.Add(new SiteMapFile() { itens = itensFile, fileName = String.Format("sitemap{0}.xml",_files.Count()+1) });
                    cont = 0;
                    itensFile = new List<SiteMapItem>();
                }
            }

            if (itensFile.Count > 0) { _files.Add(new SiteMapFile() { itens = itensFile, fileName = String.Format("sitemap{0}.xml", _files.Count() + 1) }); }

        }

        private void GenerateXMLFile()
        {
            foreach (var item in _files)
            {
                item.xml = _UrlXMLGenerator.GenerateXMLUrls(item.itens);
            }

            _xml = _IndexXMLGenerator.GenerateXMLIndex(_files, Config.Dominio);
        }

        public void ProcessURL()
        {
            SplitFiles();
            GenerateXMLFile();
        }
    }
}
