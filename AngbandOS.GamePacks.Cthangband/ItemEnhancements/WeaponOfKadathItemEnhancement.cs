namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfKadathItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "20000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "1d5"),
        (nameof(ToDamageAttribute), "1d5"),
        (nameof(DexterityAttribute), "1d2"),
        (nameof(ConstitutionAttribute), "1d2"),
        (nameof(StrengthAttribute), "1d2"),
    };
    public override bool? FreeAct => true;
    public override string? FriendlyName => "of Kadath";
    public override bool? SeeInvis => true;
    public override bool? SlayGiant => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
}
