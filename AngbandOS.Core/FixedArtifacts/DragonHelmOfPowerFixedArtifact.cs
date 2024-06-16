// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DragonHelmOfPowerFixedArtifact : FixedArtifact
{
    private DragonHelmOfPowerFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(DragonHelmArmorItemFactory);

    // Dragon Helm and Terror Mask cause fear
    protected override string? ActivationName => nameof(Terror40xEvery3xp10Activation);

    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "The Dragon Helm of Power";
    public override int Ac => 8;
    public override bool Con => true;
    public override int Cost => 300000;
    public override int TreasureRating => 20;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 3;
    public override string FriendlyName => "of Power";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a dragon helm which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override int InitialBonusConstitution => 4;
    public override int InitialBonusDexterity => 4;
    public override int InitialBonusStrength => 4;
    public override int Rarity => 12;
    public override bool ResAcid => true;
    public override bool ResBlind => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool Str => true;
    public override bool Telepathy => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 75;
}
