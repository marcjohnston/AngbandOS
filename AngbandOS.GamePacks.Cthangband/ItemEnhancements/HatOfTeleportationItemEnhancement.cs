namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfTeleportationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Teleportation";
    public override bool? Teleport => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "250"),
    };
}
