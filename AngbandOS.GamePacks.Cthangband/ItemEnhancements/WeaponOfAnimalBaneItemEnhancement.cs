namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfAnimalBaneItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "6000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(IntelligenceAttribute), "1d2"),
    };
    public override string? FriendlyName => "of Animal Bane";
    public override bool? Regen => true;
    public override bool? SlayAnimal => true;
 }
