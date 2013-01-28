// -----------------------------------------------------------------------
// <copyright file="CartDeliveryAddress.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace SHBusinessLogic.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CartDeliveryAddress
    {
        public string Region { get; private set; }

        public string City { get; private set; }

        public string Address { get; private set; }

        public string PostCode { get; private set; }

        public CartDeliveryAddress()
        {
            this.Region = this.City = this.Address = this.PostCode = string.Empty;
        }

        public CartDeliveryAddress(string region, string city, string address, string postCode)
        {
            if (string.IsNullOrEmpty(region) || string.IsNullOrEmpty(city)
                || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(postCode))
            {
                throw new ArgumentException(@"No one field 'CartDeliveryAddress' should be empty!");
            }

            this.Region = region;
            this.City = city;
            this.Address = address;
            this.PostCode = postCode;
        }
    }
}
