namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class WarriorCharacterClassStrengthAbility : CharacterClassAbility
{
    private WarriorCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(WarriorCharacterClass);
    public override int Bonus => 5;
}