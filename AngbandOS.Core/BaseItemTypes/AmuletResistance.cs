using AngbandOS.ArtifactBiases;
using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletResistance : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Resistance";

        public override int Chance1 => 4;
        public override int Cost => 25000;
        public override string FriendlyName => "Resistance";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override bool ResAcid => true;
        public override bool ResCold => true;
        public override bool ResElec => true;
        public override bool ResFire => true;
        public override int Weight => 3;

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (Program.Rng.DieRoll(3) == 1)
            {
                IArtifactBias? artifactBias = null;
                item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
            }
            if (Program.Rng.DieRoll(5) == 1)
            {
                item.RandartFlags2.Set(ItemFlag2.ResPois);
            }
        }

        public override bool KindIsGood => true;
    }
}
