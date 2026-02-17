namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BattleAxeOfNKaiFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FeatherAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(RegenAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResBlindAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "3"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(StealthAttribute), "3"),
        (nameof(ValueAttribute), "90000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(AttacksAttribute), "5"),
        (nameof(MeleeToHitAttribute), "8"),
        (nameof(ToDamageAttribute), "11"),
        (nameof(TreasureRatingAttribute), "20"),
    };
    public override string FriendlyName => "of N'Kai";
    public override ColorEnum? Color => ColorEnum.Grey;
}
