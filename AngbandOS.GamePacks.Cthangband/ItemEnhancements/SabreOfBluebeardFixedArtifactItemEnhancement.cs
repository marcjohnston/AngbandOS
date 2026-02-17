namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SabreOfBluebeardFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "8"),
        (nameof(MeleeToHitAttribute), "6"),
        (nameof(ValueAttribute), "25000"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(AttacksAttribute), "1"),
    };
    public override string FriendlyName => "of Bluebeard";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ShowMods => true;
    public override bool? SlayAnimal => true;
    public override bool? SlayGiant => true;
    public override bool? SlayOrc => true;
    public override bool? SlayTroll => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
