namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmuletOfAbdulAlhazredFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.DispelEvil5xEvery300p1d300Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(InfravisionAttribute), "3"),
        (nameof(ValueAttribute), "90000"),
        (nameof(CharismaAttribute), "3"),
        (nameof(WisdomAttribute), "3"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "of Abdul Alhazred";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? SeeInvis => true;
}
