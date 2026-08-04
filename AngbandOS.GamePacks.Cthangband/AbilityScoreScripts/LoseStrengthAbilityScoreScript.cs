namespace AngbandOS.GamePacks.Cthangband;

public class LoseStrengthAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override bool TrueToIncreaseFalseToDecrease => false;
}
