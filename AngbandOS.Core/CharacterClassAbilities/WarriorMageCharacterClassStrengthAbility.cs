namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class WarriorMageCharacterClassStrengthAbility : CharacterClassAbility
{
    private WarriorMageCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(WarriorMageCharacterClass);
    public override int Bonus => 2;
}