using Cthangband.Enumerations;

namespace Cthangband.ArtifactBiases
{
    internal class AcidArtifactBias : ArtifactBias
    {
        public override bool ApplyRandomResistances(Item item)
        {
            if (item.RandartFlags2.IsClear(ItemFlag2.ResAcid))
            {
                item.RandartFlags2.Set(ItemFlag2.ResAcid);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (Program.Rng.DieRoll(ImmunityLuck) == 1 && item.RandartFlags2.IsClear(ItemFlag2.ImAcid))
            {
                item.RandartFlags2.Set(ItemFlag2.ImAcid);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public override bool ApplySlaying(Item item)
        {
            if (item.Category != ItemCategory.Bow)
            {
                if (item.RandartFlags1.IsClear(ItemFlag1.BrandAcid))
                {
                    item.RandartFlags1.Set(ItemFlag1.BrandAcid);
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
