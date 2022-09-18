using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class StrengthArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (item.RandartFlags1.IsClear(ItemFlag1.Str))
            {
                item.RandartFlags1.Set(ItemFlag1.Str);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public override bool ApplyMiscPowers(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.SustStr))
            {
                item.RandartFlags2.Set(ItemFlag2.SustStr);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
