namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OrbOfFreedomItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1000"),
    };
    public override bool? FreeAct => true;
    public override string? FriendlyName => "of Freedom";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    }
