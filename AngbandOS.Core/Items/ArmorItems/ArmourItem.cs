namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ArmourItem : Item
    {
        public ArmourItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override bool IdentityCanBeSensed => true;
        public override int? GetBonusRealValue(int value)
        {
            if (BonusArmourClass < 0)
                return null;

            return (BonusToHit + BonusDamage + BonusArmourClass) * 100;
        }

    }
}