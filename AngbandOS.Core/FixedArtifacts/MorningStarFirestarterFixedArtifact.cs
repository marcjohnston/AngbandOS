// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MorningStarFirestarterFixedArtifact : FixedArtifact
{
    private MorningStarFirestarterFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(MorningStarHaftedWeaponItemFactory);

    // Firestarter does fire ball
    protected override string? ActivationName => nameof(LargeBallFire72Every100DirectionalActivation);

    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "The Morning Star 'Firestarter'";
    public override int Ac => 0;
    public override bool BrandFire => true;
    public override int Cost => 35000;
    public override int Dd => 2;
    public override int Ds => 6;
    public override string FriendlyName => "'Firestarter'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a morning star which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override int Rarity => 15;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override int ToA => 2;
    public override int ToD => 7;
    public override int ToH => 5;
    public override int Weight => 150;
}
