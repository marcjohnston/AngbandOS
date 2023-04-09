namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class JewelleryItem : Item
    {
        public JewelleryItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int? GetBonusRealValue(int value)
        {
            if (BonusArmourClass < 0 || BonusToHit < 0 || BonusDamage < 0)
                return 0;

            return (BonusToHit + BonusDamage + BonusArmourClass) * 100;
        }

    }
}