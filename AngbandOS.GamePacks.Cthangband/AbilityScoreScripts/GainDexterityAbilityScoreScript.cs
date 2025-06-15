namespace AngbandOS.GamePacks.Cthangband;
[Serializable]
public class GainDexterityAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override bool TrueToIncreaseFalseToDecrease => true;
}