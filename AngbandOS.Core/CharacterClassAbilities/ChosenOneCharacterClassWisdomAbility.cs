namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class ChosenOneCharacterClassWisdomAbility : CharacterClassAbility
{
    private ChosenOneCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(ChosenOneCharacterClass);
    public override int Bonus => -2;
}