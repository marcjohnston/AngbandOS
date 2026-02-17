namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MithrilChainMailOfTheVampireHunterFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.Heal777CuringAndHeroism25pd25Every300Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "-1"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "135000"),
        (nameof(WisdomAttribute), "4"),
        (nameof(StealthAttribute), "4"),
        (nameof(IntelligenceAttribute), "4"),
    };
    public override string FriendlyName => "of the Vampire Hunter";
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResDark => true;
    public override bool? ResElec => true;
    public override bool? ResFear => true;
    public override bool? ResFire => true;
    public override bool? ResNether => true;
    public override bool? ResPois => true;
    public override bool? SeeInvis => true;
    public override ColorEnum? Color => ColorEnum.BrightBlue;
}
