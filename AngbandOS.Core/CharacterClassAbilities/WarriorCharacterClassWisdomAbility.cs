namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class WarriorCharacterClassWisdomAbility : CharacterClassAbility
{
    private WarriorCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(WarriorCharacterClass);
    public override int Bonus => -2;
}