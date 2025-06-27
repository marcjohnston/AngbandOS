
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ProjectileScriptWeightedRandomGameConfiguration
{
    public virtual string? Key { get; set; } = null;
    public virtual (string, int)[] NameAndWeightBindings { get; set; }
    public virtual string LearnedDetails { get; set; } = "";
    public virtual LearnedDetailsWeightedRandomEnum LearnedDetailsMode { get; set; } = LearnedDetailsWeightedRandomEnum.Default;
}
