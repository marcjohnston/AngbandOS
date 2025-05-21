
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class PhysicalAttributeSetGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual int BaseHeight { get; set; }
    public virtual int HeightRange { get; set; }
    public virtual int BaseWeight { get; set; }
    public virtual int WeightRange { get; set; }
}
