using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class BookItemCategory : BaseItemCategory
    {
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
