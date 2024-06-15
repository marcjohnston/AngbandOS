// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RapierOfMontoyaFixedArtifact : FixedArtifact
{
    private RapierOfMontoyaFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(RapierWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Rapier of Montoya";
    public override int Ac => 0;
    public override bool BrandCold => true;
    public override int Cost => 15000;
    public override int Dd => 1;
    public override int Ds => 6;
    public override string FriendlyName => "of Montoya";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 15;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a rapier which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override int Rarity => 8;
    public override bool ResCold => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 12;
    public override int Weight => 40;
}
