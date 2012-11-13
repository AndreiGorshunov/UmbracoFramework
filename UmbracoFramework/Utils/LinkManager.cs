using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.MacroEngines;
using umbraco.MacroEngines.Library;
using umbraco.NodeFactory;

namespace UmbracoFramework.Utils
{
    public static class LinkManager
    {
        public static string GetLinkUrl(dynamic linkProperty, out bool isInternal)
        {
            dynamic link = linkProperty.BaseElement.Element("link");
            if (link.Attribute("type").Value == "internal")
            {
                int relatedNodeId = int.Parse(link.Attribute("link").Value);
                dynamic relatedNode = new RazorLibraryCore(Node.GetCurrent()).NodeById(relatedNodeId);
                isInternal = true;
                return relatedNode.Url;
            }

            isInternal = false;
            return link.Attribute("link").Value;
        }

        public static IEnumerable<string> GetInternalLinkUrls(dynamic linksProperty)
        {
            var urls = new List<string>();
            var library = new RazorLibraryCore(Node.GetCurrent());
            dynamic links = linksProperty.BaseElement.Elements("link");
            foreach (dynamic link in links)
            {
                if (link.Attribute("type").Value == "internal")
                {
                    int relatedNodeId = int.Parse(link.Attribute("link").Value);
                    dynamic relatedNode = library.NodeById(relatedNodeId);
                    urls.Add((string)relatedNode.Url);
                }
            }

            return urls;
        }

        public static dynamic GetLinkedNode(dynamic linkProperty)
        {
            dynamic link = linkProperty.BaseElement.Element("link");
            if (link.Attribute("type").Value == "internal")
            {
                int relatedNodeId = int.Parse(link.Attribute("link").Value);
                return new RazorLibraryCore(Node.GetCurrent()).NodeById(relatedNodeId);
            }

            return null;
        }

        public static IEnumerable<dynamic> GetInternalLinkNodes(dynamic linksProperty)
        {
            var nodes = new List<dynamic>();
            var library = new RazorLibraryCore(Node.GetCurrent());
            dynamic links = linksProperty.BaseElement.Elements("link");
            foreach (dynamic link in links)
            {
                if (link.Attribute("type").Value == "internal")
                {
                    int relatedNodeId = int.Parse(link.Attribute("link").Value);
                    nodes.Add(library.NodeById(relatedNodeId));
                }
            }

            return nodes;
        }
    }
}
