// -----------------------------------------------------------------------
// <copyright file="CartItem.cs" company="">
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
    public class CartItem : IEquatable<CartItem>
    {
        public int Id { get; private set; }

        public int StuffsCount { get; set; }

        public Dictionary<string, string> Params { get; private set; }

        public CartItem(int id, Dictionary<string, string> param = null)
        {
            this.Id = id;
            this.StuffsCount = 1;
            this.Params = param ?? new Dictionary<string, string>();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (CartItem)) return false;
            return Equals((CartItem) obj);
        }


        public bool Equals(CartItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id && ParamsEquals(other.Params, Params);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id*397) ^ (Params != null ? Params.GetHashCode() : 0);
            }
        }

        public bool ParamsEquals(Dictionary<string, string> params1, Dictionary<string, string> params2)
        {
            return params1.Keys.Aggregate((s, x) => s + x) == params2.Keys.Aggregate((s, x) => s + x)
                && params1.Values.Aggregate((s, x) => s + x) == params2.Values.Aggregate((s, x) => s + x);
        }
    }
}
