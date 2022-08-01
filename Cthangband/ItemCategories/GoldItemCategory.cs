using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class GoldItemCategory : BaseItemCategory
    {
        public GoldItemCategory() : base(ItemCategory.Gold)
        {
        }
        //public override bool IgnoredByMonsters => true;
    }

}
