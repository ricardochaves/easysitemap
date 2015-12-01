using EasySiteMap.Generators;
using EasySiteMap.Interfaces;
using EasySiteMap.IO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasySiteMap
{
    public class EasySiteMapGenerator : IGenerator
    {
        
        private ISiteMapConfig _config;
        private SitemMapIndex _siteIndex;
        private IWriteFileXML _writeFile;

        public EasySiteMapGenerator(ISiteMapConfig config)
        {
            _config = config;
            _siteIndex = new SitemMapIndex(new XMLUrlsGenerator(), new XMLIndexGenerator(), config);
            _writeFile = new WriteFileXML();
        }
        public EasySiteMapGenerator(ISiteMapConfig config, IXMLUrlGenerator generetorUrl)
        {
            _config = config;
            _siteIndex = new SitemMapIndex(generetorUrl, new XMLIndexGenerator(), config);
            _writeFile = new WriteFileXML();

        }
        public EasySiteMapGenerator(ISiteMapConfig config, IXMLUrlGenerator generetorUrl, IXMLIndexGenerator generatorIndex)
        {
            _config = config;
            _siteIndex = new SitemMapIndex(generetorUrl, generatorIndex, config);
            _writeFile = new WriteFileXML();

        }
        public EasySiteMapGenerator(ISiteMapConfig config, IXMLUrlGenerator generetorUrl, IXMLIndexGenerator generatorIndex, IWriteFileXML writeFile)
        {
            _config = config;
            _siteIndex = new SitemMapIndex(generetorUrl, generatorIndex, config);
            _writeFile = writeFile;
        }

        public void GenerateSiteMap(IEnumerable<ISiteMapItem> siteItens)
        {
            try
            {
                _siteIndex.AllUrls = siteItens;
                _siteIndex.ProcessURL();

                GravarXMLs(_siteIndex);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro in GenerateSiteMap.", ex);
            }
        }
        

        private void GravarXMLs(SitemMapIndex index)
        {
         if (index.Files.Count() == 1)
            {                
                _writeFile.WriteFile(index.Files.FirstOrDefault().xml, index.Config.LocalFile + "sitemap.xml");
            }
            else
            {
                foreach (var item in index.Files)
                {
                    _writeFile.WriteFile(item.xml, index.Config.LocalFile + item.fileName);
                }
            }
            _writeFile.WriteFile(index.xml, index.Config.LocalFile + "sitemap_index.xml");
        }
    }
}
