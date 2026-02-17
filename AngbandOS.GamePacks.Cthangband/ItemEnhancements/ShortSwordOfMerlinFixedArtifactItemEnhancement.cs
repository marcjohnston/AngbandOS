namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShortSwordOfMerlinFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "7"),
        (nameof(MeleeToHitAttribute), "3"),
        (nameof(ValueAttribute), "35000"),
        (nameof(AttacksAttribute), "2"),
    };
    public override string FriendlyName => "of Merlin";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Regen => true;
    public override bool? ResDisen => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayAnimal => true;
    public override bool? SlowDigest => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
