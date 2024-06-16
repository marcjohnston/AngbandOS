// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfBastFixedArtifact : FixedArtifact
{
    private RingOfBastFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(TulkasRingItemFactory);

    // Ring of Bast hastes you
    protected override string? ActivationName => nameof(Speed75p1d75Every150p1d150Activation);

    public override string Name => "The Ring of Bast";
    public override int Ac => 0;
    public override bool Con => true;
    public override int Cost => 175000;
    public override int TreasureRating => 20;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override string FriendlyName => "of Bast";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override int Level => 70;
    protected override string? BonusConstitutionRollExpression => "4";
    protected override string? BonusDexterityRollExpression => "4";
    protected override string? BonusSpeedRollExpression => "4";
    protected override string? BonusStrengthRollExpression => "4";
    public override int Rarity => 50;
    public override bool Speed => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 2;
}
