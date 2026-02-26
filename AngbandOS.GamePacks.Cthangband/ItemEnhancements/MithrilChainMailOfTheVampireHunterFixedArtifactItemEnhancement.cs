namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MithrilChainMailOfTheVampireHunterFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HoldLifeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFearAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResNetherAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
    };
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
}
