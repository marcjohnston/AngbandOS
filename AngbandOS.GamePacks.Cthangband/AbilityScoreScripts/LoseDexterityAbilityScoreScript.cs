namespace AngbandOS.GamePacks.Cthangband;

public class LoseDexterityAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override bool TrueToIncreaseFalseToDecrease => false;
}
