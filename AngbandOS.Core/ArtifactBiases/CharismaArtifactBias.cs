using Cthangband.Enumerations;

namespace Cthangband.ArtifactBiases
{
    internal class CharismaArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (item.RandartFlags1.IsClear(ItemFlag1.Cha))
            {
                item.RandartFlags1.Set(ItemFlag1.Cha);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public override bool ApplyMiscPowers(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.SustCha))
            {
                item.RandartFlags2.Set(ItemFlag2.SustCha);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
