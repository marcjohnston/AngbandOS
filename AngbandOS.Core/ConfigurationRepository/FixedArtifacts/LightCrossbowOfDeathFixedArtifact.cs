// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LightCrossbowOfDeathFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private LightCrossbowOfDeathFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Bind()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(LightCrossbowBowWeaponItemFactory));
    }


    // Death brands your bolts
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your crossbow glows deep red...");
        saveGame.BrandBolts();
        item.RechargeTimeLeft = 999;
    }
    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        if (SaveGame.Rng.DieRoll(2) == 1)
        {
            IArtifactBias artifactBias = null;
            item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
        }
        else
        {
            item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
            item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
        }
    }
    public string DescribeActivationEffect() => "fire branding of bolts every 999 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBracketSymbol));
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "The Light Crossbow of Death";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 50000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override string FriendlyName => "of Death";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 50;
    public override int Pval => 10;
    public override int Rarity => 25;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 14;
    public override int ToH => 10;
    public override int Weight => 110;
    public override bool XtraMight => true;
}
