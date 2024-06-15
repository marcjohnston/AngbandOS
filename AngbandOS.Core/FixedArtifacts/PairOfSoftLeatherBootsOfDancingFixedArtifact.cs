// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PairOfSoftLeatherBootsOfDancingFixedArtifact : FixedArtifact
{
    private PairOfSoftLeatherBootsOfDancingFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(SoftLeatherBootsArmorItemFactory);

    // Dancing heal poison and fear
    protected override string? ActivationName => nameof(RemoveFearAndPoisonEvery5Activation);

    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Pair of Soft Leather Boots of Dancing";
    public override int Ac => 2;
    public override bool Cha => true;
    public override int Cost => 40000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Dancing";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int InitialBonusCharisma => 5;
    public override int InitialBonusDexterity => 5;
    public override int Rarity => 25;
    public override bool ResChaos => true;
    public override bool ResNether => true;
    public override bool SustCha => true;
    public override bool SustCon => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 20;
}
