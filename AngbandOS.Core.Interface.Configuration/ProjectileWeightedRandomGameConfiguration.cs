
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ProjectileWeightedRandomGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual (string, int)[] NameAndWeightBindings { get; set; }
    public virtual string LearnedDetails { get; set; } = "";
}
