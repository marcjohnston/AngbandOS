namespace AngbandOS.GamePacks.Cthangband;

public class GainConstitutionAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override bool TrueToIncreaseFalseToDecrease => true;
}
