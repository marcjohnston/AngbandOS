namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfSicklinessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Sickliness";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "1d5"),
        (nameof(DexterityAttribute), "1d5"),
        (nameof(ValueAttribute), "4800"),
    };
}
