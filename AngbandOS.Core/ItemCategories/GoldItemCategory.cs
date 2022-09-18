using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class GoldItemCategory : BaseItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Gold;
        //public override bool IgnoredByMonsters => true;
    }

}
