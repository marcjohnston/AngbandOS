namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MultiHuedDragonScaleMailRazorbackFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Razorback gives you a point-blank lightning ball
    public override string? ActivationName => nameof(ActivationsEnum.StarBall150Every1000p1d325DirectionalActivation);
    public override bool Aggravate => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Razorback'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImElec => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for multi-hued dragon scale mail which provides no light.
    /// </summary>
    public override int Radius => 3;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ResPois => true;
    public override bool SeeInvis => true;
    public override int Weight => 300;
    public override int Cost => 400000;
}
