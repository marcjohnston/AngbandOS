
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ProjectileScriptWeightedRandomGameConfiguration
{
    public virtual string? Key { get; set; } = null;
    public virtual (string, int)[] NameAndWeightBindings { get; set; }
    public virtual string LearnedDetails { get; set; } = "";

    /// <summary>
    /// Returns how the learned details should be determined.  Returns <see cref="LearnedDetailsWeightedRandomEnum.Default"/>, by default.
    /// </summary>
    public virtual LearnedDetailsWeightedRandomEnum LearnedDetailsMode { get; set; } = LearnedDetailsWeightedRandomEnum.Default;
}
