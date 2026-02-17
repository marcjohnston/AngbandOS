namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfLawItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "25000"),
        (nameof(TreasureRatingAttribute), "26"),
        (nameof(MeleeToHitAttribute), "1d6"),
        (nameof(ToDamageAttribute), "1d6"),
        (nameof(ConstitutionAttribute), "1d2"),
        (nameof(StrengthAttribute), "1d2"),
    };
    public override bool? FreeAct => true;
    public override string? FriendlyName => "(Weapon of Law)";
    public override bool? SeeInvis => true;
    public override bool? SlayDemon => true;
    public override bool? SlayEvil => true;
    public override bool? SlayUndead => true;
}
