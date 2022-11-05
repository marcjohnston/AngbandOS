using AngbandOS.Enumerations;
using AngbandOS.StaticData;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class BookItemCategory : BaseItemCategory
    {
        /// <summary>
        /// Returns true for all books.
        /// </summary>
        public override bool EasyKnow => true;

        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 50)
            {
                return MassRoll(2, 3) + 1;
            }
            if (cost <= 500)
            {
                return MassRoll(1, 3) + 1;
            }
            return 0;
        }
    }
}
