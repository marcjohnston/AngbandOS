namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class PriestCharacterClassCharismaAbility : CharacterClassAbility
{
    private PriestCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(PriestCharacterClass);
    public override int Bonus => 2;
}