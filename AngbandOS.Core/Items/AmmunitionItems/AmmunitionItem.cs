namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class AmmunitionItem : Item
    {
        public AmmunitionItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override bool IdentityCanBeSensed => true;
        public override int? GetBonusRealValue(Item item, int value)
        {
            if (item.BonusToHit + item.BonusDamage < 0)
                return null;

            int bonusValue = (item.BonusToHit + item.BonusDamage) * 5;
            if (item.DamageDice > item.BaseItemCategory.Dd && item.DamageDiceSides == item.BaseItemCategory.Ds)
            {
                bonusValue += (item.DamageDice - item.BaseItemCategory.Dd) * item.DamageDiceSides * 5;
            }
            return bonusValue;
        }

    }
}