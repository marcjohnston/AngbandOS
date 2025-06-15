
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class AbilityScoreScriptGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual string LearnedDetails { get; set; } = "";
    public virtual bool UsesItem { get; set; } = true;
    public virtual string AbilityBindingKey { get; set; }
    public virtual bool TrueToIncreaseFalseToDecrease { get; set; }
}
