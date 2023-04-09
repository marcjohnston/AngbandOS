namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ArmourItem : Item
    {
        public ArmourItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override bool IdentityCanBeSensed => true;
        public override int? GetBonusRealValue(Item item, int value)
        {
            if (item.BonusArmourClass < 0)
                return null;

            return (item.BonusToHit + item.BonusDamage + item.BonusArmourClass) * 100;
        }

    }
}