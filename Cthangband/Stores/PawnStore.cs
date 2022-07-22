using Cthangband.Enumerations;
using System;
using System.Security.Policy;
using System.Windows.Documents;

namespace Cthangband.Stores
{
    [Serializable]
    internal class PawnStore : Store
    {
        public PawnStore() : base(StoreType.StorePawn)
        {
        }

        public override string FeatureType => "Pawnbrokers";

        protected override bool StoreWillBuy(Item item)
        {
            return item.Value() > 0;
        }
        protected override bool HasStoreTable => false;
        
        protected override bool MaintainsStockLevels => false;
        public override bool ShufflesOwnersAndPricing => false;
        protected override string BoughtVerb => "pawn";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        /// <param name="trueToMarkDownFalseToMarkUp"></param>
        /// <returns></returns>
        /// <remarks>
        /// Per Dean Anderson, 7/22/2022
        /// The pawn shop both buys and sells cheaply. The whole idea is that if you need cash you can pawn items
        /// (for less money than you could sell them for), in the knowledge that the shop will hold onto them and then buy
        /// them back later for the amount you pawned them for. If retrieving your items from the pawn shop had a
        /// markup then you'd be better off just selling them  normally and buying new ones to replace them.
        /// </remarks>
        protected override int AdjustPrice(int price, bool trueToMarkDownFalseToMarkUp)
        {
            if (trueToMarkDownFalseToMarkUp == true)
            {
                return price / 3;
            }
            else
            {
                return price / 3;
            }
        }
    }
}
