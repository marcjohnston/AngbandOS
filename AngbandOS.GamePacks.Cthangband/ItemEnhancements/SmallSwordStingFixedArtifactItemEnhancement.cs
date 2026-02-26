namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallSwordStingFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(AttacksAttribute), "1"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "8"),
        (nameof(MeleeToHitAttribute), "7"),
        (nameof(DiceSidesAttribute), "-1"),
        (nameof(ValueAttribute), "100000"),
        (nameof(WeightAttribute), "-5"),
        (nameof(DexterityAttribute), "2"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "2"),
    };
    public override string FriendlyName => "'Sting'";
}
