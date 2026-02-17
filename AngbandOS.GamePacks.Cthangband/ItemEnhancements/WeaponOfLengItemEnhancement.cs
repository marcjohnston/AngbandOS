namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfLengItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Aggravate => true;
    public override bool? Valueless => true;
    public override bool? IsCursed => true;
    public override string? FriendlyName => "of Leng";
    public override bool? HeavyCurse => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusArmorClassAttribute), "1d10"),
        (nameof(ToDamageAttribute), "1d20"),
        (nameof(MeleeToHitAttribute), "1d20"),
        (nameof(ValueAttribute), "-25500"),
    };
    public override bool? SeeInvis => true;
}
