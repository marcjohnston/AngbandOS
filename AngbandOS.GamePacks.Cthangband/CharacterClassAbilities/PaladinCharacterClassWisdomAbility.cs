namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PaladinCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.PaladinCharacterClass);
    public override int Bonus => 1;
}