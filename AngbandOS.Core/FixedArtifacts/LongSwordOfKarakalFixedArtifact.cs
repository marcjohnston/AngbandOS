 // AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongSwordOfKarakalFixedArtifact : FixedArtifact
{
    private LongSwordOfKarakalFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(LongSwordWeaponItemFactory);

    // Karakal teleports you randomly
    protected override string? ActivationName => nameof(GetawayEvery35Activation);

    public string DescribeActivationEffect => "a getaway every 35 turns";

    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Long Sword of Karakal";
    public override int Ac => 0;
    public override bool Blows => true;
    public override bool BrandElec => true;
    public override bool Chaotic => true;
    public override bool Con => true;
    public override int Cost => 150000;
    public override int TreasureRating => 20;
    public override int Dd => 2;
    public override int Ds => 5;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Karakal";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a long sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    protected override string? BonusAttacksRollExpression => "2";
    protected override string? BonusConstitutionRollExpression => "2";
    protected override string? BonusSpeedRollExpression => "2";
    protected override string? BonusStrengthRollExpression => "2";
    public override int Rarity => 30;
    public override bool Regen => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ResElec => true;
    public override bool ResFear => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool SustCon => true;
    public override bool SustInt => true;
    public override bool SustStr => true;
    public override bool SustWis => true;
    public override int ToA => 0;
    public override int ToD => 12;
    public override int ToH => 8;
    public override int Weight => 130;
}
