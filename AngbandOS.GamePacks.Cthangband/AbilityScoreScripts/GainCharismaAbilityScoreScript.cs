namespace AngbandOS.GamePacks.Cthangband;

public class GainCharismaAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override bool TrueToIncreaseFalseToDecrease => true;
}
