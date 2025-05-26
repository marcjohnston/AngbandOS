namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class RangerCharacterClassCharismaAbility : CharacterClassAbility
{
    private RangerCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(RangerCharacterClass);
    public override int Bonus => 1;
}