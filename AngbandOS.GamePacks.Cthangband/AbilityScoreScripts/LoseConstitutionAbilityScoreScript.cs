namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LoseConstitutionAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override bool TrueToIncreaseFalseToDecrease => false;
}
