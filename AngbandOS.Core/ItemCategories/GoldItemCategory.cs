using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class GoldItemCategory : ItemClass
    {
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Gold;
        //public override bool IgnoredByMonsters => true;
        public override int? SubCategory => null; // No longer used by gold.
    }

}
