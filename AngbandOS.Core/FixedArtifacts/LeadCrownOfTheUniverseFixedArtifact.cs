// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LeadCrownOfTheUniverseFixedArtifact : FixedArtifact
{
    private LeadCrownOfTheUniverseFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(LeadCrownArmorItemFactory);


    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "The Lead Crown of the Universe";
    public override int Ac => 0;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 10000000;
    public override int TreasureRating => 20;
    public override bool IsCursed => true;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override string FriendlyName => "of the Universe";
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 100;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a lead crown which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override bool NoTele => true;
    public override bool PermaCurse => true;
    protected override string? BonusCharismaRollExpression => "125";
    protected override string? BonusConstitutionRollExpression => "125";
    protected override string? BonusDexterityRollExpression => "125";
    protected override string? BonusIntelligenceRollExpression => "125";
    protected override string? BonusInfravisionRollExpression => "125";
    protected override string? BonusStrengthRollExpression => "125";
    protected override string? BonusWisdomRollExpression => "125";
    public override int Rarity => 1;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ResNexus => true;
    public override bool ResPois => true;
    public override bool SeeInvis => true;
    public override bool Str => true;
    public override bool Telepathy => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 20;
    public override bool Wis => true;
}
