using Cthangband.Enumerations;

namespace Cthangband.ArtifactBiases
{
    internal class WisdomArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (item.RandartFlags1.IsClear(ItemFlag1.Wis))
            {
                item.RandartFlags1.Set(ItemFlag1.Wis);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.SustWis))
            {
                item.RandartFlags2.Set(ItemFlag2.SustWis);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
