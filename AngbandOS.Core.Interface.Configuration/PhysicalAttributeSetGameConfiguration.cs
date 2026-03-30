
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class PhysicalAttributeSetGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual int BaseHeight { get; set; }
    public virtual int HeightRange { get; set; }
    public virtual int BaseWeight { get; set; }
    public virtual int WeightRange { get; set; }
}
