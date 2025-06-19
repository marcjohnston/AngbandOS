namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PriestCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.PriestCharacterClass);
    public override int Bonus => 3;
}