// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongBowOfSerpentsFixedArtifact : FixedArtifact
{
    private LongBowOfSerpentsFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(LongBowWeaponItemFactory);


    public override void ApplyResistances(Item item)
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
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBracketSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Long Bow of Serpents";
    public override int Ac => 0;
    public override int Cost => 20000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Serpents";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 3;
    public override int Rarity => 20;
    public override bool ShowMods => true;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 17;
    public override int Weight => 40;
    public override bool XtraMight => true;
}
