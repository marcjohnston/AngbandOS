namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class JewelleryItem : Item
    {
        public JewelleryItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int? GetBonusRealValue(Item item, int value)
        {
            if (item.BonusArmourClass < 0 || item.BonusToHit < 0 || item.BonusDamage < 0)
                return 0;

            return (item.BonusToHit + item.BonusDamage + item.BonusArmourClass) * 100;
        }

    }
}