namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfImmolationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4000"),
        (nameof(TreasureRatingAttribute), "16"),
        (nameof(BonusArmorClassAttribute), "1d4"),
    };
    public override string? FriendlyName => "of Immolation";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    public override bool? ShFire => true;
}
