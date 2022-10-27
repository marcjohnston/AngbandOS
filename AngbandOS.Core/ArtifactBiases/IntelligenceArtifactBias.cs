using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class IntelligenceArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (item.RandartFlags1.IsClear(ItemFlag1.Int))
            {
                item.RandartFlags1.Set(ItemFlag1.Int);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.SustInt))
            {
                item.RandartFlags2.Set(ItemFlag2.SustInt);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
