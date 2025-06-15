namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GainIntelligenceAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override bool TrueToIncreaseFalseToDecrease => true;
}
