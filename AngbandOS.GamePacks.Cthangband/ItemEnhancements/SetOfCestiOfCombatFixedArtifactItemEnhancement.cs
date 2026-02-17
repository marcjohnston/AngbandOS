namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfCestiOfCombatFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.MagicalArrow150Every1d90p90DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "10"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "110000"),
        (nameof(RadiusAttribute), "3"),
        (nameof(DexterityAttribute), "4"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Combat";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ShowMods => true;
    public override bool? Feather => true;
    public override bool? HoldLife => true;
    public override bool? Regen => true;
    public override bool? SeeInvis => true;
    public override bool? SlowDigest => true;
    public override bool? Telepathy => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
