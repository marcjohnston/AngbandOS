namespace AngbandOS.Core.Interface.Configuration;

public class AbilityScoreScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual string LearnedDetails { get; set; } = "";
    public virtual bool UsesItem { get; set; } = true;
    public virtual string AbilityBindingKey { get; set; }
    public virtual bool TrueToIncreaseFalseToDecrease { get; set; }
}
