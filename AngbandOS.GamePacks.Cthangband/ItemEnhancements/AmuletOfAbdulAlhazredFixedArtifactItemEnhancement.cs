namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmuletOfAbdulAlhazredFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.DispelEvil5xEvery300p1d300Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(InfravisionAttribute), "3"),
        (nameof(ValueAttribute), "90000"),
        (nameof(CharismaAttribute), "3"),
        (nameof(WisdomAttribute), "3"),
    };
    public override string FriendlyName => "of Abdul Alhazred";
}
