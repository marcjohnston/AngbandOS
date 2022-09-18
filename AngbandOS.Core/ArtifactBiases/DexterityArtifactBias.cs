using AngbandOS.Enumerations;

namespace AngbandOS.ArtifactBiases
{
    internal class DexterityArtifactBias : ArtifactBias
    {
        public override bool ApplyBonuses(Item item)
        {
            if (item.RandartFlags1.IsClear(ItemFlag1.Dex))
            {
                item.RandartFlags1.Set(ItemFlag1.Dex);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplyMiscPowers(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.SustDex))
            {
                item.RandartFlags2.Set(ItemFlag2.SustDex);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
