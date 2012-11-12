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
    }
}
