namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GainConstitutionAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override bool TrueToIncreaseFalseToDecrease => true;
}
