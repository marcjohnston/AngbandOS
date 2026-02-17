namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfLengItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HeavyCurseAttribute), "true"),
        (nameof(IsCursedAttribute), "true"),
    };
    public override bool? Aggravate => true;
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Leng";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusArmorClassAttribute), "1d10"),
        (nameof(ToDamageAttribute), "1d20"),
        (nameof(MeleeToHitAttribute), "1d20"),
        (nameof(ValueAttribute), "-25500"),
    };
    public override bool? SeeInvis => true;
}
