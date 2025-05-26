namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class PriestCharacterClassWisdomAbility : CharacterClassAbility
{
    private PriestCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(PriestCharacterClass);
    public override int Bonus => 3;
}