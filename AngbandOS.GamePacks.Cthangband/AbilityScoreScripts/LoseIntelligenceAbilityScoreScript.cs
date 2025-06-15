namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LoseIntelligenceAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override bool TrueToIncreaseFalseToDecrease => false;
}
