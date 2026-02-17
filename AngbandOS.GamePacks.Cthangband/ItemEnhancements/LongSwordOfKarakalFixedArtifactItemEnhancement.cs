namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordOfKarakalFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.GetawayEvery35Activation);
    public override bool? BrandElec => true;
    public override bool? Chaotic => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "12"),
        (nameof(MeleeToHitAttribute), "8"),
        (nameof(ValueAttribute), "150000"),
        (nameof(SpeedAttribute), "2"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(AttacksAttribute), "2"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "2"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Karakal";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResDark => true;
    public override bool? ResDisen => true;
    public override bool? ResElec => true;
    public override bool? ResFear => true;
    public override bool? ResLight => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayDemon => true;
    public override bool? SlayEvil => true;
    public override bool? SlowDigest => true;
    public override bool? SustCon => true;
    public override bool? SustInt => true;
    public override bool? SustStr => true;
    public override bool? SustWis => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
