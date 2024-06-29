// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class RangedWeaponItemFactory : WeaponItemFactory // TODO: Should be renamed to RangedWeaponItemClass
{
    /// <summary>
    /// Returns the ranged weapon inventory slot for bows.
    /// </summary>
    public override int WieldSlot => InventorySlot.RangedWeapon;

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override bool IsRangedWeapon => true;

    public override void ApplySlayingForRandomArtifactCreation(Item item)
    {
        if (item.Characteristics.ArtifactBias != null)
        {
            if (item.Characteristics.ArtifactBias.ApplySlaying(item))
            {
                return;
            }
        }

        switch (Game.DieRoll(6))
        {
            case 1:
            case 2:
            case 3:
                item.Characteristics.XtraMight = true;
                if (item.Characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                }
                break;

            default:
                item.Characteristics.XtraShots = true;
                if (item.Characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    item.Characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                }
                break;
        }
    }

    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        base.EnchantItem(item, usedOkay, level, power);
        if (power > 1)
        {
            switch (Game.DieRoll(21))
            {
                case 1:
                case 11:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(BowOfExtraMightRareItem));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(ResistanceAndBiasItemAdditiveBundleWeightedRandom)));
                    break;
                case 2:
                case 12:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(BowOfExtraShotsRareItem));
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 13:
                case 14:
                case 15:
                case 16:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(BowOfVelocityRareItem));
                    break;
                case 7:
                case 8:
                case 9:
                case 10:
                case 17:
                case 18:
                case 19:
                case 20:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(BowOfAccuracyRareItem));
                    break;
                case 21:
                    item.CreateRandomArtifact(false);
                    break;
            }
        }
    }

    public RangedWeaponItemFactory(Game game) : base(game) { }
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(RangedWeaponInventorySlot));
    public override bool CanApplyBlowsBonus => true;

    public override int PackSort => 32;

    public override bool CanProjectArrows => true;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override ColorEnum Color => ColorEnum.Brown;
    public override bool CanApplyArtifactBiasSlaying => false;
}
