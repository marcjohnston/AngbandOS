using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class ConstitutionArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (item.RandartFlags1.IsClear(ItemFlag1.Con))
            {
                item.RandartFlags1.Set(ItemFlag1.Con);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.SustCon))
            {
                item.RandartFlags2.Set(ItemFlag2.SustCon);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
