// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongSwordExcaliburFixedArtifact : FixedArtifact
{
    private LongSwordExcaliburFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(LongSwordWeaponItemFactory);

    // Excalibur shoots a frost ball
    protected override string? ActivationName => nameof(BallOfCold100r2Every300DirectionalActivation);

    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Long Sword 'Excalibur'";
    public override int Ac => 0;
    public override bool BrandCold => true;
    public override int Cost => 300000;
    public override int TreasureRating => 20;
    public override int Dd => 4;
    public override int Ds => 5;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Excalibur'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a long sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    protected override string? BonusSpeedRollExpression => "10";
    public override int Rarity => 120;
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayTroll => true;
    public override bool SlayUndead => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 25;
    public override int ToH => 22;
    public override int Weight => 130;
}
