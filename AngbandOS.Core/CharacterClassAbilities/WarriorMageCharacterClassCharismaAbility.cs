namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class WarriorMageCharacterClassCharismaAbility : CharacterClassAbility
{
    private WarriorMageCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(WarriorMageCharacterClass);
    public override int Bonus => 1;
}