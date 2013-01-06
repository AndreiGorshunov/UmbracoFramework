// -----------------------------------------------------------------------
// <copyright file="CartModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace SHBusinessLogic.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CartModel
    {
        public static string SessionKey = "SH.Form.Cart";

        public CartModel()
        {
            this.ItemIds = new List<int>();
        }

        public List<int> ItemIds { get; private set; }

        public string BackUrl { get; set; }
    }
}
