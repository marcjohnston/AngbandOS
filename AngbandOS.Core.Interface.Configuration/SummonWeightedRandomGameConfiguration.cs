
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class SummonWeightedRandomGameConfiguration
{
    public virtual string? Key { get; set; } = null;

    public virtual (string, int)[] NameAndWeightBindings { get; set; }

    /// <summary>
    /// Returns information about the spell, or blank if there is no detailed information.  Returns blank, by default.  Returns blank, by default.
    /// </summary>
    public virtual string LearnedDetails { get; set; } = "";
}