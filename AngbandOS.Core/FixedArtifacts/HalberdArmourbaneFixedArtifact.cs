// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class HalberdArmorbaneFixedArtifact : FixedArtifact
{
    private HalberdArmorbaneFixedArtifact(Game game) : base(game) { }
    public override int TreasureRating => 10;

    protected override string BaseItemFactoryName => nameof(HalberdPolearmWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Halberd 'Armorbane'";
    public override int Ac => 0;
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override int Cost => 22000;
    public override int Dd => 3;
    public override int Ds => 5;
    public override bool Feather => true;
    public override string FriendlyName => "'Armorbane'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for an halberd which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusCharismaRollExpression => "3";
    public override int Rarity => 8;
    public override bool ResFire => true;
    public override bool ResSound => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayGiant => true;
    public override bool SlayUndead => true;
    public override int ToA => 0;
    public override int ToD => 9;
    public override int ToH => 6;
    public override int Weight => 190;
}
