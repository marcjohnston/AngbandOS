namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfSlayGiantItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
        (nameof(TreasureRatingAttribute), "14"),
    };
    public override string? FriendlyName => "of Slay Giant";
    public override bool? SlayGiant => true;
    }
