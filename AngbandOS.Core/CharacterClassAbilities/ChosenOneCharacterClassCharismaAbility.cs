namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class ChosenOneCharacterClassCharismaAbility : CharacterClassAbility
{
    private ChosenOneCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(ChosenOneCharacterClass);
    public override int Bonus => -1;
}