namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class WeaponItem : Item
    {
        public WeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override bool CanApplyBlowsBonus => true;
        public override bool CanApplyBonusArmourClassMiscPower => true;
        public override int? GetBonusRealValue(Item item, int value)
        {
            if (item.BonusToHit + item.BonusDamage < 0)
                return null;

            int bonusValue = 0;
            bonusValue += (item.BonusToHit + item.BonusDamage + item.BonusArmourClass) * 100;
            if (item.DamageDice > item.BaseItemCategory.Dd && item.DamageDiceSides == item.BaseItemCategory.Ds)
            {
                bonusValue += (item.DamageDice - item.BaseItemCategory.Dd) * item.DamageDiceSides * 100;
            }
            return bonusValue;
        }
    }
}