namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PseudoDragonItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BreatheLightOrDarkness200r2Every1d300p300DirectionalActivation);
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResDark => true;
    public override bool ResLight => true;
    public override int TreasureRating => 30;
}