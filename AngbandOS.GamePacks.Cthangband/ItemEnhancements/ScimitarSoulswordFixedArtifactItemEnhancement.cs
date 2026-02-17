namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScimitarSoulswordFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Blessed => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(AttacksAttribute), "1"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "11"),
        (nameof(MeleeToHitAttribute), "9"),
        (nameof(ValueAttribute), "111111"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "2"),
    };
    public override string FriendlyName => "'Soulsword'";
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResChaos => true;
    public override bool? ResDisen => true;
    public override bool? ResNether => true;
    public override bool? ResNexus => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayAnimal => true;
    public override bool? SlayDemon => true;
    public override bool? SlayEvil => true;
    public override bool? SlayUndead => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
