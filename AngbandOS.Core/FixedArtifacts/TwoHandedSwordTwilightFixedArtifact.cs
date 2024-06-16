// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TwoHandedSwordTwilightFixedArtifact : FixedArtifact
{
    private TwoHandedSwordTwilightFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(TwoHandedSwordWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Two-Handed Sword 'Twilight'";
    public override int Ac => 0;
    public override bool Aggravate => true;
    public override bool BrandFire => true;
    public override int Cost => 0;
    public override bool IsCursed => true;
    public override int Dd => 4;
    public override bool DreadCurse => true;
    public override int Ds => 6;
    public override string FriendlyName => "'Twilight'";
    public override bool HeavyCurse => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImFire => true;
    public override int Level => 30;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a two-handed sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    protected override string? BonusSpeedRollExpression => "10";
    public override int Rarity => 15;
    public override bool ResDisen => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override bool Speed => true;
    public override int ToA => -50;
    public override int ToD => -60;
    public override int ToH => -40;
    public override int Weight => 250;
}
