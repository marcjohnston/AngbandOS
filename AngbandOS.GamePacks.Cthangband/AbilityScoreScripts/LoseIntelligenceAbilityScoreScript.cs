namespace AngbandOS.GamePacks.Cthangband;

public class LoseIntelligenceAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override bool TrueToIncreaseFalseToDecrease => false;
}
