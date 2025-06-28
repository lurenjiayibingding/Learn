using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeContract
{
    public sealed class Item
    {
    };

    public sealed class ShoppingCart
    {
        private List<Item> m_cart = new List<Item>();
        private Decimal m_totalCost = 0;

        public ShoppingCart()
        {

        }

        public void AddItem(Item item)
        {
            try
            {
                AddItemHelper(m_cart, item, ref m_totalCost);
            }
            catch (IOException ex)
            {
            }
            catch (Exception ex)
            {

            }
        }

        private static void AddItemHelper(List<Item> m_cart, Item newItem, ref Decimal totalCost)
        {
            Contract.Requires<IOException>(newItem != null);
            Contract.Requires(Contract.ForAll(m_cart, n => n != newItem));

            Contract.Ensures(Contract.Exists(m_cart, n => n == newItem));
            Contract.Ensures(totalCost >= Contract.OldValue(totalCost));
            Contract.EnsuresOnThrow<IOException>(totalCost == Contract.OldValue(totalCost));

            m_cart.Add(newItem);
            totalCost += 1.0M;

            Contract.ContractFailed += Contract_ContractFailed;
        }

        private static void Contract_ContractFailed(object sender, ContractFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(m_totalCost >= 0);
        }
    };
}
