using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class PhysicalAttributeSetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("int",
        Title = "Base Height",
        Summary = "Specifies the base height for the physical attribute set.")]
    public virtual int BaseHeight { get; set; }

    [ConfigurationProperty("int",
        Title = "Height Range",
        Summary = "Specifies the height variation range for the physical attribute set.")]
    public virtual int HeightRange { get; set; }

    [ConfigurationProperty("int",
        Title = "Base Weight",
        Summary = "Specifies the base weight for the physical attribute set.")]
    public virtual int BaseWeight { get; set; }

    [ConfigurationProperty("int",
        Title = "Weight Range",
        Summary = "Specifies the weight variation range for the physical attribute set.")]
    public virtual int WeightRange { get; set; }
}
