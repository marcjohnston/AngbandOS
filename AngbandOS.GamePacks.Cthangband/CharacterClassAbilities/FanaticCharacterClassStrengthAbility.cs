namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FanaticCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.FanaticCharacterClass);
    public override int Bonus => 2;
}