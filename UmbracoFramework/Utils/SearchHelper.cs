using umbraco;
using umbraco.MacroEngines;
using umbraco.NodeFactory;

namespace UmbracoFramework.Utils
{
    using System;
    using System.Linq;

    public static class SearchHelper
    {
        private static Node _homeNode;
        public static Node HomeNode
        {
            get
            {
                return _homeNode ?? (_homeNode = uQuery.GetNodesByXPath("descendant::*[@nodeName='Home']").FirstOrDefault());
            }
        }

        public static dynamic GetHomeNode(dynamic model)
        {
            return model.AncestorOrSelf("Home");
        }

        public static DynamicNode GetHomeNodeStrongTyped(DynamicNode model)
        {
            return model.AncestorOrSelf("Home");
        }

        public static Node GetNodeByName(string name)
        {
            return uQuery.GetNodesByXPath(string.Format("descendant::*[@nodeName='{0}']", name)).FirstOrDefault();
        }

        public static dynamic GetNodeByName(DynamicNode model, string name)
        {
            return GetHomeNodeStrongTyped(model).Descendants(
                x => string.Compare(x.Name, name, StringComparison.OrdinalIgnoreCase) == 0).Items.FirstOrDefault();
        }

        public static DynamicNode GetNodeByNameStrongTyped(DynamicNode model, string name)
        {
            return (DynamicNode)GetNodeByName(model, name);
        }

        public static dynamic GetNodeByNameRelative(DynamicNode model, string name)
        {
            return model.Descendants(
                x => string.Compare(x.Name, name, StringComparison.OrdinalIgnoreCase) == 0).Items.FirstOrDefault();
        }

        public static DynamicNode GetNodeByNameRelativeStrongTyped(DynamicNode model, string name)
        {
            return (DynamicNode)GetNodeByNameRelative(model, name);
        }
    }
}
