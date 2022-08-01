using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;
using Cthangband.StaticData;

namespace Cthangband.ItemCategories
{
    /// <summary>
    /// Represents jewellery items.  Amulets and rings are both armour classes.
    /// </summary>
    internal class JewelleryItemCategory : BaseItemCategory
    {
        //public override bool HasAdditionalTypeSpecificValue => true;
        //public override int GetBonusValue(Item item, int value) => (item.BonusToHit + item.BonusDamage + item.BonusArmourClass) * 100;
        //public override bool IsWorthless(Item item)
        //{
        //    if (item.TypeSpecificValue < 0)
        //    {
        //        return true;
        //    }
        //    if (item.BonusArmourClass < 0)
        //    {
        //        return true;
        //    }
        //    if (item.BonusToHit < 0)
        //    {
        //        return true;
        //    }
        //    if (item.BonusDamage < 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}       
    }
}
