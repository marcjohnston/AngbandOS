namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChosenOneCharacterClassCharismaAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.ChosenOneCharacterClass);
    public override int Bonus => -1;
}