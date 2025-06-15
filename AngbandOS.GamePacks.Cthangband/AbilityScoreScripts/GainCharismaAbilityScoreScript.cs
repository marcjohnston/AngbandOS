namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GainCharismaAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override bool TrueToIncreaseFalseToDecrease => true;
}
