
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ItemFactoryWeightedRandomGameConfiguration
{
    public virtual string? Key { get; set; } = null;
    public virtual (string, int)[] NameAndWeightBindings { get; set; }
}
