namespace AngbandOS.Core.Interface.Metadata;

public class GameMetadata
{
    public PropertyMetadata[] Properties { get; protected set; } = null!;
    public EnumMetadata[] Enums { get; protected set; } = null!;
    public GameMetadata(PropertyMetadata[] properties, EnumMetadata[] enums)
    {
        Properties = properties;
        Enums = enums;
    }
}
