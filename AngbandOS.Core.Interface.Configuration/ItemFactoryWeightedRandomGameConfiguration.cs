
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ItemFactoryWeightedRandomGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual (string, int)[] NameAndWeightBindings { get; set; }
}
