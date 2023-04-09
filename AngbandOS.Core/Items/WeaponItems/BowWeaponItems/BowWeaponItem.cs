namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BowWeaponItem : WeaponItem
    {
        public override void ApplyRandomSlaying(ref IArtifactBias artifactBias)
        {
            if (artifactBias != null)
            {
                if (artifactBias.ApplySlaying(this))
                {
                    return;
                }
            }

            switch (Program.Rng.DieRoll(6))
            {
                case 1:
                case 2:
                case 3:
                    RandartItemCharacteristics.XtraMight = true;
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new RangerArtifactBias();
                    }
                    break;

                default:
                    RandartItemCharacteristics.XtraShots = true;
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new RangerArtifactBias();
                    }
                    break;
            }
        }

        public override int WieldSlot => InventorySlot.RangedWeapon;
        public override int PackSort => 32;
        public BowWeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override bool IdentityCanBeSensed => true;
        public override bool CanApplyBlowsBonus => false;
    }
}