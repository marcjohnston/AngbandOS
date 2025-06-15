namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LoseStrengthAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override bool TrueToIncreaseFalseToDecrease => false;
}
