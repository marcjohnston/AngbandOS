namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class AmmunitionItem : Item
    {
        public AmmunitionItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override bool IdentityCanBeSensed => true;
        public override int? GetBonusRealValue(int value)
        {
            if (BonusToHit + BonusDamage < 0)
                return null;

            int bonusValue = (BonusToHit + BonusDamage) * 5;
            if (DamageDice > Factory.Dd && DamageDiceSides == Factory.Ds)
            {
                bonusValue += (DamageDice - Factory.Dd) * DamageDiceSides * 5;
            }
            return bonusValue;
        }

    }
}