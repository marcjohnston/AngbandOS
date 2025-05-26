namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class WarriorCharacterClassCharismaAbility : CharacterClassAbility
{
    private WarriorCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(WarriorCharacterClass);
    public override int Bonus => -1;
}