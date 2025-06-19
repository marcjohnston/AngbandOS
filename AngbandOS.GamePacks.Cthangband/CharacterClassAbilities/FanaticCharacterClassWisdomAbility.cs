namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FanaticCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.FanaticCharacterClass);
    public override int Bonus => 0;
}