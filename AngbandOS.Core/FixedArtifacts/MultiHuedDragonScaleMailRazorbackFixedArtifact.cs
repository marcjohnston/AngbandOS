// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MultiHuedDragonScaleMailRazorbackFixedArtifact : FixedArtifact
{
    private MultiHuedDragonScaleMailRazorbackFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(MultiHuedDragonScaleMailItemFactory);

    // Razorback gives you a point-blank lightning ball
    protected override string? ActivationName => nameof(StarBall150Every1000p1d325DirectionalActivation);

    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "The Multi-Hued Dragon Scale Mail 'Razorback'";
    public override int Ac => 30;
    public override bool Aggravate => true;
    public override int Cost => 400000;
    public override int TreasureRating => 20;
    public override int Dd => 2;
    public override int Ds => 4;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Razorback'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImElec => true;
    public override int Level => 90;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for multi-hued dragon scale mail which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override int Rarity => 9;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ResPois => true;
    public override bool SeeInvis => true;
    public override int ToA => 25;
    public override int ToD => 0;
    public override int ToH => -4;
    public override int Weight => 500;
}
