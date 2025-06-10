// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerIcicleFixedArtifact : FixedArtifact
{
    private DaggerIcicleFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(DaggerWeaponItemFactory);

    // Icicle shoots a cold ball
    protected override string? ActivationName => nameof(BallOfCold48r2Every5p1d5DirectionalActivation);

    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Dagger 'Icicle'";
    public override int Ac => 0;
    public override bool Blows => true;
    public override bool BrandCold => true;
    public override bool BrandPois => true;
    public override int Cost => 50000;
    public override int Dd => 2;
    public override bool Dex => true;
    public override int Ds => 4;
    public override string FriendlyName => "'Icicle'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    protected override string? BonusAttacksRollExpression => "2";
    protected override string? BonusDexterityRollExpression => "2";
    protected override string? BonusSpeedRollExpression => "2";
    public override int Rarity => 40;
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 9;
    public override int ToH => 6;
    public override int Weight => 12;
}
