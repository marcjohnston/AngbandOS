namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OrbOfInstabilityItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Instability";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
        public override bool? Teleport => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "650"),
    };
}
