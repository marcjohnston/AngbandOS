namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CutlassOfBlackbeardFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(DexterityAttribute), "3"),
        (nameof(StealthAttribute), "3"),
        (nameof(ValueAttribute), "28000"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(ToDamageAttribute), "11"),
    };
    public override bool? Feather => true;
    public override string FriendlyName => "of Blackbeard";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
