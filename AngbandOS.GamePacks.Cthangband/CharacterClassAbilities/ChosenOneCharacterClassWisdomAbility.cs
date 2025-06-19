namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChosenOneCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.ChosenOneCharacterClass);
    public override int Bonus => -2;
}