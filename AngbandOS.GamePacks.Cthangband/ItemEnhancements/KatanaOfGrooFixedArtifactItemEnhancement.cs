namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KatanaOfGrooFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(DamageDiceAttribute), "5"),
        (nameof(ValueAttribute), "75000"),
        (nameof(WeightAttribute), "-70"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(Vorpal1InChanceAttribute), "6"),
        (nameof(SpeedAttribute), "3"),
        (nameof(DexterityAttribute), "3"),
        (nameof(AttacksAttribute), "3"),
    };
    public override string FriendlyName => "of Groo";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ShowMods => true;
    public override bool? SustDex => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
