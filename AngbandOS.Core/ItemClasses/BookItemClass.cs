using AngbandOS.Enumerations;

using System;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class BookItemClass : ItemClass
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
