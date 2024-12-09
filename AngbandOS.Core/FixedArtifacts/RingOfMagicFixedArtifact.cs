// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfMagicFixedArtifact : FixedArtifact
{
    private RingOfMagicFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(BarahirRingItemFactory);

    // Ring of Magic has a djinn in it that drains life from an opponent
    protected override string? ActivationName => nameof(DrainLife100Every100p1d100DirectionalActivation);

    public override string Name => "The Ring of Magic";
    public override int Ac => 0;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 75000;
    public override int TreasureRating => 20;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override string FriendlyName => "of Magic";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 50;
    protected override string? BonusCharismaRollExpression => "1";
    protected override string? BonusConstitutionRollExpression => "1";
    protected override string? BonusDexterityRollExpression => "1";
    protected override string? BonusIntelligenceRollExpression => "1";
    protected override string? BonusSearchRollExpression => "1";
    protected override string? BonusStealthRollExpression => "1";
    protected override string? BonusWisdomRollExpression => "1";
    protected override string? BonusStrengthRollExpression => "1";
    public override int Rarity => 25;
    public override bool ResPois => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool Stealth => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 2;
    public override bool Wis => true;
}
