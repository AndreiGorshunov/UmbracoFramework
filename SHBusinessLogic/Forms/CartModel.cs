// -----------------------------------------------------------------------
// <copyright file="CartModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using SHBusinessLogic.Entities;

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

        private int currentStep;

        public CartModel()
        {
            this.CurrentStep = 1;
            this.IsModelValid = true;
            this.Items = new List<CartItem>();
        }

        public int CurrentStep
        {
            get { return this.currentStep; }
            set { this.currentStep = value < 1 || value > 5 ? 1 : value; }
        }

        public bool IsModelValid { get; set; }

        public CartPersonalData PersonalData { get; set; }

        public CartDeliveryAddress DeliveryAddress { get; set; }

        public CartDeliveryKind? DeliveryKind { get; set; }

        public CartBillingKind? BillingKind { get; set; }

        public readonly List<CartItem> Items;

        public string BackUrl { get; set; }

        public void AddItem(CartItem item)
        {
            if (item != null)
            {
                if (!this.Items.Contains(item))
                {
                    this.Items.Add(item);
                }
                else
                {
                    this.Items.Find(x => x.Id == item.Id).StuffsCount++;
                }
            }
        }

        public void RemoveItem(CartItem item)
        {
            if (item != null)
            {
                if (this.Items.Contains(item))
                {
                    this.Items.Remove(item);
                }
            }
        }
    }
}
