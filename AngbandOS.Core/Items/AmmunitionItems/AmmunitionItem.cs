namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class AmmunitionItem : Item
    {
        public AmmunitionItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override bool IdentityCanBeSensed => true;
        public override int? GetBonusRealValue(Item item, int value)
        {
            if (item.BonusToHit + item.BonusDamage < 0)
                return null;

            int bonusValue = (item.BonusToHit + item.BonusDamage) * 5;
            if (item.DamageDice > item.Factory.Dd && item.DamageDiceSides == item.Factory.Ds)
            {
                bonusValue += (item.DamageDice - item.Factory.Dd) * item.DamageDiceSides * 5;
            }
            return bonusValue;
        }

    }
}