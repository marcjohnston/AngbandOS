namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfHurtAnimalItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "25"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Hurt Animal";
    public override bool? SlayAnimal => true;
}
