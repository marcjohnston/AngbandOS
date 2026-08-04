namespace AngbandOS.GamePacks.Cthangband;

public class LoseCharismaAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override bool TrueToIncreaseFalseToDecrease => false;
}
