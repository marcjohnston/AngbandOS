namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class WeaponItem : Item
    {
        public WeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override bool CanApplyBlowsBonus => true;
        public override bool CanApplyBonusArmourClassMiscPower => true;
        public override int? GetBonusRealValue(int value)
        {
            if (BonusToHit + BonusDamage < 0)
                return null;

            int bonusValue = 0;
            bonusValue += (BonusToHit + BonusDamage + BonusArmourClass) * 100;
            if (DamageDice > Factory.Dd && DamageDiceSides == Factory.Ds)
            {
                bonusValue += (DamageDice - Factory.Dd) * DamageDiceSides * 100;
            }
            return bonusValue;
        }
    }
}