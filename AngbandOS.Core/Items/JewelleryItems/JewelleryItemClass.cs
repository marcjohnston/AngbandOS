namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    /// <summary>
    /// Represents jewellery items.  Amulets and rings are both armour classes.
    /// </summary>
    internal abstract class JewelleryItemClass : ItemFactory
    {
        public JewelleryItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool IsWorthless(Item item)
        {
            if (item.TypeSpecificValue < 0 || item.BonusArmourClass < 0 || item.BonusToHit < 0 || item.BonusDamage < 0)
            {
                return true;
            }
            return false;
        }
    }
}
