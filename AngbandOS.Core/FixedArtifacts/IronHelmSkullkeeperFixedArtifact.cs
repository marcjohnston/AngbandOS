// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class IronHelmSkullkeeperFixedArtifact : FixedArtifact
{
    private IronHelmSkullkeeperFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(IronHelmItemFactory);

    // Skull Keeper detects everything
    protected override string? ActivationName => nameof(DetectionEvery55p1d55Activation);

    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Iron Helm 'Skullkeeper'";
    public override int Ac => 5;
    public override int Cost => 100000;
    public override int TreasureRating => 20;
    public override int Dd => 1;
    public override int Ds => 3;
    public override string FriendlyName => "'Skullkeeper'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 20;
    protected override string? BonusIntelligenceRollExpression => "2";
    protected override string? BonusWisdomRollExpression => "2";
    public override int Rarity => 5;
    public override bool ResBlind => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override int ToA => 10;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 75;
    public override bool Wis => true;
}
