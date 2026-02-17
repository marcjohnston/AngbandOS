namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LochaberAxeOfTheDwarvesFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "17"),
        (nameof(MeleeToHitAttribute), "12"),
        (nameof(ValueAttribute), "80000"),
        (nameof(TunnelAttribute), "10"),
        (nameof(InfravisionAttribute), "10"),
    };
    public override string FriendlyName => "of the Dwarves";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFear => true;
    public override bool? ResFire => true;
    public override bool? ShowMods => true;
    public override bool? SlayEvil => true;
    public override bool? SlayGiant => true;
    public override ColorEnum? Color => ColorEnum.Black;
}
