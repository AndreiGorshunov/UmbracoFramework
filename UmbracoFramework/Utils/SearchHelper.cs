using umbraco.MacroEngines;

namespace UmbracoFramework.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class SearchHelper
    {
        public static dynamic GetHomeNode(dynamic model)
        {
            return model.AncestorOrSelf("Home");
        }

        public static DynamicNode GetHomeNodeStrongTyped(DynamicNode model)
        {
            return model.AncestorOrSelf("Home");
        }

        public static dynamic GetNodeByName(DynamicNode model, string name)
        {
            return GetHomeNodeStrongTyped(model).Descendants(
                x => string.Compare(x.Name, name, true) == 0).Items.FirstOrDefault();
        }

        public static DynamicNode GetNodeByNameStrongTyped(DynamicNode model, string name)
        {
            return (DynamicNode)GetNodeByName(model, name);
        }

        public static dynamic GetNodeByNameRelative(DynamicNode model, string name)
        {
            return model.Descendants(
                x => string.Compare(x.Name, name, true) == 0).Items.FirstOrDefault();
        }

        public static DynamicNode GetNodeByNameRelativeStrongTyped(DynamicNode model, string name)
        {
            return (DynamicNode)GetNodeByNameRelative(model, name);
        }
    }
}
