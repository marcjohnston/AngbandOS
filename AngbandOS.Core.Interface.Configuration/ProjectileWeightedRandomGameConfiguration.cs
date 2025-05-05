

namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ProjectileWeightedRandomGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual (string, int)[] NameAndWeightBindingTuples { get; set; }
}
