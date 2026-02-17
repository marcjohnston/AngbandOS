namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfSlayAnimalItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
        (nameof(TreasureRatingAttribute), "18"),
    };
    public override string? FriendlyName => "of Slay Animal";
    public override bool? SlayAnimal => true;
    }
