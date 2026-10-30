using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class PhysicalAttributeSetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Base Height",
        Summary = "Specifies the base height for the physical attribute set.",
        DataType = "int")]
    public virtual int BaseHeight { get; set; }

    [ConfigurationMetadata(
        Title = "Height Range",
        Summary = "Specifies the height variation range for the physical attribute set.",
        DataType = "int")]
    public virtual int HeightRange { get; set; }

    [ConfigurationMetadata(
        Title = "Base Weight",
        Summary = "Specifies the base weight for the physical attribute set.",
        DataType = "int")]
    public virtual int BaseWeight { get; set; }

    [ConfigurationMetadata(
        Title = "Weight Range",
        Summary = "Specifies the weight variation range for the physical attribute set.",
        DataType = "int")]
    public virtual int WeightRange { get; set; }
}
