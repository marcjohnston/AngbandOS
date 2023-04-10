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

        public override void ApplyMagic(int level, int power)
        {
            if (power == 0)
            {
                return;
            }

            int tohit1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            int todam1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            int tohit2 = GetBonusValue(10, level);
            int todam2 = GetBonusValue(10, level);
            if (power > 0)
            {
                BonusToHit += tohit1;
                BonusDamage += todam1;
                if (power > 1)
                {
                    BonusToHit += tohit2;
                    BonusDamage += todam2;
                }
            }
            else if (power < 0)
            {
                BonusToHit -= tohit1;
                BonusDamage -= todam1;
                if (power < -1)
                {
                    BonusToHit -= tohit2;
                    BonusDamage -= todam2;
                }
                if (BonusToHit + BonusDamage < 0)
                {
                    IdentCursed = true;
                }
            }
        }

        public override void ApplyRandartBonus()
        {
            BonusToHit += Program.Rng.DieRoll(BonusToHit > 19 ? 1 : 20 - BonusToHit);
            BonusDamage += Program.Rng.DieRoll(BonusDamage > 19 ? 1 : 20 - BonusDamage);
        }
    }
}