using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletOfTheMagi : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "the Magi";

        public override int Chance1 => 4;
        public override int Chance2 => 3;
        public override int Cost => 30000;
        public override bool FreeAct => true;
        public override string FriendlyName => "the Magi";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Locale2 => 80;
        public override bool Search => true;
        public override bool SeeInvis => true;
        public override int ToA => 3;
        public override int Weight => 3;

        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            item.BonusArmourClass = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            if (Program.Rng.DieRoll(3) == 1)
            {
                item.RandartFlags3.Set(ItemFlag3.SlowDigest);
            }
            if (item.SaveGame.Level != null)
            {
                item.SaveGame.Level.TreasureRating += 25;
            }
        }

        public override bool KindIsGood => true;
    }
}
