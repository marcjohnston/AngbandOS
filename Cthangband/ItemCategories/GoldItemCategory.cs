using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal abstract class GoldItemCategory : BaseItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Gold;
        //public override bool IgnoredByMonsters => true;
    }

}
