namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GainStrengthAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override bool TrueToIncreaseFalseToDecrease => true;
}
