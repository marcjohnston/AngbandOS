// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CloakDarknessFixedArtifact : FixedArtifact
{
    private CloakDarknessFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(ClothCloakItemFactory);

    // Darkness sends monsters to sleep
    protected override string? ActivationName => nameof(SleepActivation);

    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "The Cloak 'Darkness'";
    public override int Ac => 1;
    public override int Cost => 13000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override string FriendlyName => "'Darkness'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 5;
    protected override string? BonusStealthRollExpression => "2";
    protected override string? BonusIntelligenceRollExpression => "2";
    protected override string? BonusWisdomRollExpression => "2";
    public override int Rarity => 45;
    public override bool ResAcid => true;
    public override bool ResDark => true;
    public override bool Stealth => true;
    public override int ToA => 4;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 10;
    public override bool Wis => true;
}
