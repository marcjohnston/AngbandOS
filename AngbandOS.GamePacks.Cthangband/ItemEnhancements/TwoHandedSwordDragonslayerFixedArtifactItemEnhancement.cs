namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordDragonslayerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "17"),
        (nameof(MeleeToHitAttribute), "13"),
        (nameof(ValueAttribute), "100000"),
        (nameof(SlayDragonAttribute), "5"),
        (nameof(StrengthAttribute), "2"),
    };
    public override bool? FreeAct => true;
    public override string FriendlyName => "'Dragonslayer'";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ShowMods => true;
    public override bool? SlayTroll => true;
    public override bool? SlowDigest => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
