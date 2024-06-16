// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BroadSwordDemonBladeFixedArtifact : FixedArtifact
{
    private BroadSwordDemonBladeFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(BroadSwordWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Broad Sword 'Demon Blade'";
    public override int Ac => 0;
    public override bool Aggravate => true;
    public override bool Blows => true;
    public override bool Cha => true;
    public override int Cost => 66666;
    public override int TreasureRating => 20;
    public override int Dd => 11;
    public override bool Dex => true;
    public override int Ds => 5;
    public override string FriendlyName => "'Demon Blade'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    protected override string? BonusAttacksRollExpression => "2";
    protected override string? BonusCharismaRollExpression => "2";
    protected override string? BonusDexterityRollExpression => "2";
    protected override string? BonusSpeedRollExpression => "2";
    protected override string? BonusStealthRollExpression => "2";
    public override int Rarity => 15;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Speed => true;
    public override bool Stealth => true;
    public override int ToA => 0;
    public override int ToD => 7;
    public override int ToH => -30;
    public override bool Vorpal => true;
    public override int Weight => 130;
}
