// -----------------------------------------------------------------------
// <copyright file="CartPersonalData.cs" company="">
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
    public class CartPersonalData
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public CartPersonalData()
        {
            this.FirstName = this.LastName = this.Email = this.Phone = string.Empty;
        }

        public CartPersonalData(string firstName, string lastName, string email, string phone)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)
                || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                throw new ArgumentException(@"No one field 'CartPersonalData' should be empty!");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
        }
    }
}
